﻿using AutomaticTypeMapper;

namespace EOLib.Domain.Login
{
    public interface IPlayerInfoRepository
    {
        string LoggedInAccountName { get; set; }

        string PlayerPassword { get; set; }

        short PlayerID { get; set; }

        short SessionID { get; set; }

        bool IsFirstTimePlayer { get; set; }

        bool PlayerIsInGame { get; set; }
    }

    public interface IPlayerInfoProvider
    {
        string LoggedInAccountName { get; }

        string PlayerPassword { get; }

        short PlayerID { get; }

        short SessionID { get; set; }

        bool IsFirstTimePlayer { get; }

        bool PlayerIsInGame { get; }
    }

    [AutoMappedType(IsSingleton = true)]
    public sealed class PlayerInfoRepository : IPlayerInfoRepository, IPlayerInfoProvider, IResettable
    {
        public string LoggedInAccountName { get; set; }

        public string PlayerPassword { get; set; }

        public short PlayerID { get; set; }

        public short SessionID { get; set; }

        public bool IsFirstTimePlayer { get; set; }

        public bool PlayerIsInGame { get; set; }

        public void ResetState()
        {
            LoggedInAccountName = "";
            PlayerPassword = "";
            PlayerID = 0;
            SessionID = 0;
            IsFirstTimePlayer = false;
            PlayerIsInGame = false;
        }
    }
}
