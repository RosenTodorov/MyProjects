namespace FruitWarGame.GameObjects
{
    using FruitWarGame.Misc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlayerTwo : Warrior
    {
        public PlayerTwo(Position position)
            : base(position, new char[,] {{'2'}})
        {
        }

        public override void Collide(GameObject obj)
        {
            if (obj is PlayerOne && Engine.powerPlayerOne > Engine.powerPlayerTwo)
            {
                this.IsEaten = true;
                Console.SetCursorPosition(3, 3);
                Console.Write("                                           ");
                Console.SetCursorPosition(3, 18);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Player 1 wins the game.   ");
                Console.SetCursorPosition(3, 19);
                Console.ForegroundColor = ConsoleColor.White;
                if (WelcomeScreen.gameModeOne == 1)
                {
                    Console.Write("Turtle with {0} Power; {1} Speed", Engine.powerPlayerOne, CollisionHandler.totalMovePlayerOne);
                }
                if (WelcomeScreen.gameModeOne == 2)
                {
                    Console.Write("Monkey with {0} Power; {1} Speed", Engine.powerPlayerOne, CollisionHandler.totalMovePlayerOne);
                }
                if (WelcomeScreen.gameModeOne == 3)
                {
                    Console.Write("Pigeon with {0} Power; {1} Speed", Engine.powerPlayerOne, CollisionHandler.totalMovePlayerOne);
                }
                Console.SetCursorPosition(3, 21);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Do you want to start a rematch? (y/n)");
                Engine.keyMove = true;
            }

            if (obj is PlayerOne && Engine.powerPlayerTwo == Engine.powerPlayerOne)
            {
                Engine.keyDrawGame = true;
                DrawGame.PrintDrawGame();   
            } 
        }

        public override void Move()
        {
        }
    }
}
