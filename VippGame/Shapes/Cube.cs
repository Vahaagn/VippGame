using OpenTK;
using OpenTK.Graphics;
using VippGame.Core;
using VippGame.Core.Interfaces;

namespace VippGame.Shapes
{
    public class Cube : IGameObject
    {
        #region --- Fields ---

        private readonly Plane[] _planes;

        #endregion

        #region --- Properties ---

        public float Size { get; set; }
        #endregion

        #region --- Constructors ---

        public Cube(float size = 50f)
        {
            Id = IdentifierProvider.GetAvailableId();

            Size = size;

            _planes = new Plane[6];

            Init();
        }

        #endregion

        #region --- IGameObject Members ---

        public int Id { get; }

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

        #endregion

        #region --- Public methods ---

        private void Init()
        {
            _planes[0] = new Plane(Color4.Aqua, "test1.jpg", Size)
            {
                Angle = 90F,
                Rotation = new Vector3(1, 0, 0),
                Color = Color4.Aqua
            };

            _planes[1] = new Plane(Color4.Aqua, "test2.jpg", Size)
            {
                Angle = 90F,
                Rotation = new Vector3(0, -1, 0),
                Color = Color4.Magenta
            };

            _planes[2] = new Plane(Color4.Aqua, "test3.jpg", Size)
            {
                Angle = 180F,
                Rotation = new Vector3(0, 1, 0),
                Color = Color4.Green
            };

            _planes[3] = new Plane(Color4.Aqua, "test4.jpg", Size)
            {
                Angle = 90F,
                Rotation = new Vector3(0, 0, 1),
                Color = Color4.Blue
            };

            _planes[4] = new Plane(Color4.Aqua, "test5.jpg", Size)
            {
                Angle = 90F,
                Rotation = new Vector3(-1, 0, 0),
                Color = Color4.Blue
            };

            _planes[5] = new Plane(Color4.Aqua, "test6.jpg", Size)
            {
                Angle = 90F,
                Rotation = new Vector3(0, 1, 0),
                Color = Color4.Blue
            };
        }

        #endregion
    }
}