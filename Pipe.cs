using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

/*
*
*/
public class Pipe {

    private int firstX;
    public int posX {get; set;}
    public int posY {get; set;}

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

        Random random = new Random();
        this.posY = random.Next(170, 300);
    }

    /*
    *
    */
    public void Update() {
        this.posX -= 1;

        DrawTexture(this.textureDown, this.posX, this.posY, Color.White);

        DrawTexture(this.textureUp, this.posX, this.posY - 420, Color.White);
    }
}