namespace FruitWarGame
{
    using FruitWarGame.GameObjects;
    using FruitWarGame.Interfaces;
    using FruitWarGame.Misc;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class FruitWarMain 
    {
        const int WorldRows = 55;
        const int WorldCols = 30;
        const int startRow = 3;
        const int startCol = 3;
        const int endRow = 11;
        const int endCol = 11;

        public static void Main(string[] args)
        {
            IUserInterface keyboard = new KeyboardInterface();
            IRenderer renderer = new Renderer(WorldRows - 44, WorldCols - 18);

            Engine engine = new Engine(renderer, keyboard, 300);

            for (int i = startRow; i < endRow; i++)
            {
                for (int j = startCol; j < endCol; j++)
                {
                    Grid newGrid = new Grid(new Position(i, j));
                    engine.AddObject(newGrid);
                }
            }

            engine.GeneratePlayersOnField();
            Thread.Sleep(80);
            engine.GenerateFruitsOnField();

            HandlePlayerOneControls(keyboard, engine);
            HandlePlayerTwoControls(keyboard, engine);

            engine.Run();
        }

        private static void HandlePlayerOneControls(IUserInterface keyboard, Engine engine)
        {
            keyboard.OnUpPressedPlayerOne += (sender, eventInfo) =>
            { 
                Console.SetCursorPosition(startRow, startCol);
                Console.WriteLine("Player1, make a move please!");
                engine.MovePlayerOneUp();
            };

            keyboard.OnDownPressedPlayerOne += (sender, eventInfo) =>
            {
                Console.SetCursorPosition(startRow, startCol);
                Console.WriteLine("Player1, make a move please!");
                engine.MovePlayerOneDown();
            };

            keyboard.OnLeftPressedPlayerOne += (sender, eventInfo) =>
            {
                Console.SetCursorPosition(startRow, startCol);
                Console.WriteLine("Player1, make a move please!");
                engine.MovePlayerOneLeft();
            };

            keyboard.OnRightPressedPlayerOne += (sender, eventInfo) =>
            {
                Console.SetCursorPosition(startRow, startCol);
                Console.WriteLine("Player1, make a move please!");     
                engine.MovePlayerOneRight();
            };
        }

        private static void HandlePlayerTwoControls(IUserInterface keyboard, Engine engine)
        {
            keyboard.OnUpPressedPlayerTwo += (sender, eventInfo) =>
            {
                Console.SetCursorPosition(startRow, startCol);
                Console.WriteLine("Player2, make a move please!");
                engine.MovePlayerTwoUp();
            };

            keyboard.OnDownPressedPlayerTwo += (sender, eventInfo) =>
            {
                Console.SetCursorPosition(startRow, startCol);
                Console.WriteLine("Player2, make a move please!");
                engine.MovePlayerTwoDown();
            };

            keyboard.OnLeftPressedPlayerTwo += (sender, eventInfo) =>
            {
                Console.SetCursorPosition(startRow, startCol);
                Console.WriteLine("Player2, make a move please!");
                engine.MovePlayerTwoLeft();
            };

            keyboard.OnRightPressedPlayerTwo += (sender, eventInfo) =>
            {
                Console.SetCursorPosition(startRow, startCol);
                Console.WriteLine("Player2, make a move please!");
                engine.MovePlayerTwoRight();
            };
        }
    }
}
