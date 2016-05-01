using OpenTK;
using OpenTK.Graphics;
using VippGame.Core;

namespace VippGame.Shapes
{
    public class Cube
    {
        private readonly Plane[] _planes;

        public Cube()
        {
            _planes = new Plane[4];

            Init();
        }

        public void Draw()
        {
            foreach (var plane in _planes)
            {
                plane.Draw();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var plane in _planes)
            {
                plane.Update(gameTime);
            }
        }

        private void Init()
        {
            for (int i = 0; i < _planes.Length; i++)
            {
                _planes[i] = new Plane(Color4.Aqua);
            }

            _planes[0].Angle = 90F;
            _planes[0].Rotation = new Vector3(1, 0, 0);
            _planes[0].Color = Color4.Aqua;

            _planes[1].Angle = 90F;
            _planes[1].Rotation = new Vector3(0, -1, 0);
            _planes[1].Color = Color4.Magenta;

            _planes[2].Angle = 180F;
            _planes[2].Rotation = new Vector3(0, 1, 0);
            _planes[2].Color = Color4.Green;

            _planes[3].Angle = 90F;
            _planes[3].Rotation = new Vector3(0, 0, 1);
            _planes[3].Color = Color4.Blue;
        }
    }
}