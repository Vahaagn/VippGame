#region --- Header ---

// File: Player.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/05

#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using VippGame.Core.Interfaces;

namespace VippGame
{
    public class Player : IPlayer
    {
        #region --- IGameObject Members ---

        public ulong Id { get; }
        public Vector2 Position { get; set; }

        public Point Size
        {
            get { return new Point(Texture.Width, Texture.Height); }
            set { }
        }

        public Texture2D Texture { get; private set; }
        public Color Color { get; set; }
        public bool Visible { get; set; }
        public int DrawOrder { get; set; }

        public void Update(GameTime gameTime)
        {
            //throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position.ToPoint(), Size), Color);
        }

        public void Move(float xChange, float yChange)
        {
            Move(new Vector2(xChange, yChange));
        }

        public void Move(Vector2 changeVector)
        {
            Position += changeVector;
        }

        public void Initialize()
        {
            Visible = true;
        }

        public void Load(ContentManager contentManager)
        {
            Texture = contentManager.Load<Texture2D>("Player/player1");
        }

        #endregion
    }
}