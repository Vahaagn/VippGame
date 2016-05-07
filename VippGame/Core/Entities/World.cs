#region --- Header ---

// File: World.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07

#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using VippGame.Core.Interfaces;
using IDrawable = VippGame.Core.Interfaces.IDrawable;

namespace VippGame.Core.Entities
{
    public class World : IObject, IDrawable, IUpdatable, IInitializable, ILoadable
    {
        #region --- IDrawable Members ---

        public bool Visible { get; set; }
        public int DrawOrder { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region --- IInitializable Members ---

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region --- ILoadable Members ---

        public void Load(ContentManager contentManager)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region --- IUpdatable Members ---

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        #endregion

        public ulong Id { get; }
    }
}