package gfx;

import java.awt.image.BufferedImage;

public class Assets {
    public static BufferedImage background, weapon;
    public static SpriteSheet player, player1, enemy;

    //Loads every resource needed for the game

    public static void init() {
        player = new SpriteSheet(ImageLoader.loadImage("/textures/player.png"));
        player1 = new SpriteSheet(ImageLoader.loadImage("/textures/player1.png"));
        enemy = new SpriteSheet(ImageLoader.loadImage("/textures/enemy.png"));
        weapon = ImageLoader.loadImage("/textures/weapon.png");
        background = ImageLoader.loadImage("/textures/bckg.jpg");
    }
}
