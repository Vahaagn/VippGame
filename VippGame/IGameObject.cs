#region --- Header ---
// File: IGameObject.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/05
#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VippGame
{
    public interface IGameObject
    {
        Vector2 Position { get; set; }
        Point Size { get; }
        Texture2D Texture { get; set; }
        Color Color { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}