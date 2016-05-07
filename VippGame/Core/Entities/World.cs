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
using MonoGame.Extended.Shapes;
using System;
using System.Collections.Generic;
using VippGame.Core.Interfaces;

namespace VippGame.Core.Entities
{
    public class World : IWorld
    {
        #region --- IWorld Members ---

        public ulong Id { get; }
        public Vector2 Position { get; set; }
        public Point Size { get; set; }
        public RectangleF Bounds => new RectangleF(Position, Size.ToVector2());
        public bool Visible { get; set; }
        public int DrawOrder { get; set; }

        private List<IGameObject> _gameObjects;

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Load(ContentManager contentManager)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}