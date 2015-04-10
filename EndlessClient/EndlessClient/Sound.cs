﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EOLib;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace EndlessClient
{
	//sfx001 will be ID int 0
	public enum SoundEffectID
	{
		LayeredTechIntro,
		ButtonClick,
		DialogButtonClick,
		TextBoxFocus, //also the sound when opening chest?
		Login = 4, //also the sound from a server message?
		UnknownShimmerSound,
		UnknownStaticSound,
		ScreenCapture,
		PMReceived = 8,
		PunchAttack,
		UnknownWarpSound,
		UnknownPingSound,
		UnknownClickSound = 12,
		UnknownHarpSound,
		MeleeWeaponAttack,
		UnknownClickSound2,
		TradeAccepted = 16,
		UnknownNotificationSound,
		UnknownWhooshSound,
		ItemInventoryPickup,
		ItemInventoryPlace = 20,
		Earthquake,
		DoorClose,
		DoorOpen,
		UnknownClickSound3 = 24,
		BuySell,
		Craft,
		UnknownBuzzSound,
		UnknownBloopSound = 28,
		UnknownAttackLikeSound,
		PotionOfFlamesEffect,
		AdminWarp,
		NoWallWalk = 32,
		PotionOfEvilTerrorEffect,
		PotionOfFireworksEffect,
		PotionOfSparklesEffect,
		LearnNewSpell = 36,
		AttackBow,
		LevelUp,
		Dead,
		JumpStone = 40,
		Water,
		Heal,
		Harp1,
		Harp2 = 44,
		Harp3,
		Guitar1,
		Guitar2,
		Guitar3 = 48,
		Thunder,
		UnknownTimerSound,
		UnknownFanfareSound,
		Gun = 52,
		UltimaBlastSpell,
		ShieldSpell,
		UnknownAggressiveShieldSound,
		IceBlastSpell1 = 56,
		EnergyBallSpell,
		WhirlSpell,
		BouldersSpell,
		HeavenSpell = 60,
		//there's another ice blast spell in here

		//not sure what the remaining sounds are but I think map ambient noises start eventually
		//map noises seem to fade out as you change maps or get farther away from them
	}

	//mfx001 will be ID int 0
	public enum MusicEffectID
	{
		
	}

	public enum Note
	{
		
	}

	public class EOSoundManager : IDisposable
	{
		private class SoundInfo : IDisposable
		{
			private readonly SoundEffect m_effect;

			private readonly List<SoundEffectInstance> m_instances;

			public SoundInfo(SoundEffect toWrap)
			{
				if (toWrap == null) return;

				m_effect = toWrap;
				m_instances = new List<SoundEffectInstance> { toWrap.CreateInstance() };
			}

			public SoundEffectInstance GetNextAvailableInstance()
			{
				if (m_effect == null) return null;

				SoundEffectInstance ret = m_instances.Find(_sei => _sei.State == SoundState.Stopped);
				if(ret == null)
					m_instances.Add(ret = m_effect.CreateInstance());
				return ret;
			}

			public void Dispose()
			{
				Dispose(true);
			}

			private void Dispose(bool disposing)
			{
				if (disposing)
				{
					m_instances.ForEach(_inst =>
					{
						_inst.Stop();
						_inst.Dispose();
					});
					m_effect.Dispose();
				}
				GC.SuppressFinalize(this);
			}
		}

		//some of the original SFX files will fail to load because the file length is stored incorrectly in the WAV header.
		//this method fixes those in-place. make sure to have backups! :)
		private void _correctTheFileLength(string filename)
		{
			byte[] wav = File.ReadAllBytes(filename);

			string riff = Encoding.ASCII.GetString(wav.SubArray(0, 4));
			if (riff != "RIFF" || wav.Length < 8) //check for RIFF tag and length
				return;

			int reportedLength = wav[4] + wav[5]*256 + wav[6]*65536 + wav[7]*16777216;
			int actualLength = wav.Length - 8;

			if (reportedLength != actualLength)
			{
				wav[4] = (byte) (actualLength & 0xFF);
				wav[5] = (byte) ((actualLength >> 8) & 0xFF);
				wav[6] = (byte) ((actualLength >> 16) & 0xFF);
				wav[7] = (byte) ((actualLength >> 24) & 0xFF);
				File.WriteAllBytes(filename, wav);
			}
		}

		private const string SFX_DIR = "sfx";
		private const string MFX_DIR = "mfx";

		private List<SoundInfo> m_sounds;
		private List<SoundInfo> m_guitarSounds;
		private List<SoundInfo> m_harpSounds;
		private List<Song> m_music;

		//singleton pattern -- any newly constructed instance is copied from the 'instance'
		private static readonly object _construction_locker_ = new object();
		private static EOSoundManager inst;

		private bool IsDisposed { get; set; }

		public EOSoundManager()
		{
			lock (_construction_locker_)
			{
				if (inst != null)
				{
					_copyFrom(inst);
					return;
				}

				string[] soundFiles = Directory.GetFiles(SFX_DIR, "*.wav");
				Array.Sort(soundFiles);

				string[] musicFiles = Directory.GetFiles(MFX_DIR, "*.mid");
				Array.Sort(musicFiles);

				m_sounds = new List<SoundInfo>(81);
				m_guitarSounds = new List<SoundInfo>(36);
				m_harpSounds = new List<SoundInfo>(36);
				m_music = new List<Song>(musicFiles.Length);

				foreach (string sfx in soundFiles)
				{
					_correctTheFileLength(sfx);

					using (FileStream fs = new FileStream(sfx, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						//Note: this MAY throw InvalidOperationException if the file is invalid. However, _correctTheFileLength fixes
						//	this for the original sfx files.
						SoundEffect nextEffect = SoundEffect.FromStream(fs);

						if (sfx.ToLower().Contains("gui"))
							m_guitarSounds.Add(nextEffect == null ? null : new SoundInfo(nextEffect));
						else if (sfx.ToLower().Contains("har"))
							m_harpSounds.Add(nextEffect == null ? null : new SoundInfo(nextEffect));
						else
							m_sounds.Add(nextEffect == null ? null : new SoundInfo(nextEffect));
					}
				}

				foreach (string mfx in musicFiles)
				{
					Song nextSong = Song.FromUri(mfx, new Uri(mfx, UriKind.Relative));
					m_music.Add(nextSong);
				}

				MediaPlayer.IsRepeating = true;

				inst = this;
			}
		}

		private void _copyFrom(EOSoundManager other)
		{
			//shallow copy is intended
			m_sounds = other.m_sounds;
			m_guitarSounds = other.m_guitarSounds;
			m_harpSounds = other.m_harpSounds;
			m_music = other.m_music;
		}

		public SoundEffectInstance GetGuitarSoundRef(Note which)
		{
			return m_guitarSounds[(int) which].GetNextAvailableInstance();
		}

		public SoundEffectInstance GetHarpSoundRef(Note which)
		{
			return m_harpSounds[(int) which].GetNextAvailableInstance();
		}

		public SoundEffectInstance GetSoundEffectRef(SoundEffectID whichSoundEffect)
		{
			return m_sounds[(int)whichSoundEffect].GetNextAvailableInstance();
		}

		public bool PlaySong(MusicEffectID whichMusicEffect)
		{
			MediaPlayer.Stop();
			try
			{
				MediaPlayer.Play(m_music[(int) whichMusicEffect]);
			}
			catch (ArgumentNullException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			return true;
		}

		~EOSoundManager()
		{
			//ensure that primary instance is disposed of if the reference to it is not explicitly disposed
			if (this == inst && !IsDisposed)
			{
				Dispose(true);
			}
		}

		public void Dispose()
		{
			if (this != inst)
				return;

			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				foreach (Song mfx in m_music)
				{
					MediaPlayer.Stop();
					mfx.Dispose();
				}

				foreach (var sfx in m_sounds)
					sfx.Dispose();

				foreach (var gui in m_guitarSounds)
					gui.Dispose();

				foreach (var har in m_harpSounds)
					har.Dispose();
			}

			IsDisposed = true;
			GC.SuppressFinalize(this);
		}
	}
}
