using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using TiledSharp;
using VippGame.Core.Interfaces;

namespace VippGame.Core.Managers
{
    public class TilesInfo
    {
        public Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
        public int Width;
        public int Height;
        public int TilesInWidth;
        public int TilesInHeight;
    }

    public class WorldLoader : IWorld
    {
        public ulong Id { get; }
        private Random _rand;

        private TmxMap _map;
        private TilesInfo _tiles;
        public bool Visible { get; set; }
        public int DrawOrder { get; set; }
        public RectangleF Bounds => new RectangleF(0, 0, _map.Width, _map.Height);

        public WorldLoader(string mapName, int tileSize = 16)
        {
            _rand = new Random(DateTime.UtcNow.Millisecond);

            LoadMap(mapName);
        }

        public void Load(ContentManager contentManager)
        {
            foreach (var tileset in _map.Tilesets)
            {
                var texture = contentManager.Load<Texture2D>($@"Maps\{tileset.Name}");
                _tiles.Textures.Add(tileset.Name, texture);

                //foreach (var tile in tileset.Tiles)
                //{
                //    var name = tile.Image.Source.Replace("Content\\Maps\\Tiles/", "").Replace(".png", "");
                //    var texture = contentManager.Load<Texture2D>($@"Maps\Tiles\{name}");
                //    _tiles.Textures.Add(name, texture);
                //}
            }

            var first = _tiles.Textures.First();
            _tiles.TilesInWidth = first.Value.Width / _tiles.Width;
            _tiles.TilesInHeight = first.Value.Height / _tiles.Height;
        }

        public void Initialize()
        {
            Visible = true;
        }

        public void LoadMap(string mapName)
        {
            _map = new TmxMap($@"Content\Maps\{mapName}.tmx");

            _tiles = new TilesInfo
            {
                Width = _map.Tilesets[0].TileWidth,
                Height = _map.Tilesets[0].TileHeight,
            };
        }

        public void Draw(SpriteBatch spriteBatch, RectangleF viewport)
        {
            //_map.Draw(spriteBatch, _camera);

            for (var i = 0; i < _map.Layers[0].Tiles.Count; i++)
            {
                int gid = _map.Layers[0].Tiles[i].Gid;

                // Empty tile, do nothing
                if (gid == 0)
                {
                    continue;
                }

                string name = _map.Tilesets.First().Name;

                var leftMargin = 6;
                var rightMargin = 9;
                var upMargin = 6;
                var downMargin = 6;

                int tileFrame = gid;
                int column = tileFrame % _tiles.TilesInWidth - 1;
                int row = tileFrame / _tiles.TilesInWidth;

                int x = i % _map.Width * _map.TileWidth;
                int y = (int)Math.Floor(i / (double)_map.Width) * _map.TileHeight;

                var tilesetRec = new Rectangle(_tiles.Width * column + leftMargin, _tiles.Height * row + upMargin, _tiles.Width, _tiles.Height);
                var positionRec = new Rectangle(x, y, _tiles.Width, _tiles.Height);

                if (!viewport.Intersects(positionRec))
                {
                    continue;
                }

                spriteBatch.Draw(_tiles.Textures[name], positionRec, tilesetRec, Color.White);
            }
        }
    }
}