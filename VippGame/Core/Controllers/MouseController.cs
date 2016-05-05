#region --- Header ---
// File: MouseController.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/03
#endregion

using OpenTK;
using OpenTK.Input;
using System;

namespace VippGame.Core
{
    public class MouseController
    {
        private const float MAX_REST_DIFF = 0f;

        private bool _hasFirstClicked;
        private MouseState _mouseStartState;
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

        public event EventHandler<MouseButtonEventArgs> MouseButtonDown;
        public event EventHandler<MouseMoveEventArgs> MouseMove;
    }
}