#region --- Header ---

// File: IdentifierProvider.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/03

#endregion

namespace VippGame.Core
{
    public static class IdentifierProvider
    {
        #region --- Constants ---

        private static int _lastId;

        #endregion

        #region --- Public methods ---

        public static int GetAvailableId()
        {
            return _lastId++;
        }

        #endregion
    }
}