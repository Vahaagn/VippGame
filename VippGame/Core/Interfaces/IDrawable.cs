#region --- Header ---
// File: IDrawable.cs
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
    public interface IDrawable
    {
        bool Visible { get; set; }
        int DrawOrder { get; set; }
        RectangleF Bounds { get; }

        void Draw(SpriteBatch spriteBatch);
    }
}