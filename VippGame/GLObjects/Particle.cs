using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;
using Time = SFML.System.Time;

namespace VippGame.GLObjects
{
    public class Particle
    {
        private readonly Random _rand;
        private readonly float _size;
        private float _angle;
        private float _speed;
        private Vector3 _velocity;
        private Time _lifeTime;

        public Vector3 Position { get; set; }
        public Color Color { get; set; }

        public Particle(Random rand, Vector3? position = null, float size = 1.5f, Color? color = null)
        {
            _rand = rand;

            _size = size;
            Position = position ?? Vector3.Zero;
            Color = color ?? Color.White;

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

            GL.Color4(Color);
            GL.PointSize(_size);

            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(Position.Xy);
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

            GL.Color4(Color);
            GL.PointSize(_size);

            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(Position);
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

            Position += _velocity * gameTime.AsSeconds();

            float ratio = _lifeTime.AsSeconds() / 3f;
            Color = Color.FromArgb((int) (ratio*255), Color);
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
            Position = new Vector3(_rand.Next(-640, 640), _rand.Next(-480, 480), _rand.Next(-200, 200));
        }
    }
}