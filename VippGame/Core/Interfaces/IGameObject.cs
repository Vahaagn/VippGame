#region --- Header ---
// File: IGameObject.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VippGame.Core.Interfaces
{
    public interface IGameObject : IObject, IUpdatable, IDrawable, IInitializable, ILoadable
    {
        Vector2 Position { get; set; }
        Point Size { get; set; }
        Texture2D Texture { get; }
        Color Color { get; set; }
    }
}