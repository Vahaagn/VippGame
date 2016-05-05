using System;
using VippGame.Core.Interfaces;
using VippGame.GLObjects;

namespace VippGame.Core
{
    public class ParticleSystem : IGameObject
    {
        #region --- Fields ---

        private Particle[] _particles;
        private readonly Random _rand;

        #endregion

        #region --- Properties ---

        public int Count => _particles.Length;

        #endregion

        #region --- Constructors ---

        public ParticleSystem(Random rand, uint count = 50)
        {
            _rand = rand;
            InitializeArray(count);
        }

        #endregion

        #region --- IGameObject Members ---

        public void Draw()
        {
            foreach (var particle in _particles)
            {
                particle.Draw3D();
            }
        }

        public void Update(GameTime gameTime)
        {
            for (uint i = 0; i < _particles.Length; i++)
            {
                _particles[i].Update(gameTime);
            }
        }

        public int Id { get; }

        #endregion

        #region --- Public methods ---

        public void SetParticlesCount(uint newCount)
        {
            InitializeArray(newCount);
        }

        private void InitializeArray(uint count)
        {
            _particles = new Particle[count];
            for (var i = 0; i < _particles.Length; i++)
            {
                _particles[i] = new Particle(_rand);
            }
        }

        #endregion
    }
}