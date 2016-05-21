#region --- Header ---
// File: ICollide.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using Microsoft.Xna.Framework;
using MonoGame.Extended.Shapes;
using System;
using VippGame.Core.Events;
using VippGame.Core.Structs;

namespace VippGame.Core.Interfaces
{
    public interface ICollide
    {
        bool CanCollide { get; set; }
        bool isCheckable { get; set; }
        bool IsColliding { get; set; }
        CollisionResult CollisionResult { get; set; }
        Vector2 Position { get; }
        Point Size { get; }
        RectangleF CollisionBoundary { get; }

        void CheckCollision(ICollide collideObject);

        event EventHandler<CollideEventArgs> Colliding;
    }
}