#region --- Header ---

// File: GameObject.cs
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
using VippGame.Core.Events;
using VippGame.Core.Handlers;
using VippGame.Core.Interfaces;
using VippGame.Core.Structs;

namespace VippGame.Core.Entities
{
    public abstract class GameObject : IGameObject
    {
        #region --- IGameObject Members ---

        public ulong Id { get; }
        public bool Visible { get; set; }
        public int DrawOrder { get; set; }
        public bool CanCollide { get; set; }
        public bool IsColliding { get; set; }
        public CollisionResult CollisionResult { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Origin => Position + Size.ToVector2() / 2f;
        public Point Size
        {
            get { return new Point(Texture.Width, Texture.Height); }
            set { }
        }

        public RectangleF Bounds => new RectangleF(Position, Size.ToVector2());
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }

        public virtual void Initialize()
        {
            Color = Color.White;
            Visible = true;
            CanCollide = true;
        }

        public virtual void Load(ContentManager contentManager)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position.ToPoint(), Size), Color);
        }

        public CollisionResult CheckCollision(ICollide collideObject)
        {
            var self = (ICollide)this;
            var collisionHandler = new CollisionHandler();

            var result = collisionHandler.CheckCollisions(self, collideObject);
            bool collisionDetected = result.Left | result.Right | result.Up | result.Down;

            if (collisionDetected)
            {
                IsColliding = true;
                CollisionResult = result;
                Colliding?.Invoke(this, new CollideEventArgs(result, collideObject));
            }
            else
            {
                IsColliding = false;
                CollisionResult = new CollisionResult();
            }

            return result;
        }

        public event EventHandler<CollideEventArgs> Colliding;

        #endregion
    }
}