﻿using System.Linq;

namespace EOBot
{
    public enum ArgsError
    {
        NoError,
        BadFormat,
        WrongNumberOfArgs,
        InvalidPort,
        InvalidNumberOfBots,
        TooManyBots,
        NotEnoughBots,
        InvalidSimultaneousNumberOfBots,
        InvalidWaitFlag,
        InvalidInitDelay
    }

    public class ArgumentsParser
    {
        public ArgsError Error { get; private set; }

        public string Host { get; private set; }
        public ushort Port { get; private set; }

        public int NumBots { get; private set; }
        public int SimultaneousBots { get; private set; }

        public int InitDelay { get; private set; }

        public string Account { get; private set; }
        public string Password { get; private set; }
        public string Character { get; private set; }

        public ArgumentsParser(string[] args)
        {
            InitDelay = 1100;

            Error = ArgsError.NoError;

            if (args.Length < 5)
            {
                Error = ArgsError.WrongNumberOfArgs;
                return;
            }

            foreach (var arg in args)
            {
                var pair = arg.ToLower().Split('=');

                if (pair.Length != 2)
                {
                    Error = ArgsError.BadFormat;
                    return;
                }

                switch (pair[0])
                {
                    case "host":
                        ParseHost(pair[1]);
                        break;
                    case "port":
                        if (!ParsePort(pair[1]))
                            return;
                        break;
                    case "bots":
                        if (!ParseNumBots(pair))
                            return;
                        break;
                    case "initdelay":
                        if (!ParseInitDelay(pair[1]))
                            return;
                        break;
                    case "account":
                        Account = pair[1];
                        break;
                    case "password":
                        Password = pair[1];
                        break;
                    case "character":
                        Character = pair[1];
                        break;
                    default:
                        Error = ArgsError.BadFormat;
                        return;
                }
            }
        }

        private void ParseHost(string hostStr)
        {
            Host = hostStr;
        }

        private bool ParsePort(string portStr)
        {
            ushort port;
            if (!ushort.TryParse(portStr, out port))
            {
                Error = ArgsError.InvalidPort;
                return false;
            }
            Port = port;
            return true;
        }

        private bool ParseNumBots(string[] pair)
        {
            var both = pair[1].Split(',');

            if (both.Length < 1 || both.Length > 2)
            {
                Error = ArgsError.BadFormat;
                return false;
            }

            bool needSimul = both.Length == 2;

            int numBots, simul = -1;
            if (!int.TryParse(both[0], out numBots))
            {
                Error = ArgsError.InvalidNumberOfBots;
                return false;
            }
            if (needSimul && !int.TryParse(both[1], out simul))
            {
                Error = ArgsError.InvalidSimultaneousNumberOfBots;
                return false;
            }
            if (numBots > BotFramework.NUM_BOTS_MAX || (needSimul && (simul > BotFramework.NUM_BOTS_MAX || simul > numBots)))
            {
                Error = ArgsError.TooManyBots;
                return false;
            }
            if (numBots < 1 || (needSimul && simul < 1))
            {
                Error = ArgsError.NotEnoughBots;
                return false;
            }

            NumBots = numBots;
            SimultaneousBots = needSimul ? simul : numBots;
            return true;
        }

        private bool ParseInitDelay(string initDelay)
        {
            int delay;
            if (!int.TryParse(initDelay, out delay) || delay < 1100)
            {
                Error = ArgsError.InvalidInitDelay;
                return false;
            }

            InitDelay = delay;

            return true;
        }
    }
}
