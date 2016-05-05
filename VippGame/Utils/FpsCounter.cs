using OpenTK.Graphics;
using System.Drawing;
using VippGame.Core;
using VippGame.Core.Interfaces;
using VippGame.GLObjects;

namespace VippGame.Utils
{
    public class FpsCounter : IGameObject
    {
        #region --- Constants ---

        private const string FORMAT = "FPS: {0}";

        #endregion

        #region --- Fields ---

        private readonly Color4 _color;
        private readonly GlText _textGl;
        private float _elapsedTime;

        private int _fps;

        #endregion

        #region --- Constructors ---

        public FpsCounter(uint size = 12, Color4? color = null)
        {
            _color = color ?? Color4.Magenta;
            _textGl = new GlText();
        }

        #endregion

        #region --- IGameObject Members ---

        public void Draw()
        {
            _textGl.Draw();
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTime += (float)gameTime.ElapsedTime.TotalMilliseconds;

            if (_elapsedTime < 1000)
            {
                ++_fps;
                return;
            }

            var text = string.Format(FORMAT, _fps);
            _textGl.UpdateText(text);
            _fps = 0;
            _elapsedTime = 0;
        }

        public int Id { get; }

        #endregion

        #region --- Public methods ---

        public void UpdateWindowSize(Size size)
        {
            _textGl.ClientSize = size;
        }

        #endregion
    }
}