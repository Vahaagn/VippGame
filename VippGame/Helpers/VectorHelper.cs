#region --- Header ---
// File: VectorHelper.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/05
#endregion

using Microsoft.Xna.Framework;

namespace VippGame.Helpers
{
    public static class VectorHelper
    {
        public static Vector3 ToVector3(this Vector2 vector2, float valueZ = 0f)
        {
            return new Vector3(vector2, valueZ);
        }
    }
}