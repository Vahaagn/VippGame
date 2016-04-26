using System;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using VippGame.Utils;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;

namespace VippGame.Core
{
    public class GameEngine
    {
        #region [ Fields ]
        private RenderWindow _window;
        private readonly Clock _gameClock;
        private readonly Clock _loopClock;
        private readonly Random _random;
        private FpsCounter _fpsCounter;
        private ParticleSystem _particles;
        #endregion

        #region [ Properties ]
        public bool ShowFps { get; set; }
        public string WindowTitle { get; set; }
        #endregion

        #region [ Constructors ]
        public GameEngine()
        {
            _gameClock = new Clock();
            _loopClock = new Clock();
            _random = new Random(DateTime.Now.Millisecond);
        }
        #endregion

        #region [ Public methods ]
        public void Init()
        {
            OpenTK.Toolkit.Init();
            
            _window = new RenderWindow(new VideoMode(640, 480), WindowTitle, Styles.Default, GetContextSettings());
            _window.SetFramerateLimit(60);
            _window.SetVerticalSyncEnabled(true);
            _window.SetActive();

            GraphicsContext graphicsContext = new GraphicsContext(new ContextHandle(IntPtr.Zero), null);

            ConfigureEvents();
        }

        public void Start()
        {
            ConfigureOpenGl();

            var cube = GetCube();

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);
            GL.VertexPointer(3, VertexPointerType.Float, 7 * sizeof(float), Marshal.UnsafeAddrOfPinnedArrayElement(cube, 0));
            GL.ColorPointer(4, ColorPointerType.Float, 7 * sizeof(float), Marshal.UnsafeAddrOfPinnedArrayElement(cube, 3));
            GL.DisableClientState(ArrayCap.NormalArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);

            var font = new Font(Resources.Fonts.consola);

            Time elapsedTime = _loopClock.Restart();
            _fpsCounter = new FpsCounter(font);

            _particles = new ParticleSystem(_random, 100);

            while (_window.IsOpen)
            {
                _window.DispatchEvents();

                Update(elapsedTime);
                _fpsCounter.Update();

                Draw();

                _window.Display();
                elapsedTime = _loopClock.Restart();
            }
        }
        #endregion

        #region [ Private methods ]
        private void Draw()
        {
            DrawOpenGl();
            _window.PushGLStates();
            DrawSfml();
            _window.PopGLStates();
        }

        private void DrawOpenGl()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0.0F, 0.0F, -200.0F);
            GL.Rotate(_gameClock.ElapsedTime.AsSeconds() * 50, 1.0F, 0.0F, 0.0F);
            GL.Rotate(_gameClock.ElapsedTime.AsSeconds() * 50, 0.0F, 0.5F, 0.0F);
            GL.Rotate(_gameClock.ElapsedTime.AsSeconds() * 50, 0.0F, 0.0F, 0.75F);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            

            _fpsCounter.Draw();
        }

        private void DrawSfml()
        {
            _particles.DrawSfml(_window);

            //_fpsCounter.Draw(_window);
        }

        private void Update(Time gameTime)
        {
            _particles.Update(gameTime);
        }

        private void ConfigureOpenGl()
        {
            GL.ClearDepth(1.0);
            GL.ClearColor(0, 0, 0, 1);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.Texture2D);
            GL.Viewport(0, 0, (int)_window.Size.X, (int)_window.Size.Y);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            float ratio = _window.Size.X / (_window.Size.Y * 1.0F);
            GL.Frustum(-ratio, ratio, -1, 1, 1, 500);
        }

        private ContextSettings GetContextSettings()
        {
            ContextSettings contextSettings = new ContextSettings
            {
                MajorVersion = 3,
                MinorVersion = 1,
                DepthBits = 24,
                StencilBits = 8,
                AntialiasingLevel = 4,
                AttributeFlags = ContextSettings.Attribute.Debug
            };

            return contextSettings;
        }

        private void ConfigureEvents()
        {
            _window.Closed += window_Closed;
            _window.Resized += window_Resized;
            _window.KeyPressed += window_KeyPressed;
        }

        // TODO: It's just temporary! Remember to delete it later
        private static float[] GetCube()
        {
            return new float[]
            {
                -50, -50, -50, 0, 0, 1, 1,
                -50, 50, -50, 0, 0, 1, 1,
                -50, -50, 50, 0, 0, 1, 1,
                -50, -50, 50, 0, 0, 1, 1,
                -50, 50, -50, 0, 0, 1, 1,
                -50, 50, 50, 0, 0, 1, 1,

                50, -50, -50, 0, 1, 0, 1,
                50, 50, -50, 0, 1, 0, 1,
                50, -50, 50, 0, 1, 0, 1,
                50, -50, 50, 0, 1, 0, 1,
                50, 50, -50, 0, 1, 0, 1,
                50, 50, 50, 0, 1, 0, 1,

                -50, -50, -50, 1, 0, 0, 1,
                50, -50, -50, 1, 0, 0, 1,
                -50, -50, 50, 1, 0, 0, 1,
                -50, -50, 50, 1, 0, 0, 1,
                50, -50, -50, 1, 0, 0, 1,
                50, -50, 50, 1, 0, 0, 1,

                -50, 50, -50, 0, 1, 1, 1,
                50, 50, -50, 0, 1, 1, 1,
                -50, 50, 50, 0, 1, 1, 1,
                -50, 50, 50, 0, 1, 1, 1,
                50, 50, -50, 0, 1, 1, 1,
                50, 50, 50, 0, 1, 1, 1,

                -50, -50, -50, 1, 0, 1, 1,
                50, -50, -50, 1, 0, 1, 1,
                -50, 50, -50, 1, 0, 1, 1,
                -50, 50, -50, 1, 0, 1, 1,
                50, -50, -50, 1, 0, 1, 1,
                50, 50, -50, 1, 0, 1, 1,

                -50, -50, 50, 1, 1, 0, 1,
                50, -50, 50, 1, 1, 0, 1,
                -50, 50, 50, 1, 1, 0, 1,
                -50, 50, 50, 1, 1, 0, 1,
                50, -50, 50, 1, 1, 0, 1,
                50, 50, 50, 1, 1, 0, 1,
            };
        }
        #endregion

        #region [ Events ]
        private void window_KeyPressed(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;

            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }

        private void window_Resized(object sender, SizeEventArgs e)
        {
            GL.Viewport(0, 0, (int)e.Width, (int)e.Height);
        }

        private void window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
        #endregion
    }
}