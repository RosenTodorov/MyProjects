namespace FruitWarGame.Misc
{
    using System;
    using System.Linq;

    public abstract class DrawGame
    {
        public static void PrintDrawGame()
        {
            Console.Clear();
            Console.SetCursorPosition(3, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Draw game.              ");
            Console.SetCursorPosition(3, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Do you want to start a rematch? (y/n) ");
        }
    }
}
