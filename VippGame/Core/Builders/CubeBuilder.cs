#region --- Header ---

// File: CubeBuilder.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/03

#endregion

using OpenTK.Graphics;
using System;
using VippGame.Shapes;

namespace VippGame.Core.Builders
{
    public class CubeBuilder
    {
        #region --- Fields ---

        private readonly Cube _cube;

        #endregion

        #region --- Constructors ---

        public CubeBuilder()
        {
            _cube = new Cube();
        }

        #endregion

        #region --- Public methods ---

        public static CubeBuilder Create() => new CubeBuilder();

        public Cube Object()
        {
            return _cube;
        }

        public CubeBuilder WithColor(Color4 color)
        {
            throw new NotImplementedException("Cube object need the publi color Property");
            return this;
        }

        public CubeBuilder WithSize(float size)
        {
            _cube.Size = size;
            return this;
        }

        #endregion
    }
}