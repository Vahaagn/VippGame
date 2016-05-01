using System.Drawing;
using OpenTK.Graphics;
using VippGame.Core;
using VippGame.GLObjects;

namespace VippGame.Utils
{
    public class FpsCounter
    {
        private const string FORMAT = "FPS: {0}";

        private int _fps;
        private float _elapsedTime;
        private readonly Color4 _color;
        private readonly GlText _textGl;

        public FpsCounter(uint size = 12, Color4? color = null)
        {
            _color = color ?? Color4.Magenta;
            _textGl = new GlText();
        }

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

            string text = string.Format(FORMAT, _fps);
            _textGl.UpdateText(text);
            _fps = 0;
            _elapsedTime = 0;
        }

        public void UpdateWindowSize(Size size)
        {
            _textGl.ClientSize = size;
        }
    }
}