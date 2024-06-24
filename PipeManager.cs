using Raylib_cs;
using static Raylib_cs.Raylib;

public class PipeManager {

    private const int PIPE_WIDTH = 52;
    private const int PIPE_HEIGHT = 320;

    private List<Pipe> pipeList = new();

    private Texture2D textureDown;
    private Texture2D textureUp;

    public PipeManager(int posX) {

        // Pipes
        Image imagePipe = LoadImage("sprites/pipe-green.png");
        this.textureDown = LoadTextureFromImage(imagePipe);

        // Pipes
        Image imagePipeUp = LoadImage("sprites/pipe-green.png");
        ImageFlipVertical(ref imagePipeUp);
        this.textureUp = LoadTextureFromImage(imagePipeUp);

        UnloadImage(imagePipe);
        UnloadImage(imagePipeUp);

        for (int index = 0; index < 4; index++) {
            Pipe pipe = new Pipe(this.textureDown, this.textureUp, posX + index * 150);
            this.pipeList.Add(pipe);
        }
    }

    public void Update(Game game) {
        
        Pipe firstPipe = this.pipeList.First();
        if (firstPipe.posX < -50) {
            firstPipe.posX = this.pipeList.Last().posX + 160;

            // Move first to final position in the list
            this.pipeList.Remove(firstPipe);
            firstPipe.RandomPosY();
            firstPipe.passed = false;
            this.pipeList.Add(firstPipe);
        }

        Bird bird = game.bird;

        foreach (Pipe pipe in this.pipeList) {

            // Check collision with Bird
            if (!pipe.passed && bird.posX > (pipe.posX)) {
                game.score += 1;
                pipe.passed = true;
            }

            pipe.Update();
        }
    }

    public bool checkCollision(Bird bird) {
        foreach (Pipe pipe in this.pipeList) {
            
        }
        return false;
    }
}