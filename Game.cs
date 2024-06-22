using Raylib_cs;
using static Raylib_cs.Raylib;

public class Game 
{
    private const int SCREEN_WIDTH = 288;
    private const int SCREEN_HEIGHT = 512;

    private Texture2D textureBackground;
    private Texture2D textureBase;

    private PipeManager pipeManager;
    private Bird bird;

    private int xBird, yBird;

    public void Run() {

        InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "Flappy Bird Clone");
        SetTargetFPS(60);

        CreateBackGround();
        CreateTerrainBase();

        this.pipeManager = new PipeManager(SCREEN_WIDTH);

        // Bird
        this.bird = new Bird();

        Init();

         // Main loop
        while (!WindowShouldClose())
        {
            BeginDrawing();
            ClearBackground(Color.White);
            
            // Input handling
            if (IsKeyDown(KeyboardKey.Space)) {
                yBird -= 4;
            } else {
                yBird += 2;
            }

            int x = (SCREEN_WIDTH / 2 - textureBackground.Width / 2);
            int y = SCREEN_HEIGHT / 2 - textureBackground.Height / 2;
            
            DrawTexture(textureBackground, x, y, Color.White);

            this.pipeManager.Update();
            DrawTexture(textureBase, x, SCREEN_HEIGHT - 112, Color.White);

            this.bird.Update(xBird, yBird);

            EndDrawing();
        }

        this.bird.UnloadTextures();
        UnloadTexture(this.textureBackground);
        UnloadTexture(this.textureBase);
    }

    private void CreateBackGround() {
        // Load background day image    
        Image background = LoadImage("sprites/background-day.png");
        this.textureBackground = LoadTextureFromImage(background);
        UnloadImage(background);
    }
    
    private void CreateTerrainBase() {
        Image terrain = LoadImage("sprites/base.png");
        this.textureBase = LoadTextureFromImage(terrain);
        UnloadImage(terrain);
    }

    private void Init() {
        this.xBird = (SCREEN_WIDTH / 2) - 70;
        this.yBird = 100; // Initial Y position
    }
}