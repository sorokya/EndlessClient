﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using EOLib.Domain.Chat;
using EOLib.Domain.Login;
using EOLib.Localization;
using EOLib.Net;

namespace EOLib.PacketHandlers
{
    public class FindCommandPlayerSameMapHandler : FindCommandHandlerBase
    {
        public override PacketAction Action
        {
            get { return PacketAction.Pong; }
        }

        protected override EOResourceID ResourceIDForResponse
        {
            get { return EOResourceID.STATUS_LABEL_IS_ONLINE_SAME_MAP; }
        }

        public FindCommandPlayerSameMapHandler(IChatRepository chatRespository,
                                               ILocalizedStringService localizedStringService,
                                               IPlayerInfoProvider playerInfoProvider)
            : base(chatRespository, localizedStringService, playerInfoProvider)
        {
        }
    }
}