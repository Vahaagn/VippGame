#region --- Header ---
// File: IWorld.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Shapes;

namespace VippGame.Core.Interfaces
{
    public interface IWorld : IObject, IInitializable, ILoadable //, IUpdatable
    {
        //Vector2 Position { get; set; }
        //Point Size { get; set; }

        void Draw(SpriteBatch spriteBatch, RectangleF viewport);
    }
}