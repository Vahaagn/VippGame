using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SFML.Graphics;
using VippGame.Utils;
using Color = System.Drawing.Color;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;
using Time = SFML.System.Time;

namespace VippGame.Core
{
    public class Particle
    {
        private Random _rand;
        private int _size;
        private float _angle;
        private float _speed;
        private Vector2 _velocity;
        public Vector2 _position;
        private Time _lifeTime;
        public Color _color;

        public Particle(Random rand, Vector2? position = null, int size = 2)
        {
            _rand = rand;

            _size = size;
            _position = position ?? Vector2.Zero;
            _color = Color.White;

            Reset();
        }

        public void Draw()
        {
            GL.PushMatrix();
            GL.LoadIdentity();

            Matrix4 orthoProjection = Matrix4.CreateOrthographicOffCenter(0, 640, 480, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Projection);

            GL.PushMatrix();//
            GL.LoadMatrix(ref orthoProjection);
            
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Color3(_color);
            GL.PointSize(_size);

            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(_position);
            GL.End();
            
            GL.Disable(EnableCap.Blend);

            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
        }

        public void Update(Time gameTime)
        {
            _lifeTime -= gameTime;

            if (_lifeTime <= Time.Zero)
            {
                Reset();
            }

            _position += _velocity * gameTime.AsSeconds();

            float ratio = _lifeTime.AsSeconds() / 3f;
            _color = Color.FromArgb((int) (ratio*255), _color);
        }

        private void Reset()
        {
            _angle = (float)(_rand.Next(0, 360) * Math.PI / 180f);
            _speed = _rand.Next(0, 50) + 50f;

            _velocity = new Vector2((float)Math.Cos(_angle) * _speed, (float)Math.Sin(_angle) * _speed);
            _lifeTime = Time.FromMilliseconds(_rand.Next(1000, 3000));
            _position = new Vector2(_rand.Next(0, 640), _rand.Next(0, 480));
        }
    }
}