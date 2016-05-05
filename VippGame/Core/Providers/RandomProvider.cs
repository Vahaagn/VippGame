#region --- Header ---

// File: RandomProvider.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/03

#endregion

using System;

namespace VippGame.Core
{
    public class RandomProvider
    {
        #region --- Constants ---

        private static Random _random;

        #endregion

        #region --- Public methods ---

        public static Random GetRandom() => _random;

        public static void Initialize(Random random)
        {
            _random = random;
        }

        #endregion
    }
}