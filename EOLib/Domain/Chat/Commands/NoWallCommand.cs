﻿using AutomaticTypeMapper;
using EOLib.Domain.Character;

namespace EOLib.Domain.Chat.Commands
{
    [AutoMappedType]
    public class NoWallCommand : IPlayerCommand
    {
        private readonly ICharacterRepository _characterRepository;

        public string CommandText => "nowall";

        public NoWallCommand(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public bool Execute(string parameter)
        {
            if (_characterRepository.MainCharacter.AdminLevel == AdminLevel.Player)
                return false;

            var newNoWall = !_characterRepository.MainCharacter.NoWall;
            var newCharacter = _characterRepository.MainCharacter.WithNoWall(newNoWall);
            _characterRepository.MainCharacter = newCharacter;

            return true;
        }
    }
}
