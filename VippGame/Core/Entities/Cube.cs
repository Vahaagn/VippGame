#region --- Header ---
// File: Cube.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VippGame.Core.Entities
{
    public class Cube : GameObject
    {
        public Cube(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public override void Load(ContentManager contentManager)
        {
            Texture = contentManager.Load<Texture2D>("Textures/cube");
        }
    }
}