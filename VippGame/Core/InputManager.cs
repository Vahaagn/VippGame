using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

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

        public void Update(GameTime gameTime)
        {
            HandleMouse(gameTime);
        }

        public void Draw(Camera camera)
        {
            if (_hasFirstClicked)
            {
                camera.Rotate(_velocity);
            }

            camera.Zoom = _wheelPower;
        }

        private Vector3 _velocity = Vector3.Zero;
        private float _wheelPower = 1.0f;
        private int _lastWheelValue = 0;
        private float _maxWheelValue = 25.0f;
        private float _wheelChange = 0.0f;

        private void HandleMouse(GameTime gameTime)
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
                        _velocity.X = diffX * 0.5f;
                    }

                    if (Math.Abs(diffY) > MAX_REST_DIFF)
                    {
                        _velocity.Y = diffY * 0.5f;
                    }
                }
            }
            
            if (state.Wheel != _lastWheelValue)
            {
                var change = _wheelChange + state.Wheel - _lastWheelValue;
                _lastWheelValue = state.Wheel;

                if (Math.Abs(change) >= _maxWheelValue)
                {
                    return;
                }

                _wheelChange = change;

                float addWheelValue = 1.0f;

                if (_wheelChange > 0)
                {
                    addWheelValue -= Math.Min(1.0f, _wheelChange / _maxWheelValue);
                }
                else if (_wheelChange < 0)
                {
                    addWheelValue -= Math.Max(-1.0f, _wheelChange / _maxWheelValue);
                }

                _wheelPower = addWheelValue;
            }
        }
    }
}