﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using EOLib.Data.BLL;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EndlessClient.Rendering.CharacterProperties
{
	public class ShieldRenderer : ICharacterPropertyRenderer
	{
		private readonly SpriteBatch _spriteBatch;
		private readonly ICharacterRenderProperties _renderProperties;
		private readonly Texture2D _shieldTexture;

		public ShieldRenderer(SpriteBatch spriteBatch, ICharacterRenderProperties renderProperties, Texture2D shieldTexture)
		{
			_spriteBatch = spriteBatch;
			_renderProperties = renderProperties;
			_shieldTexture = shieldTexture;
		}

		public void Render(Rectangle parentCharacterDrawArea)
		{
			throw new System.NotImplementedException();
		}
	}
}