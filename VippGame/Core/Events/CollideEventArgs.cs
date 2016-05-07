#region --- Header ---
// File: CollideEventArgs.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using System;
using VippGame.Core.Interfaces;
using VippGame.Core.Structs;

namespace VippGame.Core.Events
{
    public class CollideEventArgs : EventArgs
    {
        public CollideEventArgs(CollisionResult result, ICollide @object)
        {
            Result = result;
            CollisionObject = @object;
        }

        public CollisionResult Result { get; }
        public ICollide CollisionObject { get; }
    }
}