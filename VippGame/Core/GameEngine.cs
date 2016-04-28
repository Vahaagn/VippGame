using System;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using VippGame.Shapes;
using VippGame.Utils;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;

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

        private InputManager _inputManager;
        private FpsCounter _fpsCounter;
        private ParticleSystem _particles;
        private Cube _cube;
        #endregion

        #region [ Properties ]
        public bool ShowFps { get; set; }
        public string WindowTitle { get; set; }
        #endregion

        #region [ Constructors ]

        public GameEngine()
            : base(640, 480, GraphicsMode.Default, "Test",
                GameWindowFlags.Default, DisplayDevice.Default, 3, 1,
                GraphicsContextFlags.Debug)
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

            _inputManager = new InputManager();
            _fpsCounter = new FpsCounter(font);
            _particles = new ParticleSystem(_random, 100);
            _cube = new Cube();

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
            KeyPress += GameEngine_KeyPress;

            UpdateFrame += GameEngine_UpdateFrame;
            RenderFrame += GameEngine_RenderFrame;
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
        }

        void GameEngine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Key.Escape)
            {
                Close();
            }
        }
        #endregion
    }
}