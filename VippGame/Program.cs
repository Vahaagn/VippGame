/*
 * Name: VippGame
 * Author: Mateusz Giza
 * Date: 26/04/2016
 */

using System;
using OpenTK.Graphics;
using VippGame.Core;

namespace VippGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine { ShowFps = true, WindowTitle = "Vipp Game" };
            gameEngine.Init();
            gameEngine.Start();
        }
    }
}
