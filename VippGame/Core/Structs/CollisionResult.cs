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
    }
}