using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

public class Bird {

    private int x,y;

    private Vector2 position;

    private Texture2D textureBird { get; set;}

    /**
     * Constructor
     */
    public Bird() {
         // Load bird texture
        Image bird = LoadImage("sprites/yellowbird-midflap.png");
        textureBird = LoadTextureFromImage(bird);
        UnloadImage(bird);
    }

    public void update(int x, int y) {
        this.x = x;
        this.y = y;
        DrawTexture(this.textureBird, x, y, Color.White);
    }
}