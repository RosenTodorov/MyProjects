namespace FruitWarGame.Misc
{
    using System;
    using System.Linq;

    public class WelcomeScreen
    {
        public static int gameModeOne;
        public static int gameModeTwo;

        public static void PrintWelcomeScreen()
        {
            Console.CursorVisible = true;
            //------Set Colors
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            int i = -4;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2 - 4 + ++i);
            Console.Write("FruitWar");

            i++;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 + ++i);

            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 28, Console.WindowHeight / 2 + ++i);
                Console.Write("Player1, please choose a warrior.");
                Console.WriteLine();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 29, Console.WindowHeight / 2 + ++i);
                Console.Write(" Insert 1 for turtle / 2 for monkey / 3 for pigeon: ");
                try
                {
                    gameModeOne = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine();
                    if (gameModeOne < 1 || gameModeOne > 3)
                    {
                        throw new ArgumentException();
                    }
                    break;
                }
                    
                catch (FormatException)
                {
                    Console.WriteLine("            Input can only be 1, 2 or 3 !!!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("            Input can only be 1, 2 or 3 !!!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("            Input can only be 1, 2 or 3 !!!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("            Input can only be 1, 2 or 3 !!!");
                }
                i--;
            }

            i++;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 + ++i);

            while (true)
            {

                Console.SetCursorPosition(Console.WindowWidth / 2 - 28, Console.WindowHeight / 2 + ++i);
                Console.Write("Player2, please choose a warrior.");
                Console.WriteLine();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 29, Console.WindowHeight / 2 + ++i);
                Console.Write(" Insert 1 for turtle / 2 for monkey / 3 for pigeon: ");
                try
                {
                    gameModeTwo = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine();
                    if (gameModeTwo < 1 || gameModeTwo > 3)
                    {
                        throw new ArgumentException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("            Input can only be 1, 2 or 3 !!!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("            Input can only be 1, 2 or 3 !!!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("            Input can only be 1, 2 or 3 !!!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("            Input can only be 1, 2 or 3 !!!");
                }
                i--;
            }

            i++;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 + ++i);

            Console.WriteLine("                             ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + ++i);
            Console.WriteLine();
            Console.Write("            When you are ready, press any key to start the game: ");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}

