using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VippGame
{
    public class InputController
    {
        private GameWindow _gameWindow;
        private Camera _camera;
        private Player _player;
        private int _lastWheelValue;

        public InputController(GameWindow gameWindow, Camera camera, Player player)
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
                        _player.Position = new Vector2(_player.Position.X - 1, _player.Position.Y);
                        break;
                    case Keys.D:
                        _player.Position = new Vector2(_player.Position.X + 1, _player.Position.Y);
                        break;
                    case Keys.W:
                        _player.Position = new Vector2(_player.Position.X, _player.Position.Y - 1);
                        break;
                    case Keys.S:
                        _player.Position = new Vector2(_player.Position.X, _player.Position.Y + 1);
                        break;
                }
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
                _camera.ChangeZoom(wheelChange);
                _lastWheelValue = state.ScrollWheelValue;
            }
        }
    }
}