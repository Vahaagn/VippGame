using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using VippGame.Resources;

namespace VippGame.Core
{
    public class Camera
    {
        #region --- Fields ---

        private Matrix4 _modelMatrix;
        private Matrix4 _viewMatrix;
        private Matrix4 _projectionMatrix;

        private Vector3 _rotation;

        #endregion

        #region --- Properties ---

        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 Transformation { get; set; }
        public Size ScreenSize { get; set; }
        public float Zoom { get; set; }

        public float AspectRatio => ScreenSize.Width / 1.0F * ScreenSize.Height;
        public float Fov => MathHelper.DegreesToRadians(60);

        public Matrix4 ModelMatrix
        {
            get { return _modelMatrix; }
            set { _modelMatrix = value; }
        }

        public Matrix4 ViewMatrix
        {
            get { return _viewMatrix; }
            set { _viewMatrix = value; }
        }

        public Matrix4 ProjectionMatrix
        {
            get { return _projectionMatrix; }
            set { _projectionMatrix = value; }
        }

        public ShaderProgram ShaderProgram { get; }

        #endregion

        #region --- Constructors ---

        public Camera(Size? screenSize = null)
        {
            ScreenSize = screenSize ?? new Size(640, 480);
            Zoom = 1.0f;

            var shaders = new Shader[]
            {
                new Shader(ShaderType.VertexShader, Shaders.Camera_Vertex)
            };
            ShaderProgram = new ShaderProgram(shaders);
            ShaderProgram.Use();

            _modelMatrix = Matrix4.Identity;
            _viewMatrix = Matrix4.Identity;
            _projectionMatrix = Matrix4.Identity;
        }

        #endregion

        #region --- Public methods ---

        public void Rotate(Vector3 velocity)
        {
            //_rotation = velocity;

            //GL.Rotate(_rotation.X, 1.0F, 0.0f, 0.0f);
            //GL.Rotate(_rotation.Y, 0.0f, 1.0F, 0.0f);
        }

        public void Update(GameTime gameTime)
        {
            CalculateModelViewProjection();

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref _projectionMatrix);

            GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);

            //GL.Rotate(RotationX, 1, 0, 0);
            //GL.Rotate(RotationY, 0, 1, 0);
            //GL.Rotate(RotationZ, 0, 0, 1);
            //GL.Translate(-X, -Y, -Z);
        }

        private void CalculateModelViewProjection()
        {
            var modelPosition = GL.GetUniformLocation(ShaderProgram.Handle, nameof(ModelMatrix));
            var viewPosition = GL.GetUniformLocation(ShaderProgram.Handle, nameof(ViewMatrix));
            var projectionPosition = GL.GetUniformLocation(ShaderProgram.Handle, nameof(ProjectionMatrix));

            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(Fov, AspectRatio, 0.1f, 100.0f);
            _viewMatrix = Matrix4.LookAt(new Vector3(4, 3, 3), Vector3.Zero, Vector3.UnitY);
            _modelMatrix = Matrix4.Identity;

            GL.UniformMatrix4(modelPosition, false, ref _modelMatrix);
            GL.UniformMatrix4(viewPosition, false, ref _viewMatrix);
            GL.UniformMatrix4(projectionPosition, false, ref _projectionMatrix);
        }

        #endregion
    }
}