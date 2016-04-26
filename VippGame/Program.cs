﻿/*
 * Name: VippGame
 * Author: Mateusz Giza
 * Date: 26/04/2016
 */

using VippGame.Core;

namespace VippGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Init();
            gameEngine.Start();
        }
    }
}
