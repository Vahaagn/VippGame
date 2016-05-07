#region --- Header ---
// File: IUpdatable.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using Microsoft.Xna.Framework;

namespace VippGame.Core.Interfaces
{
    public interface IUpdatable
    {
        void Update(GameTime gameTime);
    }
}