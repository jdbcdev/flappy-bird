using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

/*
*
*/
public class Bird {

    private int x,y;
    private int counter = 0;
    private int textureIndex = 0;

    private Texture2D[] textureBird = new Texture2D[3];

    /**
     * Constructor
     */
    public Bird() {
         // Load bird texture
        Image birdUpFlap = LoadImage("sprites/yellowbird-upflap.png");
        Image birdMidFlap = LoadImage("sprites/yellowbird-midflap.png");
        Image birdDownFlap = LoadImage("sprites/yellowbird-downflap.png");
        textureBird[0] = LoadTextureFromImage(birdUpFlap);
        textureBird[1] = LoadTextureFromImage(birdMidFlap);
        textureBird[2] = LoadTextureFromImage(birdDownFlap);

        UnloadImage(birdUpFlap);
        UnloadImage(birdMidFlap);
        UnloadImage(birdDownFlap);
    }

    /*
    * Update bird
    */
    public void Update(int x, int y) {
        this.x = x;
        this.y = y;

        counter ++;

        // Bird flap
        if (counter == 6) {
            textureIndex ++;
            counter = 0;
        }

        if (textureIndex == 3) {
            textureIndex = 0;
        }
        
        DrawTexture(this.textureBird[textureIndex], x, y, Color.White);
    }

    /*
    * Unload bird textures
    */
    public void UnloadTextures() {

        foreach(Texture2D texture in textureBird) {
            UnloadTexture(texture);
        }
    }
}