using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Maps.Tiled;
using MonoGame.Extended.Shapes;
using System;
using VippGame.Core.Interfaces;
using IDrawable = VippGame.Core.Interfaces.IDrawable;

namespace VippGame.Core.Managers
{
    public class WorldLoader : IObject, ILoadable, IInitializable, IDrawable
    {
        public ulong Id { get; }
        private Random _rand;
        private TiledMap _map;
        private Camera2D _camera;

        public WorldLoader(Camera2D camera, int tileSize = 16)
        {
            _camera = camera;
            _rand = new Random(DateTime.UtcNow.Millisecond);
        }

        public void Load(ContentManager contentManager)
        {
            _map = contentManager.Load<TiledMap>("Maps/test");
        }

        public void Initialize()
        {
            Visible = true;
        }

        public bool Visible { get; set; }
        public int DrawOrder { get; set; }
        public RectangleF Bounds => new RectangleF(0, 0, _map.Width, _map.Height);
        public void Draw(SpriteBatch spriteBatch)
        {
            _map.Draw(spriteBatch, _camera);
        }
    }
}