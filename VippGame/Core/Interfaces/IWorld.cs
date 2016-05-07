#region --- Header ---
// File: IWorld.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using Microsoft.Xna.Framework;

namespace VippGame.Core.Interfaces
{
    public interface IWorld : IObject, IUpdatable, IDrawable, IInitializable, ILoadable
    {
        Vector2 Position { get; set; }
        Point Size { get; set; }
    }
}