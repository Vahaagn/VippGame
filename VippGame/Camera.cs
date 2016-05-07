using Microsoft.Xna.Framework;
using VippGame.Core.Interfaces;
using VippGame.Helpers;

namespace VippGame
{
    public class Camera
    {
        public Vector3 Position { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }
        public float MinZoom = 1f;
        public float MaxZoom = 5f;

        public Matrix TranslationMatrix
        {
            get
            {
                var f = Matrix.CreateTranslation(-Position.X, -Position.Y, 0);
                var g = Matrix.CreateRotationZ(Rotation);
                var h = Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
                var i = Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0));

                return f * g * h * i;
            }
        }

        public void ChangeZoom(float difference)
        {
            var cameraZoomChange = difference / 1000f;
            if (CanZoom(cameraZoomChange))
            {
                Zoom += cameraZoomChange;
            }
            else if (Zoom + cameraZoomChange > MaxZoom)
            {
                Zoom = MaxZoom;
            }
            else if (Zoom + cameraZoomChange < MinZoom)
            {
                Zoom = MinZoom;
            }
        }

        public bool CanZoom(float difference)
        {
            var newValue = Zoom + difference;

            return newValue >= MinZoom && newValue <= MaxZoom;
        }

        public void LookAt(IGameObject gameObject)
        {
            Position = gameObject.Position.ToVector3();
        }
    }
}