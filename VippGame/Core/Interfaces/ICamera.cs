#region --- Header ---

// File: ICamera.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/07

#endregion

using Microsoft.Xna.Framework;

namespace VippGame.Core.Interfaces
{
    public interface ICamera : IObject
    {
        #region --- Properties ---

        Vector2 Position { get; set; }
        float Zoom { get; set; }
        float Rotation { get; set; }
        Matrix TranslationMatrix { get; }

        #endregion

        #region --- Public methods ---

        void ChangeZoom(float difference);

        void LookAt(IGameObject gameObject);

        #endregion
    }
}