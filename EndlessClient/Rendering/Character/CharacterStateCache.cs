﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using System.Collections.Generic;
using EOLib;
using EOLib.Domain.Character;

namespace EndlessClient.Rendering.Character
{
    public class CharacterStateCache : ICharacterStateCache
    {
        public Optional<ICharacterRenderProperties> ActiveCharacterRenderProperties { get; private set; }

        private readonly Dictionary<int, ICharacterRenderProperties> _characterRenderProperties;

        public IReadOnlyDictionary<int, ICharacterRenderProperties> CharacterRenderProperties
        {
            get { return _characterRenderProperties; }
        }

        public CharacterStateCache()
        {
            ActiveCharacterRenderProperties = new Optional<ICharacterRenderProperties>();
            _characterRenderProperties = new Dictionary<int, ICharacterRenderProperties>();
        }

        public bool HasCharacterWithID(int id)
        {
            return _characterRenderProperties.ContainsKey(id);
        }

        public void UpdateActiveCharacterState(ICharacterRenderProperties newActiveCharacterState)
        {
            ActiveCharacterRenderProperties = new Optional<ICharacterRenderProperties>(newActiveCharacterState);
        }

        public void UpdateCharacterState(int id, ICharacterRenderProperties newCharacterState)
        {
            if (!HasCharacterWithID(id))
                _characterRenderProperties.Add(id, null);

            _characterRenderProperties[id] = newCharacterState;
        }

        public void RemoveCharacterState(int id)
        {
            _characterRenderProperties.Remove(id);
        }

        public void ClearAll()
        {
            ActiveCharacterRenderProperties = null;
            _characterRenderProperties.Clear();
        }
    }
}