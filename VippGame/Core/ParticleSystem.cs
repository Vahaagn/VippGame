using System;
using SFML.Graphics;
using SFML.System;
using VippGame.Utils;

namespace VippGame.Core
{
    public class ParticleSystem
    {
        private Particle[] _particles;
        private VertexArray _vertexArray;

        public ParticleSystem(Random rand, uint count = 50)
        {
            _particles = new Particle[count];
            for (int i = 0; i < _particles.Length; i++)
            {
                _particles[i] = new Particle(rand);
            }

            _vertexArray = new VertexArray(PrimitiveType.Points, count);
        }

        public void DrawSfml(RenderWindow renderWindow)
        {
            for (uint i = 0; i < _vertexArray.VertexCount; i++)
            {
                Vertex vertex = _vertexArray[i];
                vertex.Position = _particles[i]._position.ToVector2F();
                vertex.Color.A = _particles[i]._color.A;
                _vertexArray[i] = vertex;
            }

            renderWindow.Draw(_vertexArray);
        }

        public void Update(Time gameTime)
        {
            for (uint i = 0; i < _vertexArray.VertexCount; i++)
            {
                _particles[i].Update(gameTime);
            }
        }
    }
}