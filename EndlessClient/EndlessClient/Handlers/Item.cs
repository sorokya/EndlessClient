﻿using System;
using EOLib;

namespace EndlessClient.Handlers
{
	public static class Item
	{
		public static bool GetItem(short uid)
		{
			EOClient client = (EOClient) World.Instance.Client;
			if (client == null || !client.ConnectedAndInitialized)
				return false;

			Packet pkt = new Packet(PacketFamily.Item, PacketAction.Get);
			pkt.AddShort(uid);

			return client.SendPacket(pkt);
		}

		public static void DropItem(short id, int amount, byte x = 255, byte y = 255) //255 means use character's current location
		{
			EOClient client = (EOClient) World.Instance.Client;
			if (client == null || !client.ConnectedAndInitialized)
				return;

			Packet pkt = new Packet(PacketFamily.Item, PacketAction.Drop);
			pkt.AddShort(id);
			pkt.AddInt(amount);
			if (x == 255 && y == 255)
			{
				pkt.AddByte(x);
				pkt.AddByte(y);
			}
			else
			{
				pkt.AddChar(x);
				pkt.AddChar(y);
			}

			client.SendPacket(pkt);
		}

		public static void JunkItem(short id, int amount)
		{
			EOClient client = (EOClient) World.Instance.Client;
			if (client == null || !client.ConnectedAndInitialized)
				return;
			
			Packet pkt = new Packet(PacketFamily.Item, PacketAction.Junk);
			pkt.AddShort(id);
			pkt.AddInt(amount);

			client.SendPacket(pkt);
		}

		/// <summary>
		/// Sent when an Item is dropped by the MainPlayer
		/// See ItemAddResponse for when another player drops an item
		/// </summary>
		public static void ItemDropResponse(Packet pkt)
		{
			short _id = pkt.GetShort();
			int _amount = pkt.GetThree();
			int characterAmount = pkt.GetInt(); //amount remaining for the character
			MapItem item = new MapItem
			{
				id = _id,
				amount = _amount,
				uid = pkt.GetShort(),
				x = pkt.GetChar(),
				y = pkt.GetChar(),
				//turn off drop protection since main player dropped it
				time = DateTime.Now.AddSeconds(-5),
				npcDrop = false,
				playerID = World.Instance.MainPlayer.ActiveCharacter.ID
			};
			byte characterWeight = pkt.GetChar(), characterMaxWeight = pkt.GetChar(); //character adjusted weights

			World.Instance.ActiveMapRenderer.AddMapItem(item);
			World.Instance.MainPlayer.ActiveCharacter.UpdateInventoryItem(_id, characterAmount, characterWeight, characterMaxWeight);
		}

		/// <summary>
		/// Item is added to the map (sent when another player drops an item)
		/// </summary>
		public static void ItemAddResponse(Packet pkt)
		{
			World.Instance.ActiveMapRenderer.AddMapItem(new MapItem
			{
				id = pkt.GetShort(),
				uid = pkt.GetShort(),
				amount = pkt.GetThree(),
				x = pkt.GetChar(),
				y = pkt.GetChar(),
				time = DateTime.Now,
				npcDrop = false,
				playerID = -1 //unknown ID! so it will say Item is protected w/o "by player"
			});
		}

		public static void ItemRemoveResponse(Packet pkt)
		{
			short itemUid = pkt.GetShort();
			World.Instance.ActiveMapRenderer.RemoveMapItem(itemUid);
		}

		public static void ItemJunkResponse(Packet pkt)
		{
			short id = pkt.GetShort();
			/*int amountRemoved = */pkt.GetThree();//don't really care - just math it
			int amountRemaining = pkt.GetInt();
			byte weight = pkt.GetChar();
			byte maxWeight = pkt.GetChar();

			World.Instance.MainPlayer.ActiveCharacter.UpdateInventoryItem(id, amountRemaining, weight, maxWeight);
		}

		/// <summary>
		/// Main player is picking an item up off the map
		/// </summary>
		public static void ItemGetResponse(Packet pkt)
		{
			short uid = pkt.GetShort();
			short id = pkt.GetShort();
			int amountTaken = pkt.GetThree();
			byte weight = pkt.GetChar();
			byte maxWeight = pkt.GetChar();

			if (uid != 0)
			{
				World.Instance.ActiveMapRenderer.UpdateMapItemAmount(uid, amountTaken);
			}

			World.Instance.MainPlayer.ActiveCharacter.UpdateInventoryItem(id, amountTaken, weight, maxWeight, true);//true: adding amounts if item ID exists
			EOGame.Instance.Hud.SetStatusLabel(string.Format("[ Information ] You picked up {0} {1}", amountTaken, World.Instance.EIF.GetItemRecordByID(id).Name));
		}
	}
}
