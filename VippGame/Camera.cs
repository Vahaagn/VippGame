using Microsoft.Xna.Framework;
using VippGame.Core.Interfaces;

namespace VippGame
{
    public class Camera : ICamera
    {
        #region --- Constants ---

        private const float MIN_ZOOM = 1f;
        private const float MAX_ZOOM = 5f;

        #endregion

        #region --- ICamera Members ---

        public ulong Id { get; }

        public Vector2 Position { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }

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
            else if (Zoom + cameraZoomChange > MAX_ZOOM)
            {
                Zoom = MAX_ZOOM;
            }
            else if (Zoom + cameraZoomChange < MIN_ZOOM)
            {
                Zoom = MIN_ZOOM;
            }
        }

        public void LookAt(IGameObject gameObject)
        {
            Position = gameObject.Position;
        }

        #endregion

        #region --- Public methods ---

        private bool CanZoom(float difference)
        {
            var newValue = Zoom + difference;

            return newValue >= MIN_ZOOM && newValue <= MAX_ZOOM;
        }

        #endregion
    }
}