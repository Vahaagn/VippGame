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
using System.Collections.Generic;
using System.Linq;
using VippGame.Core.Interfaces;
using IDrawable = VippGame.Core.Interfaces.IDrawable;

namespace VippGame.Core.Managers
{
    public class ObjectManager
    {
        private readonly List<IObject> _objects;

        public ObjectManager()
        {
            _objects = new List<IObject>();
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _objects.OfType<IDrawable>()
                .Where(obj => obj.Visible)
                .AsParallel()
                .ForAll(obj => obj.Draw(spriteBatch));
        }

        public IPlayer GetPlayer()
        {
            return _objects.OfType<IPlayer>().Single();
        }

        public ICamera GetCamera()
        {
            return _objects.OfType<ICamera>().Single();
        }
    }
}