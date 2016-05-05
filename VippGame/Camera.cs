using Microsoft.Xna.Framework;

namespace VippGame
{
    public class Camera
    {
        public Vector3 Position { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }

        public Matrix TranslationMatrix
        {
            get
            {
                var f = Matrix.CreateTranslation(-(int)Position.X, -(int)Position.Y, 0);
                var g = Matrix.CreateRotationZ(Rotation);
                var h = Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
                var i = Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0));

                return f * g * h * i;
            }
        }
    }
}