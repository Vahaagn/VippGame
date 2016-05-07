using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VippGame.Core.Interfaces;

namespace VippGame.Core.Entities
{
    public class CameraOld : ICamera, IInitializable
    {
        #region --- Constants ---

        private const float MIN_ZOOM = 1f;
        private const float MAX_ZOOM = 5f;

        #endregion

        #region --- Properties ---

        public Viewport ViewPort { get; set; }

        #endregion

        #region --- ICamera Members ---

        public ulong Id { get; }

        public Vector2 Position { get; set; }
        public Rectangle Bounds => new Rectangle(Position.ToPoint(), new Point(ViewPort.Width, ViewPort.Height));
        public float Zoom { get; set; }
        public float Rotation { get; set; }

        public Matrix TranslationMatrix
        {
            get
            {
                var f = Matrix.CreateTranslation(-ViewPort.Width * 0.5f, -ViewPort.Height * 0.5f, 0);
                var g = Matrix.CreateRotationZ(Rotation);
                var h = Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
                var i = Matrix.CreateTranslation(new Vector3(ViewPort.Width * 0.5f, ViewPort.Height * 0.5f, 0));

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

        // TODO: Check if I really need this

        public void LookAt(IGameObject gameObject)
        {
            Position = gameObject.Position - new Vector2(ViewPort.Width * 0.5f, ViewPort.Height * 0.5f);
        }

        #endregion

        #region --- IInitializable Members ---

        public void Initialize()
        {
            Position = Vector2.Zero;
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