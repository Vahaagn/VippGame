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
using System.Diagnostics;
using VippGame.Core.Events;
using VippGame.Core.Interfaces;
using VippGame.Core.Structs;

namespace VippGame.Core.Entities
{
    public class Player : GameObject, IPlayer
    {
        #region --- IPlayer Members ---

        public override void Load(ContentManager contentManager)
        {
            Texture = contentManager.Load<Texture2D>("Player/player1");
            Position = Position - Size.ToVector2() * 0.5f;
        }

        public override void Initialize()
        {
            base.Initialize();

            isCheckable = true;

            Colliding += OnColliding;
        }

        private void OnColliding(object sender, CollideEventArgs collideEventArgs)
        {
            var side = "|";
            if (collideEventArgs.Result.Left) side += "Left|";
            if (collideEventArgs.Result.Right) side += "Right|";
            if (collideEventArgs.Result.Up) side += "Up|";
            if (collideEventArgs.Result.Down) side += "Down|";

            Debug.WriteLine($"Player collide detected with {collideEventArgs.CollisionObject.GetType().Name} on {side} side");
        }

        #endregion

        #region --- Public methods ---

        public void Move(float xChange, float yChange)
        {
            Move(new Vector2(xChange, yChange));
        }

        public void Move(Vector2 changeVector)
        {
            if (!IsColliding)
            {
                Position += changeVector;
                return;
            }

            float moveX = changeVector.X;
            float moveY = changeVector.Y;

            if (CollisionResult.Left && moveX < 0)
            {
                moveX = 0;
            }
            if (CollisionResult.Right && moveX > 0)
            {
                moveX = 0;
            }
            if (CollisionResult.Up && moveY < 0)
            {
                moveY = 0;
            }
            if (CollisionResult.Down && moveY > 0)
            {
                moveY = 0;
            }

            Position += new Vector2(moveX, moveY);
        }

        #endregion
    }
}