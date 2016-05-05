using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace VippGame
{
    public class InputController
    {
        private GameWindow _gameWindow;
        private Camera _camera;
        private int _lastWheelValue;

        public InputController(GameWindow gameWindow, Camera camera)
        {
            _gameWindow = gameWindow;
            _camera = camera;
        }

        public void Update()
        {
            var state = Mouse.GetState(_gameWindow);

            var wheelChange = state.ScrollWheelValue - _lastWheelValue;
            if (wheelChange != 0)
            {
                _camera.ChangeZoom(wheelChange);
                _lastWheelValue = state.ScrollWheelValue;
            }
        }
    }
}