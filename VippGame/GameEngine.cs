using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VippGame.Core.Managers;

namespace VippGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private WorldLoader _worldLoader;
        private Texture2D _dirt1;
        private Texture2D _dirt2;
        private Texture2D _dirt3;
        private Camera _camera;
        private InputController _inputController;
        private ObjectManager _objectManager;

        public GameEngine()
        {
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _objectManager = new ObjectManager();

            var worldSize = new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            var centerScreen = new Vector2(worldSize.X / 2f, worldSize.Y / 2f);

            _worldLoader = new WorldLoader(worldSize);
            _camera = new Camera()
            {
                Position = new Vector3(centerScreen, 0),
                Rotation = 0f,
                Zoom = 1f
            };
            var player = new Player() { Color = Color.White, Position = centerScreen };
            _inputController = new InputController(Window, _camera, player);

            _objectManager.Add(player);
            _objectManager.Initialize();

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
            //GraphicsDevice.Viewport = new Viewport(0, 0, 4000, 2000);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _dirt1 = Content.Load<Texture2D>("Textures/dirt1");
            _dirt2 = Content.Load<Texture2D>("Textures/dirt2");
            _dirt3 = Content.Load<Texture2D>("Textures/dirt3");

            _objectManager.Load(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _inputController.Update();

            _objectManager.Update(gameTime);

            _camera.LookAt(_objectManager.GetPlayer());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, _camera.TranslationMatrix);

            _worldLoader.Draw(_spriteBatch, _dirt1, _dirt2, _dirt3);

            _objectManager.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
