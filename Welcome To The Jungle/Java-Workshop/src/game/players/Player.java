package game.players;

import gfx.Assets;
import gfx.SpriteSheet;

import java.awt.*;

public class Player {
    private int x, y;
    public static int hitPoints;
    private SpriteSheet img;
    private SpriteSheet img1;
    private int velocity;
    private int width, height;
    public static int health;
    private int column = 120;
    private int row = 0;

    public Rectangle boundingBox;

    public static boolean goingDown;
    public static boolean goingLeft;
    public static boolean goingRight;
    public static boolean goingFire;

    public Player(int x, int y, int hitPoints) {
        goingRight = true;
        this.x = 200;
        this.y = 370;
        this.hitPoints = 40;
        this.img = Assets.player;
        this.img1 = Assets.player1;
        this.width = 51;
        this.height = 70;
        this.health = 100;
        this.velocity = 10; // s kakva skorost 6te se dviji 2 px
        this.boundingBox = new Rectangle(x, y, this.width, this.height);

        goingDown = false;
        goingLeft = false;
        goingRight = false;
        goingFire = false;
    }

    public int getHealth() {
        return this.health;
    }

    //Checks if the player intersects with something
    public boolean Intersects(Rectangle r) {
        if(this.boundingBox.contains(r) || r.contains(this.boundingBox)) {
            return true;
        }
        return false;
    }

    //Update the movement of the player
    public void tick() {
        this.width = 51;
        //Update the bounding box's position
        this.boundingBox.setBounds(this.x, this.y, this.width, this.height);

        if (goingFire) {
            this.hitPoints--;
            if (Player.hitPoints <= 4) {
                Enemy.colEnemy = Enemy.colEnemyDead;
                Enemy.heightEnemy = 70;
            }
            this.width = 1;
            Enemy.rowEnemy = 0;
            Enemy.widthEnemy = 51;
            Enemy.heightEnemy = 120;
            Enemy.yEnemy = 320;

        } else if (goingLeft) {
            this.x -= this.velocity;
            this.column++;
            this.column %= 10;
        } else if (goingRight) {
            this.x += this.velocity;
            this.column++;
            this.column %= 10;
        } else {
            this.column = 0;
            Enemy.heightEnemy = 60;
            Enemy.yEnemy = 380;
            Enemy.rowEnemy = 125;
            if (this.hitPoints <= 4) {
                Enemy.colEnemy = Enemy.colEnemyDead;
                Enemy.heightEnemy = 70;
                Enemy.rowEnemy = 0;
            }
        }
    }

    //Draws the player
    public void render(Graphics g) {
        g.drawImage(this.img.crop(this.column * this.width, this.row, this.width, this.height), this.x, this.y, null);
        if(goingDown){
            g.drawImage(this.img.crop(40, 80, this.width, this.height), this.x, this.y, null);
        } else if(goingFire){
            g.drawImage(this.img1.crop(50, 0, 51, 70), this.x, this.y, null);
        }
    }
}
