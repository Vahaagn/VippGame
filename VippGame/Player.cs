#region --- Header ---
// File: Player.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/05
#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VippGame
{
    public class Player : IGameObject
    {
        public Vector2 Position { get; set; }
        public Point Size => new Point(Texture.Width, Texture.Height);
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }

        public Player()
        {

        }

        public void Update(GameTime gameTime)
        {
            //throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position.ToPoint(), Size), Color);
        }
    }
}