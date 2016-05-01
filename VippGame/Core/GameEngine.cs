using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using SFML.Graphics;
using SFML.System;
using VippGame.Shapes;
using VippGame.Utils;

namespace VippGame.Core
{
    public class GameEngine : GameWindow
    {
        #region [ Fields ]
        //private RenderWindow _window;
        private readonly Clock _gameClock;
        private readonly Clock _loopClock;
        private readonly Random _random;
        private Time _elapsedTime;
        private Matrix4 modelviewMatrix, projectionMatrix;
        private Matrix4 rotationviewMatrix;

        private Camera _camera;
        private InputManager _inputManager;
        private FpsCounter _fpsCounter;
        private ParticleSystem _particles;
        private CubeV2 _cube;
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
            _gameClock = new Clock();
            _loopClock = new Clock();
            _random = new Random(DateTime.Now.Millisecond);
        }

        #endregion

        #region [ Public methods ]
        public void Init()
        {
            Context.MakeCurrent(WindowInfo);
            
            ConfigureEvents();
        }

        public void Start()
        {
            ConfigureOpenGl();

            var font = new Font(Resources.Fonts.consola);

            _camera = new Camera(Size) { Position = new Vector3(0, 0, 10), Target = new Vector3(0, 0, 0), Transformation = Vector3.UnitY };
            _inputManager = new InputManager();
            _fpsCounter = new FpsCounter(font);
            _particles = new ParticleSystem(_random, 100);
            _cube = new CubeV2();

            Run(60);
        }
        #endregion

        #region [ Private methods ]
        private void Draw()
        {
            DrawOpenGl();

            SwapBuffers();

            _elapsedTime = _loopClock.Restart();
        }

        private void DrawOpenGl()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0.0F, 0.0F, -200.0F);

            _inputManager.Draw();
            _camera.Update(_gameTime);
            _inputManager.Draw(_camera);

            _cube.Draw();
            _particles.Draw();
            _fpsCounter.Draw();
        }

        private void Update(Time gameTime)
        {
            _inputManager.Update(gameTime);
            _particles.Update(gameTime);

            _fpsCounter.Update();
        }

        private void ConfigureOpenGl()
        {
            GL.ClearDepth(1.0);
            GL.ClearColor(0, 0, 0, 1);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.Texture2D);
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            float ratio = Width / (Height * 1.0F);
            GL.Frustum(-ratio, ratio, -1, 1, 1, 500);
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

        private void GameEngine_Closed(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region [ Events ]
        void GameEngine_RenderFrame(object sender, FrameEventArgs e)
        {
            Draw();
        }

        void GameEngine_UpdateFrame(object sender, FrameEventArgs e)
        {
            Update(_elapsedTime);
        }

        void GameEngine_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            _camera.ScreenSize = Size;
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