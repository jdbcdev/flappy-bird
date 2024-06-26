using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

/*
*
*/
public class Pipe {

    public const int PIPE_WIDTH = 52;
    public const int PIPE_HEIGHT = 320;
    public const int PIPE_GAP = 100;

    public int posX {get; set;}
    public int posY {get; set;}

    public bool passed {get; set;}
    
    private int firstX;

    private Texture2D textureDown;
    private Texture2D textureUp;

    /*
    * Constructor
    */
    public Pipe(Texture2D textureDown, Texture2D textureUp, int x) {
        this.textureDown = textureDown;
        this.textureUp = textureUp;
        this.posX = x;
        this.firstX = x;
        this.passed = false;
        this.RandomPosY();
    }

    public void Update() {
        this.posX -= 1;

        DrawTexture(this.textureDown, this.posX, this.posY, Color.White);

        DrawTexture(this.textureUp, this.posX, this.posY - PIPE_HEIGHT - PIPE_GAP, Color.White);
    } 

    public void RandomPosY() {
        Random random = new Random();
        this.posY = random.Next(170, 300);
    }

    public bool Collide(Bird bird) {

        Rectangle rec1 = new Rectangle(this.posX, this.posY, PIPE_WIDTH, PIPE_HEIGHT);
        Rectangle rec2 = new Rectangle(this.posX, this.posY - PIPE_HEIGHT - PIPE_GAP, PIPE_WIDTH, PIPE_HEIGHT);

        Rectangle rectBird = new Rectangle(bird.posX, bird.posY, bird.BIRD_WIDTH, bird.BIRD_HEIGHT);

        return CheckCollisionRecs(rec1, rectBird) || CheckCollisionRecs(rec2, rectBird);
    }
}