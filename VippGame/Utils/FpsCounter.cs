using SFML.Graphics;
using SFML.System;
using VippGame.Core;

namespace VippGame.Utils
{
    public class FpsCounter
    {
        private int _fps;
        private Text _fpsText;
        private readonly Clock _loopClock;
        private TextGL _textGl;

        public FpsCounter(Font font, uint size = 12, Color? color = null, Text.Styles? styles = null)
        {
            _textGl = new TextGL();
            _fpsText = new Text();

            _fpsText.Font = font;
            _fpsText.CharacterSize = size;
            _fpsText.Color = color ?? Color.Magenta;
            _fpsText.Style = styles ?? Text.Styles.Regular;
            _fpsText.Position = new Vector2f(0, 0);

            _loopClock = new Clock();
        }

        public void Draw()
        {
            _textGl.Draw();
        }

        public void Draw(RenderWindow renderWindow)
        {
            //renderWindow.Draw(_fpsText);
        }

        public void Update()
        {
            var elapsedTime = _loopClock.ElapsedTime.AsMilliseconds();

            if (elapsedTime < 1000)
            {
                ++_fps;
                return;
            }

            _fpsText.DisplayedString = "FPS: " + _fps;
            _fps = 0;
            _loopClock.Restart();
        }
    }
}