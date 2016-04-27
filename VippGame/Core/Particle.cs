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
        private float _size;
        private float _angle;
        private float _speed;
        private Vector3 _velocity;
        public Vector3 _position;
        private Time _lifeTime;
        public Color _color;

        public Particle(Random rand, Vector3? position = null, float size = 1.5f, Color? color = null)
        {
            _rand = rand;

            _size = size;
            _position = position ?? Vector3.Zero;
            _color = color ?? Color.White;

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

            GL.Color4(_color);
            GL.PointSize(_size);

            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(_position.Xy);
            GL.End();
            
            GL.Disable(EnableCap.Blend);

            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
        }

        public void Draw3D()
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Color4(_color);
            GL.PointSize(_size);

            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(_position);
            GL.End();

            GL.Disable(EnableCap.Blend);
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

        /// <summary>
        /// This will reset the angle, speed, velocity, lifetime and position of the Particle with random values
        /// </summary>
        private void Reset()
        {
            _angle = (float)(_rand.Next(0, 360) * Math.PI / 180f);
            _speed = _rand.Next(0, 50) + 50f;

            _velocity = new Vector3((float)Math.Cos(_angle) * _speed, (float)Math.Sin(_angle) * _speed, (float)Math.Sin(_angle)*_speed);
            _lifeTime = Time.FromMilliseconds(_rand.Next(1000, 3000));
            _position = new Vector3(_rand.Next(-640, 640), _rand.Next(-480, 480), _rand.Next(-200, 200));
        }
    }
}