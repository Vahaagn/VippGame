#region --- Header ---
// File: CollisionHandler.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using System;
using VippGame.Core.Interfaces;
using VippGame.Core.Structs;

namespace VippGame.Core.Handlers
{
    public class CollisionHandler
    {
        private const float COLLISION_TOLERANCE = 1f;

        public void CheckCollisions(ICollide main, ICollide other)
        {
            var result = CollisionResult.Empty;

            DoHorizontalChecks(main, other, ref result);
            DoVerticalChecks(main, other, ref result);

            UpdateCollisionInformation(main, other, ref result);
        }

        private void DoHorizontalChecks(ICollide main, ICollide other, ref CollisionResult result)
        {
            bool canCollideVertically =
                (main.Position.Y < other.Position.Y &&
                 main.Position.Y + main.Size.Y > other.Position.Y) ||
                (main.Position.Y > other.Position.Y &&
                 main.Position.Y < other.Position.Y + other.Size.Y);

            if (!canCollideVertically) return;

            if (Math.Abs(main.Position.X - other.Position.X) <= COLLISION_TOLERANCE)
            {
                result.Left = true;
            }
            else if (main.Position.X > other.Position.X)
            {
                result.Left = Math.Abs(main.Position.X - (other.Position.X + other.Size.X)) <= COLLISION_TOLERANCE;
            }
            else
            {
                result.Right = Math.Abs((main.Position.X + main.Size.X) - other.Position.X) <= COLLISION_TOLERANCE;
            }
        }

        private void DoVerticalChecks(ICollide main, ICollide other, ref CollisionResult result)
        {
            bool canCollideHorizontaly =
                (main.Position.X < other.Position.X &&
                 main.Position.X + main.Size.X > other.Position.X) ||
                (main.Position.X > other.Position.X &&
                 main.Position.X < other.Position.X + other.Size.X);

            if (!canCollideHorizontaly) return;

            if (Math.Abs(main.Position.Y - other.Position.Y) <= COLLISION_TOLERANCE)
            {
                result.Up = true;
            }
            else if (main.Position.Y > other.Position.Y)
            {
                result.Up = Math.Abs(main.Position.Y - (other.Position.Y + other.Size.Y)) <= COLLISION_TOLERANCE;
            }
            else
            {
                result.Down = Math.Abs((main.Position.Y + main.Size.Y) - other.Position.Y) <= COLLISION_TOLERANCE;
            }
        }

        private void UpdateCollisionInformation(ICollide main, ICollide other, ref CollisionResult result)
        {
            if (CheckCollisionResult(ref result))
            {
                main.IsColliding = true;
                other.IsColliding = true;

                main.CollisionResult |= result;
                other.CollisionResult |= InvertCollisionResult(ref result);
            }
        }

        public bool CheckCollisionResult(ref CollisionResult result)
        {
            bool collisionDetected = result.Left | result.Right | result.Up | result.Down;

            return collisionDetected;
        }

        private CollisionResult InvertCollisionResult(ref CollisionResult result)
        {
            var inverted = new CollisionResult();

            if (result.Left) inverted.Right = true;
            if (result.Right) inverted.Left = true;
            if (result.Up) inverted.Down = true;
            if (result.Down) inverted.Up = true;

            return inverted;
        }
    }
}