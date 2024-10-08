using Raylib_cs;
using static Raylib_cs.Raylib;

public class Game 
{
    public Bird bird {get; private set;}

    public int score {get; set;}
    private List<Texture2D> scoreTextures = new();
    private int scorePosX = SCREEN_WIDTH / 2;

    private const int SCREEN_WIDTH = 288;
    private const int SCREEN_HEIGHT = 512;

    private const int BIRD_DOWN = 4;
    private const int BIRD_UP = 2;

    private Texture2D textureBackground;
    private Texture2D textureBase;

    private PipeManager pipeManager;

    private int xBird, yBird;

    private Texture2D textureGameover;

    private bool gameOver = false;

    public void Run() {

        InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "Flappy Bird Clone");
        SetTargetFPS(60);

        CreateBackGround();
        CreateTerrainBase();

        LoadScoreTextures();

        LoadGameOverTexture();

        this.score = 0;
        this.pipeManager = new PipeManager(SCREEN_WIDTH);

        // Bird
        this.bird = new Bird();

        this.InitBirdPosition();

        int x = (SCREEN_WIDTH / 2 - textureBackground.Width / 2);
        int y = SCREEN_HEIGHT / 2 - textureBackground.Height / 2;

        // Main loop
        while (!WindowShouldClose())
        {
            BeginDrawing();
            ClearBackground(Color.White);

            // Check collision bird and pipes
            if (this.pipeManager.CheckCollision(this.bird)) {
                this.gameOver = true;
            }

            // Check collision against the floor
            if (this.bird.posY > (SCREEN_HEIGHT - 130)) {
                this.gameOver = true;
            }
            
            this.HandleInput();

            if (!this.gameOver) {

                DrawTexture(textureBackground, x, y, Color.White);

                this.pipeManager.Update(this);
                DrawTexture(textureBase, x, SCREEN_HEIGHT - 112, Color.White);

                this.bird.Update(xBird, yBird);
                
                this.DrawScore();
            } else {
                DrawTexture(textureBackground, x, y, Color.White);
                DrawTexture(textureBase, x, SCREEN_HEIGHT - 112, Color.White);

                DrawTexture(textureGameover, 50, 120, Color.White);

                this.DrawScore();
            }

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

    private void InitBirdPosition() {
        this.xBird = (SCREEN_WIDTH / 2) - 70;
        this.yBird = 100; // Initial Y position
    }

    private void HandleInput() {
        
        if (!gameOver) {
            // Input handling
            if (IsKeyDown(KeyboardKey.Space)) {
                this.yBird -= BIRD_DOWN;
            } else {
                this.yBird += BIRD_UP;
            }
        } else {
            if (IsKeyDown(KeyboardKey.Enter)) {
                this.InitBirdPosition();
                this.pipeManager = new PipeManager(SCREEN_WIDTH);

                this.gameOver = false;
            }
        }
    }

    private void LoadScoreTextures() {
        for (int index = 0; index < 10; index++){
            var fileName = "sprites/" + index + ".png";
            Image numberImage = LoadImage(fileName);
            Texture2D numberTexture = LoadTextureFromImage(numberImage);
            this.scoreTextures.Add(numberTexture);
            UnloadImage(numberImage);
        }
    }

    private void LoadGameOverTexture() {
        Image gameoverImage = LoadImage("sprites/gameover.png");
        this.textureGameover = LoadTextureFromImage(gameoverImage);
        UnloadImage(gameoverImage);
    }

    private bool CheckCollision() {
        return false;
    }

    private void DrawScore() {

        string scoreString = this.score.ToString();
        
        int counter = scoreString.Length;
        foreach (char digit in scoreString) {
            int index = digit - '0';

            int scoreX  = this.scorePosX - (24 * (counter - 1));

            DrawTexture(this.scoreTextures.ElementAt(index), scoreX, 20, Color.White);

            counter--;
        }
    }
    
}