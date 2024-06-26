using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
using System;
using System.Text;

namespace Company.FlappyBird;

/**
 * https://github.com/ChrisDill/Raylib-cs-Examples
 */
public class FlappyBirdGame
{
    public static int Main()
    {
        Game game = new Game();
        game.Run();

        CloseWindow();

        return 0;
    }
    
}