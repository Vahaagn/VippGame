using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;
using VippGame.Core.Builders;
using VippGame.Shapes;
using VippGame.Utils;

namespace VippGame.Core
{
    public class GameEngine : GameWindow
    {
        #region [ Fields ]
        private readonly Random _random;
        private readonly GameTime _gameTime;

        private Matrix4 modelviewMatrix, projectionMatrix;
        private Matrix4 rotationviewMatrix;

        private Camera _camera;
        private InputController _inputController;
        private ObjectManager _objectManager;
        private FpsCounter _fpsCounter;
        private ParticleSystem _particles;
        private Cube _cube;
        #endregion

        #region [ Properties ]
        public bool ShowFps { get; set; }
        public string WindowTitle { get; set; }
        #endregion

        #region [ Constructors ]
        public GameEngine(int width = 640, int height = 480, string title = "Vipp Game")
            : base(width, height, new GraphicsMode(32, 24, 0, 4), title,
                GameWindowFlags.Default, DisplayDevice.Default, 2, 1, GraphicsContextFlags.Debug)
        {
            _random = new Random(DateTime.Now.Millisecond);
            RandomProvider.Initialize(_random);
            _gameTime = new GameTime();
        }
        #endregion

        #region [ Public methods ]
        public void Init()
        {
            Context.MakeCurrent(WindowInfo);

            ConfigureEvents();

            _objectManager = new ObjectManager();
        }

        public void Start()
        {
            ConfigureOpenGl();

            _camera = new Camera(Size) { Position = new Vector3(0, 0, -1), Target = new Vector3(0, 0, 0), Transformation = Vector3.UnitY };
            _inputController = new InputController();
            _fpsCounter = new FpsCounter();
            _particles = ParticleSystemBuilder.Create().WithCount(200).Object();
            _cube = CubeBuilder.Create().WithSize(1).Object();

            _objectManager.AddObject(_cube);
            _objectManager.AddObject(_particles);
            _objectManager.AddObject(_fpsCounter);

            Run(60);
        }
        #endregion

        #region [ Private methods ]
        private void Draw()
        {
            DrawOpenGl();
            SwapBuffers();

            _gameTime.Restart();
        }

        private void DrawOpenGl()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            _camera.Update(_gameTime);
            _inputController.Draw(_camera);

            GL.Translate(0, 0, -5);
            GL.Color3(System.Drawing.Color.Red);
            GL.Begin(BeginMode.Quads);
            GL.Vertex2(1, 1);
            GL.Vertex2(-1, 1);
            GL.Vertex2(-1, -1);
            GL.Vertex2(1, -1);
            GL.End();

            DrawGrid(Color.Aqua, 100, 100);

            _objectManager.Draw();

        }

        private void Update(GameTime gameTime)
        {
            _inputController.Update(gameTime);

            _objectManager.Update(gameTime);
        }

        public void DrawGrid(System.Drawing.Color color, float X, float Z, int cell_size = 16, int grid_size = 256)
        {
            int dX = (int)Math.Round(X / cell_size) * cell_size;
            int dZ = (int)Math.Round(Z / cell_size) * cell_size;

            int ratio = grid_size / cell_size;

            GL.PushMatrix();

            GL.Translate(dX - grid_size / 2, 0, dZ - grid_size / 2);

            int i;

            GL.Color3(color);
            GL.Begin(PrimitiveType.Lines);

            for (i = 0; i < ratio + 1; i++)
            {
                int current = i * cell_size;

                GL.Vertex3(current, 0, 0);
                GL.Vertex3(current, 0, grid_size);

                GL.Vertex3(0, 0, current);
                GL.Vertex3(grid_size, 0, current);
            }

            GL.End();

            GL.PopMatrix();
        }

        private void ConfigureOpenGl()
        {
            GL.ClearDepth(1.0);
            GL.ClearColor(0, 0, 0, 1);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            //GL.Disable(EnableCap.Lighting);
            //GL.Disable(EnableCap.Texture2D);
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //float ratio = Width / (Height * 1.0F);
            //GL.Frustum(-ratio, ratio, -1, 1, 1, 100);
        }

        private void ConfigureEvents()
        {
            Resize += GameEngine_Resize;
            Closed += GameEngine_Closed;

            UpdateFrame += GameEngine_UpdateFrame;
            RenderFrame += GameEngine_RenderFrame;

            KeyPress += GameEngine_KeyPress;
            KeyDown += GameEngine_KeyDown;
        }
        #endregion

        #region [ Events ]
        private void GameEngine_Closed(object sender, EventArgs e)
        {
            Exit();
        }

        void GameEngine_RenderFrame(object sender, FrameEventArgs e)
        {
            Draw();
        }

        void GameEngine_UpdateFrame(object sender, FrameEventArgs e)
        {
            Update(_gameTime);
        }

        void GameEngine_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            _camera.ScreenSize = Size;
            _fpsCounter.UpdateWindowSize(Size);

            GL.Viewport(0, 0, Width, Height);

            //Get the aspect ratio of the screen
            double aspect_ratio = Width / (double)Height;
            //Field of view of are camera
            float fov = 1.0f;
            //The nearest the camera can see, want to keep this number >= 0.1f else visible clipping ensues
            float near_distance = 1.0f;
            //The farthest the camera can see, depending on how far you want to draw this can be up to float.MaxValue
            float far_distance = 1000.0f;

            //Now we pass the parameters onto are matrix
            OpenTK.Matrix4 perspective_matrix =
               OpenTK.Matrix4.CreatePerspectiveFieldOfView(fov, (float)aspect_ratio, near_distance, far_distance);

            //Then we tell GL to use are matrix as the new Projection matrix.
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective_matrix);
        }

        void GameEngine_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only working with alfa-numeric Keys!!
        }

        private void GameEngine_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
        #endregion
    }
}