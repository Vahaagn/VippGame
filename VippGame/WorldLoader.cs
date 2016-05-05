using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VippGame
{
    public class WorldLoader
    {
        private byte[,] _worldData;
        private readonly int _tileSize;
        private float _scale = 5f;
        private Random _rand;
        private Point _size;

        public WorldLoader(Point size, int tileSize = 16)
        {
            _size = size;
            _tileSize = tileSize;
            _rand = new Random(DateTime.UtcNow.Millisecond);

            Init();
        }

        private void Init()
        {
            //_worldData = new byte[,]
            //{
            //    {1, 1, 1, 0},
            //    {1, 0, 0, 1},
            //    {1, 1, 0, 1}
            //};
            int tilesX = (int)(_size.X / (_tileSize * _scale));
            int tilesY = (int)(_size.Y / (_tileSize * _scale));
            _worldData = new byte[tilesY, tilesX];
            Generate();
        }

        private void Generate()
        {
            for (int i = 0; i < _worldData.GetLength(0); ++i)
            {
                for (int j = 0; j < _worldData.GetLength(1); ++j)
                {
                    var n = _rand.Next(0, 255);
                    var f = n%2 == 0 ? 0 : 1;
                    _worldData[i, j] = (byte) f;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture2)
        {
            for (int i = 0; i < _worldData.GetLength(0); ++i)
            {
                for (int j = 0; j < _worldData.GetLength(1); ++j)
                {
                    if (_worldData[i, j] == 0)
                    {
                        continue;
                    }

                    spriteBatch.Draw(texture2, new Vector2(j * _tileSize * _scale, i * _tileSize * _scale), null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 1f);
                }
            }
        }
    }
}