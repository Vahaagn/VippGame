using SFML.Graphics;
using SFML.System;
using VippGame.GLObjects;
using Color = SFML.Graphics.Color;
using Font = SFML.Graphics.Font;

namespace VippGame.Utils
{
    public class FpsCounter
    {
        private int _fps;
        private readonly Text _fpsText;
        private readonly Clock _loopClock;
        private readonly GlText _textGl;

        public FpsCounter(Font font, uint size = 12, Color? color = null, Text.Styles? styles = null)
        {
            _textGl = new GlText();
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
            _textGl.UpdateText(_fpsText.DisplayedString);
            _fps = 0;
            _loopClock.Restart();
        }
    }
}