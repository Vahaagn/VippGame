#region --- Header ---

// File: ParticleSystemBuilder.cs
// Original Project: VippGame
// Original Solution: VippGame
// ------------------------------
// Created by: Mateusz Giza
// Created on: 2016/05/03

#endregion

namespace VippGame.Core.Builders
{
    public class ParticleSystemBuilder
    {
        #region --- Fields ---

        private readonly ParticleSystem _particleSystem;

        #endregion

        #region --- Constructors ---

        public ParticleSystemBuilder()
        {
            var random = RandomProvider.GetRandom();
            _particleSystem = new ParticleSystem(random);
        }

        #endregion

        #region --- Public methods ---

        public static ParticleSystemBuilder Create() => new ParticleSystemBuilder();

        public ParticleSystem Object()
        {
            return _particleSystem;
        }

        public ParticleSystemBuilder WithCount(uint count)
        {
            _particleSystem.SetParticlesCount(count);
            return this;
        }

        #endregion
    }
}