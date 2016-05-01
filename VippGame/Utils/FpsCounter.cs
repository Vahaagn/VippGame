using SFML.Graphics;
using SFML.System;
﻿using System.Drawing;
using OpenTK.Graphics;
using VippGame.Core;
using VippGame.GLObjects;
using Color = SFML.Graphics.Color;
using Font = SFML.Graphics.Font;

namespace VippGame.Utils
{
    public class FpsCounter
    {
        private const string FORMAT = "FPS: {0}";

        private int _fps;
        private readonly Text _fpsText;
        private float _elapsedTime;
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
    }
}