#region --- Header ---
// File: CollisionResult.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion
namespace VippGame.Core.Structs
{
    public struct CollisionResult
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }

        public static CollisionResult Empty => new CollisionResult();

        public static CollisionResult operator |(CollisionResult left, CollisionResult right)
        {
            var newResult = left;

            newResult.Left = left.Left | right.Left;
            newResult.Right = left.Right | right.Right;
            newResult.Up = left.Up | right.Up;
            newResult.Down = left.Down | right.Down;

            return newResult;
        }
    }
}