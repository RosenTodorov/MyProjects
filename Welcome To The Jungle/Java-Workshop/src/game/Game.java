package game;

import display.Display;
import game.players.Dagger;
import game.players.Player;
import game.players.Enemy;
import gfx.Assets;
import gfx.ImageLoader;
import states.*;

import java.awt.*;
import java.awt.image.BufferStrategy;
import java.awt.image.BufferedImage;

public class Game implements Runnable{
    private Display display;
    public int width, height;
    public String title;

    private boolean running = false;
    private Thread thread;

    private InputHandler inputHandler;
    private BufferStrategy bs;
    private Graphics g;

    private BufferedImage img;

    //Testing
    public static Player pesho;
    public static  Enemy enemy;
    private Dagger weapon;

    //States
    private State gameState;
    private State menuState;
    private State settingsState;

    public static Rectangle bullets, blood;

    public Game(String title, int width, int height) {
        this.width = width;
        this.height = height;
        this.title = title;
    }

    //Initializes all the graphics and it will get
    //everything ready for our game
    private void init() {
        //Initializing a new display.Display object
        Assets.init();
        display = new Display(this.title, this.width, this.height);
        this.pesho = new Player(200, 370, 40);
        this.weapon = new Dagger(590, 380, 45, 31);
        this.enemy = new Enemy(630, 380);

        img = ImageLoader.loadImage("/textures/bckg.jpg");

        this.inputHandler = new InputHandler(this.display);

        //Initializing all the states
        gameState = new GameState();
        menuState = new MenuState();
        settingsState = new SettingsState();
        //Setting the currentState to gameState because we do not have
        //any more states set up
        StateManager.setState(gameState);

        bullets = new Rectangle(20, 30, Player.hitPoints, 10);
        blood = new Rectangle(20, 10, Player.health, 10);
    }

    //The method that will update all the variables
    private void tick() {
        //Checks if a State exists and tick()
        this.pesho.tick();
        this.weapon.tick();

        if (StateManager.getState() != null) {
            StateManager.getState().tick();
        }
        if(pesho.Intersects(this.weapon.boundingBox)) {
            if (!Player.goingDown) {
                Player.health -= 20;
            }
            if (Player.health == 0) {
                System.out.print("Your soldier is dead !!!");
                stop();
            }
        } else if (Player.hitPoints == 0){
            System.out.print("Your enemy is dead !!!");
            stop();
        }
    }

    //The method that will draw everything on the canvas
    private void render() {
        //Setting the bufferStrategy to be the one used in our canvas
        //Gets the number of buffers that the canvas should use.
        this.bs = display.getCanvas().getBufferStrategy();
        //If our bufferStrategy doesn't know how many buffers to use
        //we create some manually
        if (bs == null) {
            //Create 2 buffers
            display.getCanvas().createBufferStrategy(2);
            this.bs = display.getCanvas().getBufferStrategy();
            //returns out of the method to prevent errors
            //return;
        }
        //Instantiates the graphics related to the bufferStrategy
        g = bs.getDrawGraphics();
        //Clear the screen at every frame
        g.clearRect(0, 0, this.width, this.height);
        //Beginning of drawing things on the screen
        g.drawImage(Assets.background, 0, 0, null);

        this.pesho.render(this.g);
        this.weapon.render(this.g);
        this.enemy.render(this.g);

        this.g.fillRect(20, 30, Player.hitPoints, 10);
        g.setColor(Color.red);
        this.g.fillRect(20, 10, Player.health, 10);

        //Checks if a State exists and render()
        if (StateManager.getState() != null){
            StateManager.getState().render(this.g);
        }

        //End of drawing objects

        //Enables the buffer
        bs.show();
        //Shows everything stored in the Graphics object
        g.dispose();
    }

    //Implementing the interface's method
    @Override
    public void run() {
        init();

        //Sets the frames per seconds
        int fps = 30;
        //1 000 000 000 nanoseconds in a second. Thus we measure time in nanoseconds
        //to be more specific. Maximum allowed time to run the tick() and render() methods
        double timePerTick = 1_000_000_000.0 / fps;
        //How much time we have until we need to call our tick() and render() methods
        double delta = 0;
        //The current time in nanoseconds
        long now;
        //Returns the amount of time in nanoseconds that our computer runs.
        long lastTime = System.nanoTime();
        long timer = 0;
        int ticks = 0;

        while (running) {
            //Sets the now variable to the current time in nanoseconds
            now = System.nanoTime();
            //Amount of time passed divided by the max amount of time allowed.
            delta += (now-lastTime) / timePerTick;
            //Adding to the timer the time passed
            timer += now - lastTime;
            //Setting the lastTime with the values of now time after we have calculated the delta
            lastTime = now;

            System.out.println(delta);
            //If enough time has passed we need to tick() and render() to achieve 60 fps
            if (delta >= 1) {
                try {
                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                tick();
                render();
                //Reset the delta
                ticks++;
                delta--;
            }

            if (timer >= 1_000_000_000) {
                System.out.println("Ticks and Frames: " + ticks);
                ticks = 0;
                timer = 0;
            }
        }

        //Calls the stop method to ensure everything has been stopped
        stop();
    }

    //Creating a start method for the Thread to start our game
    //Synchronized is used because our method is working with threads
    //so we ensure ourselves that nothing will go bad
    public synchronized void start() {
        //If the game is running exit the method
        //This is done in order to prevent the game to initialize
        //more than enough threads
        if(running) {
            return;
        }
        //Setting the while-game-loop to run
        running = true;
        //Initialize the thread that will work with "this" class (game.Game)
        thread = new Thread(this);
        //The start method will call start the new thread and it will call
        //the run method in our class
        thread.start();
    }

    //Creating a stop method for the Thread to stop our game
    public synchronized void stop() {
        //If the game is not running exit the method
        //This is done to prevent the game from stopping a
        //non-existing thread and cause errors
        if(!running) {
            return;
        }
        running = false;
        //The join method stops the current method from executing and it
        //must be surrounded in try-catch in order to work
        try {
            thread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
