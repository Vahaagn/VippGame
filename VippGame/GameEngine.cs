﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using VippGame.Core.Controller;
using VippGame.Core.Entities;
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

            var worldSize = new Point(5000, 5000);
            var centerScreen = new Vector2(worldSize.X / 2f, worldSize.Y / 2f);

            _worldLoader = new WorldLoader(worldSize);
            //var camera = new Camera()
            //{
            //    Position = centerScreen,
            //    Rotation = 0f,
            //    Zoom = 1f,
            //    ViewPort = GraphicsDevice.Viewport
            //};
            var viewportAdapter = new BoxingViewportAdapter(Window, _graphics, worldSize.X, worldSize.Y);
            var camera = new Camera2D(viewportAdapter) { Zoom = 5f };
            var player = new Player() { Color = Color.White, Position = centerScreen };
            var cubes = new[]
            {
                new Cube(50, 50),
                new Cube(100, 50),
                new Cube(150, 50),
                new Cube(50, 100),
                new Cube(50, 150),
            };

            _inputController = new InputController(Window, camera, player);

            _objectManager.AddCamera(camera);
            _objectManager.Add(player);
            foreach (var cube in cubes)
            {
                _objectManager.Add(cube);
            }
            _objectManager.Initialize();

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

            _objectManager.GetCamera().LookAt(_objectManager.GetPlayer().Position);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null,
                _objectManager.GetCamera().GetViewMatrix());

            _worldLoader.Draw(_spriteBatch, _objectManager.GetCamera().GetBoundingRectangle(), _dirt1, _dirt2, _dirt3);

            _objectManager.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
