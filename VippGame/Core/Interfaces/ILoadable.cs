#region --- Header ---
// File: ILoadable.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07
#endregion

using Microsoft.Xna.Framework.Content;

namespace VippGame.Core.Interfaces
{
    public interface ILoadable
    {
        void Load(ContentManager contentManager);
    }
}