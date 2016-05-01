using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace VippGame.Core
{
    public class Camera
    {
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 Transformation { get; set; }
        public Size ScreenSize { get; set; }
        public float Zoom { get; set; }

        public Camera(Size? screenSize = null)
        {
            ScreenSize = screenSize ?? new Size(640, 480);
            Zoom = 1.0f;
        }

        public void Update(GameTime gameTime)
        {
            CalculateAndProject();
        }

        private Vector3 _rotation;

        public void Rotate(Vector3 velocity)
        {
            _rotation = velocity;

            GL.Rotate(_rotation.X, 1.0F, 0.0f, 0.0f);
            GL.Rotate(_rotation.Y, 0.0f, 1.0F, 0.0f);
        }

        private void CalculateAndProject()
        {
            var aspect = ScreenSize.Width / (float)ScreenSize.Height;

            //if (orthoView)
            //{
            //    GL.MatrixMode(MatrixMode.Projection);
            //    GL.LoadIdentity();
            //    GL.Ortho(-r * aspect, r * aspect, -r, r, -100, 100);
            //}

            //else
            //{
            //Matrix4 perspective = Matrix4.Perspective(60, aspect, 1, 10000);
            //Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90), aspect, 1, 1000);
            Matrix4 perspective = Matrix4.CreatePerspectiveOffCenter(-Zoom * aspect, Zoom * aspect, -Zoom, Zoom, 1, 10000);
            Matrix4 lookat = Matrix4.LookAt(Position, Target, Transformation);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.MultMatrix(ref perspective);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.MultMatrix(ref lookat);
            //GL.LoadMatrix(ref lookat);
            //}
        }
    }
}