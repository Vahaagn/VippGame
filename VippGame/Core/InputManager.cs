using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Time = SFML.System.Time;

namespace VippGame.Core
{
    public class InputManager
    {
        private const float MAX_REST_DIFF = 1f;

        private bool _hasFirstClicked;
        private MouseState _mouseStartState;

        public InputManager()
        {
            Init();
        }

        private void Init()
        {

        }

        public void Update(Time gameTime)
        {
            HandleMouse(gameTime);
        }

        public void Draw()
        {
            if (_hasFirstClicked)
            {
                GL.Rotate(velocity.X, axisX, 0.0f, 0.0f);
                GL.Rotate(velocity.Y, 0.0f, axisY, 0.0f);
            }
        }

        private Vector3 velocity = Vector3.Zero;
        private float axisX = 0.0f;
        private float axisY = 0.0f;

        private void HandleMouse(Time gameTime)
        {
            MouseState state = Mouse.GetCursorState();

            if (state.IsButtonDown(MouseButton.Left))
            {
                if (!_hasFirstClicked)
                {
                    _hasFirstClicked = true;
                    _mouseStartState = state;
                }

                if (state != _mouseStartState)
                {
                    float diffX = state.Y - _mouseStartState.Y;
                    float diffY = state.X - _mouseStartState.X;

                    if (Math.Abs(diffX) > MAX_REST_DIFF)
                    {
                        axisX = Math.Max(diffX * 0.05f, 1.0f);
                        velocity.X = diffX * 0.5f;
                    }

                    if (Math.Abs(diffY) > MAX_REST_DIFF)
                    {
                        axisY = Math.Max(diffY * 0.05f, 1.0f);
                        velocity.Y = diffY * 0.5f;
                    }
                }
            }
            else
            {
                velocity = Vector3.Zero;
                axisX = 0.0f;
                axisY = 0.0f;
                _hasFirstClicked = false;
            }
        }
    }
}