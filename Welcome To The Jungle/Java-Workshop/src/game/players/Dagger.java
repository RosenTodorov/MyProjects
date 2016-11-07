package game.players;
import gfx.Assets;
import gfx.SpriteSheet;

import java.awt.*;
import java.awt.image.BufferedImage;

/**
 * Created by rosen.todorov on 12.09.2016.
 */
public class Dagger {
    private int x, y, width, height;
    public Rectangle boundingBox;
    private BufferedImage image;

    public Dagger(int x, int y, int width, int height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.boundingBox = new Rectangle(x, y, this.width, this.height);
        this.image = Assets.weapon;
    }

    public void tick() {
        this.boundingBox.setBounds(this.x, this.y, this.width, this.height);
        this.x -=15;
        if (x <= 0){
            this.x = 580;
        }
    }

    public void render(Graphics g) {
        g.drawImage(this.image, this.x, this.y, this.width, this.height, null);
    }
}
