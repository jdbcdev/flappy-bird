using Raylib_cs;
using static Raylib_cs.Raylib;

public class PipeManager {

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

    public void Update() {
        
        Pipe firstPipe = this.pipeList.First();
        if (firstPipe.posX < -50) {
            firstPipe.posX = this.pipeList.Last().posX + 160;

            // Move first to final position in the list
            this.pipeList.Remove(firstPipe);
            this.pipeList.Add(firstPipe);
        }

        foreach (Pipe pipe in this.pipeList) {
            pipe.Update();
        }
    }

    public void UnloadTexture() {

        //UnloadTexture(this.texture);
    }
}