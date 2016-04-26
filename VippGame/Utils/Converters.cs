using OpenTK;
using SFML.System;

namespace VippGame.Utils
{
    public static class Converters
    {
        public static Vector2f ToVector2F(this Vector2 vector2)
        {
            return new Vector2f(vector2.X, vector2.Y);
        }

        public static Vector2 ToVector2(this Vector2f vector2f)
        {
            return new Vector2(vector2f.X, vector2f.Y);
        }
    }
}