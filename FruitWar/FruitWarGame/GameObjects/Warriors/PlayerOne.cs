namespace FruitWarGame.GameObjects
{
    using FruitWarGame.Misc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlayerOne : Warrior
    {
        public PlayerOne(Position position)
            : base(position, new char[,] { { '1' } })
        {
        }

        public override void Collide(GameObject obj)
        {

            if (obj is PlayerTwo && Engine.powerPlayerOne < Engine.powerPlayerTwo)
            {
                this.IsEaten = true;
                Console.SetCursorPosition(3, 3);
                Console.Write("                                           ");
                Console.SetCursorPosition(3, 18);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Player 2 wins the game.    ");
                Console.SetCursorPosition(3, 19);
                Console.ForegroundColor = ConsoleColor.White;
                if (WelcomeScreen.gameModeTwo == 1)
                {
                    Console.Write("Turtle with {0} Power; {1} Speed", Engine.powerPlayerTwo, CollisionHandler.totalMovePlayerTwo);
                }
                if (WelcomeScreen.gameModeTwo == 2)
                {
                    Console.Write("Monkey with {0} Power; {1} Speed", Engine.powerPlayerTwo, CollisionHandler.totalMovePlayerTwo);
                }
                if (WelcomeScreen.gameModeTwo == 3)
                {
                    Console.Write("Pigeon with {0} Power; {1} Speed", Engine.powerPlayerTwo, CollisionHandler.totalMovePlayerTwo);
                }
                Console.SetCursorPosition(3, 21);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Do you want to start a rematch? (y/n)");
                Engine.keyMove = true;
            }
            if (obj is PlayerTwo && Engine.powerPlayerOne == Engine.powerPlayerTwo)
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


