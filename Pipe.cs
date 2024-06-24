using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

/*
*
*/
public class Pipe {

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

    /*
    *
    */
    public void Update() {
        this.posX -= 1;

        DrawTexture(this.textureDown, this.posX, this.posY, Color.White);

        DrawTexture(this.textureUp, this.posX, this.posY - 420, Color.White);
    } 

    /*
    *
    */
    public void RandomPosY() {
        Random random = new Random();
        this.posY = random.Next(170, 300);
    }
}