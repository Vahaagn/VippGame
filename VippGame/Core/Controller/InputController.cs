using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using VippGame.Core.Entities;

namespace VippGame.Core.Controller
{
    public class InputController
    {
        private GameWindow _gameWindow;
        private Camera2D _camera;
        private Player _player;
        private int _lastWheelValue;
        private const float SPEED = 2f;

        public InputController(GameWindow gameWindow)
        {
            _gameWindow = gameWindow;
        }

        public InputController(GameWindow gameWindow, Camera2D camera, Player player)
        {
            _gameWindow = gameWindow;
            _camera = camera;
            _player = player;
        }

        public void Update()
        {
            MouseUpdate();
            KeyboardUpdate();
        }

        private void MouseUpdate()
        {
            var state = Mouse.GetState(_gameWindow);

            WheelUpdate(ref state);
        }

        private void KeyboardUpdate()
        {
            var state = Keyboard.GetState();

            foreach (var pressedKey in state.GetPressedKeys())
            {
                switch (pressedKey)
                {
                    case Keys.A:
                        _player.Move(-SPEED, 0);
                        break;
                    case Keys.D:
                        _player.Move(SPEED, 0);
                        break;
                    case Keys.W:
                        _player.Move(0, -SPEED);
                        break;
                    case Keys.S:
                        _player.Move(0, SPEED);
                        break;
                }
            }

            if (state.IsKeyDown(Keys.Back))
            {
                _player.Position = new Vector2(200, 200);
            }

            if (state.IsKeyDown(Keys.Q))
            {
                _camera.Rotation = MathHelper.ToRadians(-2f);
            }
            else if (state.IsKeyDown(Keys.E))
            {
                _camera.Rotation = MathHelper.ToRadians(2f);
            }
            else
            {
                _camera.Rotation = 0f;
            }
        }

        private void WheelUpdate(ref MouseState state)
        {
            var wheelChange = state.ScrollWheelValue - _lastWheelValue;
            if (wheelChange != 0)
            {
                if (wheelChange > 0) _camera.ZoomIn(1f);
                else _camera.ZoomOut(1f);

                _lastWheelValue = state.ScrollWheelValue;
            }
        }
    }
}