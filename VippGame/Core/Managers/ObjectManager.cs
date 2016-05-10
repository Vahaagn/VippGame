#region --- Header ---
// File: ObjectManager.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System.Collections.Generic;
using System.Linq;
using VippGame.Core.Interfaces;
using VippGame.Core.Structs;
using IDrawable = VippGame.Core.Interfaces.IDrawable;

namespace VippGame.Core.Managers
{
    public class ObjectManager
    {
        private readonly List<IObject> _objects;
        private Camera2D _camera;

        public ObjectManager()
        {
            _objects = new List<IObject>();
        }

        public void AddCamera(Camera2D camera)
        {
            _camera = camera;
        }

        public void Add(params IObject[] objects)
        {
            _objects.AddRange(objects);
        }

        public void Remove(IObject @object)
        {
            if (_objects.Contains(@object))
            {
                _objects.Remove(@object);
            }
        }

        public void Initialize()
        {
            _objects.OfType<IInitializable>()
                .AsParallel()
                .ForAll(obj => obj.Initialize());
        }

        public void Load(ContentManager contentManager)
        {
            _objects.OfType<ILoadable>()
                .AsParallel()
                .ForAll(obj => obj.Load(contentManager));
        }

        public void Update(GameTime gameTime)
        {
            _objects.OfType<IUpdatable>()
                .AsParallel()
                .ForAll(obj => obj.Update(gameTime));

            CheckCollisions();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var viewportBounds = GetCamera().GetBoundingRectangle();

            var worlds = _objects.OfType<IWorld>();
            foreach (var world in worlds)
            {
                world.Draw(spriteBatch, viewportBounds);
            }

            var inRangeObjects = _objects.OfType<IDrawable>();
            //.Where(obj => viewportBounds.Intersects(obj.Bounds) && obj.Visible);

            //inRangeObjects.AsParallel().ForAll(obj => obj.Draw(spriteBatch));

            foreach (var inRangeObject in inRangeObjects)
            {
                inRangeObject.Draw(spriteBatch);
            }
        }

        public void CheckCollisions()
        {
            var collideObjects = _objects.OfType<ICollide>().Where(obj => obj.CanCollide);

            foreach (var collideObject in collideObjects.Where(obj => obj.isCheckable))
            {
                collideObject.IsColliding = false;
                collideObject.CollisionResult = CollisionResult.Empty;
            }

            foreach (var collideObject in collideObjects.Where(obj => obj.isCheckable))
            {
                foreach (var collide in collideObjects)
                {
                    if (collide == collideObject) continue;

                    collideObject.CheckCollision(collide);
                }
            }
        }

        public IPlayer GetPlayer()
        {
            return _objects.OfType<IPlayer>().Single();
        }

        public Camera2D GetCamera()
        {
            return _camera;
        }

        public IList<IObject> GetGameObjectsList() => _objects;
    }
}