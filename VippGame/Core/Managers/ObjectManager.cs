#region --- Header ---

// File: ObjectManager.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/03

#endregion

using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using VippGame.Core.Interfaces;

namespace VippGame.Core
{
    public class ObjectManager
    {
        #region --- Fields ---

        private readonly List<IGameObject> _gameObjects;

        #endregion

        #region --- Constructors ---

        public ObjectManager()
        {
            _gameObjects = new List<IGameObject>();
        }

        #endregion

        #region --- Public methods ---

        public void AddObject(IGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        public void AddObjects(IEnumerable<IGameObject> gameObjects)
        {
            _gameObjects.AddRange(gameObjects);
        }

        public void Draw()
        {
            foreach (var gameObject in _gameObjects)
            {
                GL.PushMatrix();

                gameObject.Draw();

                GL.PopMatrix();
            }
        }

        public void Update(GameTime gameTime)
        {
            _gameObjects.ForEach(go => go.Update(gameTime));
        }

        #endregion
    }
}