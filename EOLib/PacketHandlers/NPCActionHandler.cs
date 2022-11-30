using AutomaticTypeMapper;
using EOLib.Domain.Character;
using EOLib.Domain.Chat;
using EOLib.Domain.Extensions;
using EOLib.Domain.Login;
using EOLib.Domain.Map;
using EOLib.Domain.Notifiers;
using EOLib.Domain.NPC;
using EOLib.IO.Repositories;
using EOLib.Net;
using EOLib.Net.Handlers;
using Optional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EOLib.PacketHandlers
{
    [AutoMappedType]
    public class NPCActionHandler : InGameOnlyPacketHandler
    {
        private const int NPC_WALK_ACTION = 0;
        private const int NPC_ATTK_ACTION = 1;
        private const int NPC_TALK_ACTION = 2;

        private readonly ICharacterRepository _characterRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IENFFileProvider _enfFileProvider;
        private readonly ICurrentMapStateRepository _currentMapStateRepository;
        private readonly IEnumerable<INPCActionNotifier> _npcAnimationNotifiers;
        private readonly IEnumerable<IMainCharacterEventNotifier> _mainCharacterNotifiers;
        private readonly IEnumerable<IOtherCharacterEventNotifier> _otherCharacterNotifiers;

        public override PacketFamily Family => PacketFamily.NPC;

        public override PacketAction Action => PacketAction.Player;

        public NPCActionHandler(IPlayerInfoProvider playerInfoProvider,
                                ICurrentMapStateRepository currentMapStateRepository,
                                ICharacterRepository characterRepository,
                                IChatRepository chatRepository,
                                IENFFileProvider enfFileProvider,
                                IEnumerable<INPCActionNotifier> npcAnimationNotifiers,
                                IEnumerable<IMainCharacterEventNotifier> mainCharacterNotifiers,
                                IEnumerable<IOtherCharacterEventNotifier> otherCharacterNotifiers)
            : base(playerInfoProvider)
        {
            _currentMapStateRepository = currentMapStateRepository;
            _characterRepository = characterRepository;
            _chatRepository = chatRepository;
            _enfFileProvider = enfFileProvider;
            _npcAnimationNotifiers = npcAnimationNotifiers;
            _mainCharacterNotifiers = mainCharacterNotifiers;
            _otherCharacterNotifiers = otherCharacterNotifiers;
        }

        public override bool HandlePacket(IPacket packet)
        {
            while (!packet.EOF() && packet.PeekByte() != 255)
            {
                HandleNPCWalk(packet);
            }

            if (packet.EOF())
                return true;

            packet.ReadByte(); //255

            while (!packet.EOF() && packet.PeekByte() != 255)
            {
                var updatedNpc = HandleNPCAttack(packet);
                if (updatedNpc != null)
                {
                    _currentMapStateRepository.NPCs.Remove(updatedNpc);
                    _currentMapStateRepository.NPCs.Add(updatedNpc);
                }
            }

            if (packet.EOF())
                return true;

            packet.ReadByte(); //255

            while (!packet.EOF() && packet.PeekByte() != 255)
            {
                HandleNPCTalk(packet);
            }

            return true;
        }

        private NPC GetNPCFromPacket(IPacket packet)
        {
            var index = packet.ReadChar();
            NPC npc;
            try
            {
                npc = _currentMapStateRepository.NPCs.Single(n => n.Index == index);
            }
            catch (InvalidOperationException)
            {
                _currentMapStateRepository.UnknownNPCIndexes.Add(index);
                npc = null;
            }

            return npc;
        }

        private void HandleNPCWalk(IPacket packet)
        {
            var npc = GetNPCFromPacket(packet);
            if (npc == null)
                return;

            //npc remove from view sets x/y to either 0,0 or 252,252 based on target coords
            var x = packet.ReadChar();
            var y = packet.ReadChar();
            var npcDirection = (EODirection) packet.ReadChar();

            var updatedNPC = npc.WithDirection(npcDirection);
            updatedNPC = EnsureCorrectXAndY(updatedNPC, x, y);

            _currentMapStateRepository.NPCs.Remove(npc);
            _currentMapStateRepository.NPCs.Add(updatedNPC);

            foreach (var notifier in _npcAnimationNotifiers)
                notifier.StartNPCWalkAnimation(npc.Index);
        }

        private NPC HandleNPCAttack(IPacket packet)
        {
            var npc = GetNPCFromPacket(packet);
            if (npc == null)
                return npc;

            var isDead = packet.ReadChar() == 2; //2 if target player is dead, 1 if alive
            var npcDirection = (EODirection)packet.ReadChar();
            var characterID = packet.ReadShort();
            var damageTaken = packet.ReadThree();
            var playerPercentHealth = packet.ReadThree();

            if (characterID == _characterRepository.MainCharacter.ID)
            {
                var characterToUpdate = _characterRepository.MainCharacter;

                var stats = characterToUpdate.Stats;
                stats = stats.WithNewStat(CharacterStat.HP, (short)Math.Max(stats[CharacterStat.HP] - damageTaken, 0));

                var props = characterToUpdate.RenderProperties.WithIsDead(isDead);
                _characterRepository.MainCharacter = characterToUpdate.WithStats(stats).WithRenderProperties(props);

                foreach (var notifier in _mainCharacterNotifiers)
                    notifier.NotifyTakeDamage(damageTaken, playerPercentHealth, isHeal: false);
            }
            else if (_currentMapStateRepository.Characters.ContainsKey(characterID))
            {
                var updatedCharacter = _currentMapStateRepository.Characters[characterID].WithDamage(damageTaken, isDead);
                _currentMapStateRepository.Characters[characterID] = updatedCharacter;

                foreach (var notifier in _otherCharacterNotifiers)
                    notifier.OtherCharacterTakeDamage(characterID, playerPercentHealth, damageTaken, isHeal: false);
            }
            else
            {
                _currentMapStateRepository.UnknownPlayerIDs.Add(characterID);
            }

            foreach (var notifier in _npcAnimationNotifiers)
                notifier.StartNPCAttackAnimation(npc.Index);

            return npc.WithDirection(npcDirection);
        }

        private void HandleNPCTalk(IPacket packet)
        {
            var npc = GetNPCFromPacket(packet);
            if (npc == null)
                return;

            var messageLength = packet.ReadChar();
            var message = packet.ReadString(messageLength);

            var npcData = _enfFileProvider.ENFFile[npc.ID];

            var chatData = new ChatData(ChatTab.Local, npcData.Name, message, ChatIcon.Note);
            _chatRepository.AllChat[ChatTab.Local].Add(chatData);

            foreach (var notifier in _npcAnimationNotifiers)
                notifier.ShowNPCSpeechBubble(npc.Index, message);
        }

        private static NPC EnsureCorrectXAndY(NPC npc, byte destinationX, byte destinationY)
        {
            var opposite = npc.Direction.Opposite();
            var tempNPC = npc
                .WithDirection(opposite)
                .WithX(destinationX)
                .WithY(destinationY);
            return npc
                .WithX((byte)tempNPC.GetDestinationX())
                .WithY((byte)tempNPC.GetDestinationY());
        }
    }
}
