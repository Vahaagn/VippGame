using System;
using OpenTK.Graphics.OpenGL;
using SFML.Graphics;
using SFML.System;
using VippGame.GLObjects;
using VippGame.Utils;
using PrimitiveType = SFML.Graphics.PrimitiveType;

namespace VippGame.Core
{
    public class ParticleSystem
    {
        private readonly Particle[] _particles;
        private readonly VertexArray _vertexArray;

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
                vertex.Position = _particles[i].Position.Xy.ToVector2F();
                vertex.Color.A = _particles[i].Color.A;
                _vertexArray[i] = vertex;
            }

            renderWindow.Draw(_vertexArray);
        }

        public void Draw()
        {
            foreach (var particle in _particles)
            {
                particle.Draw3D();
            }
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