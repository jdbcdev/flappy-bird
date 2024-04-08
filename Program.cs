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
        const int screenWidth = 288;
        const int screenHeight = 512;

        InitWindow(screenWidth, screenHeight, "Flappy Bird Clone");
        SetTargetFPS(60);

        // Load background day image
        Image background = LoadImage("sprites/background-day.png");
        Texture2D textureBackground = LoadTextureFromImage(background);
        UnloadImage(background);

        // Load base 
        Image terrain = LoadImage("sprites/base.png");
        Texture2D textureBase = LoadTextureFromImage(terrain);
        UnloadImage(terrain);

        // Pipes
        Image pipe = LoadImage("sprites/pipe-green.png");
        Texture2D texturePipe = LoadTextureFromImage(pipe);
        UnloadImage(pipe);


        // Bird
        Bird bird = new Bird();
        int xBird = (screenWidth / 2) - 34;

        // Main loop
        while (!WindowShouldClose())
        {
            BeginDrawing();
            ClearBackground(Color.White);

            int x = screenWidth / 2 - textureBackground.Width / 2;
            int y = screenHeight / 2 - textureBackground.Height / 2;
            DrawTexture(textureBackground, x, y, Color.White);

            DrawTexture(textureBase, x, screenHeight - 112, Color.White);

            bird.update(xBird, 100);

            //DrawText("Let's make an indie videogame!", 190, 200, 20, Color.Black);

            EndDrawing();
        }

        UnloadTexture(textureBackground);
        UnloadTexture(textureBase);
        UnloadTexture(texturePipe);
        CloseWindow();

        return 0;
    }
}