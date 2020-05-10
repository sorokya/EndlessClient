﻿using System.Collections.Generic;
using AutomaticTypeMapper;
using EOLib.Domain.Character;
using EOLib.Domain.Login;
using EOLib.IO.Repositories;

namespace EOLib.Net.Translators
{
    [AutoMappedType]
    public class AccountLoginPacketTranslator : CharacterDisplayPacketTranslator<IAccountLoginData>
    {
        public AccountLoginPacketTranslator(IEIFFileProvider eifFileProvider)
            : base(eifFileProvider) { }

        public override IAccountLoginData TranslatePacket(IPacket packet)
        {
            var reply = (LoginReply) packet.ReadShort();

            var characters = new List<ICharacter>();
            if (reply == LoginReply.Ok)
                characters.AddRange(GetCharacters(packet));

            return new AccountLoginData(reply, characters);
        }
    }
}
