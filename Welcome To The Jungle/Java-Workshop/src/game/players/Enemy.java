package game.players;

import gfx.Assets;
import gfx.SpriteSheet;

import java.awt.*;

/**
 * Created by rosen.todorov on 16.09.2016.
 */
public class Enemy {
    private int x, y;
    private SpriteSheet img2;
    private int width, height;
    public static int colEnemy = 60;
    public static  int rowEnemy = 125;
    public static  int colEnemyDead = 230;
    public static  int heightEnemy = 60;
    public static  int widthEnemy = 51;
    public static  int yEnemy = 380;

    public Rectangle boundingBox;

    public static boolean goingDown;
    public static boolean goingLeft;
    public static boolean goingRight;
    public static boolean goingFire;

    public Enemy(int x, int y) {
        this.x = 200;
        this.y = 370;
        this.img2 = Assets.enemy;
        this.width = 51;
        this.height = 70;
        this.boundingBox = new Rectangle(x, y, this.width, this.height);

        goingDown = false;
        goingLeft = false;
        goingRight = false;
        goingFire = false;
    }

    //Checks if the player intersects with something
    public boolean Intersects(Rectangle r) {
        if(this.boundingBox.contains(r) || r.contains(this.boundingBox)) {
            return true;
        }
        return false;
    }

    //Draws the player
    public void render(Graphics g) {
        g.drawImage(this.img2.crop(this.colEnemy, this.rowEnemy, this.widthEnemy, this.heightEnemy), 630, this.yEnemy, null);
    }
}


