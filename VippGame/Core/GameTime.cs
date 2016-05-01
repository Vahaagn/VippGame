using System;
using System.Diagnostics;

namespace VippGame.Core
{
    public class GameTime
    {
        private readonly Stopwatch _gameClock;
        private readonly Stopwatch _loopClock;

        public TimeSpan ElapsedTime { get; private set; }
        public float DeltaTime => (float)(ElapsedTime.TotalMilliseconds / 1000.0);
        public float DeltaTicks => ElapsedTime.Ticks / (float)Stopwatch.Frequency;

        public GameTime()
        {
            _gameClock = new Stopwatch();
            _loopClock = new Stopwatch();

            _gameClock.Start();
            _loopClock.Start();
        }

        public TimeSpan ElapsedTillStart => _gameClock.Elapsed;

        public TimeSpan Restart()
        {
            ElapsedTime = _loopClock.Elapsed;
            _loopClock.Restart();

            return ElapsedTime;
        }
    }
}