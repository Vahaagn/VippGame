using System;
using VippGame.GLObjects;

namespace VippGame.Core
{
    public class ParticleSystem
    {
        private readonly Particle[] _particles;

        public ParticleSystem(Random rand, uint count = 50)
        {
            _particles = new Particle[count];
            for (int i = 0; i < _particles.Length; i++)
            {
                _particles[i] = new Particle(rand);
            }
        }

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
    }
}