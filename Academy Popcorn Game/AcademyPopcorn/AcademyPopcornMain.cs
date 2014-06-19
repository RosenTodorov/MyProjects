using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            // 1. adding ceiling and left/right walls
            for (int i = startRow - 1; i < WorldRows; i++)
            {
                UnpassableBlock newIndBlockLeft = new UnpassableBlock(new MatrixCoords(i, startCol - 1));
                UnpassableBlock newIndBlockRight = new UnpassableBlock(new MatrixCoords(i, endCol));
                engine.AddObject(newIndBlockRight);
                engine.AddObject(newIndBlockLeft);
            }
            for (int i = startCol - 1; i <= endCol; i++)
            {
                UnpassableBlock newTopBlock = new UnpassableBlock(new MatrixCoords(startRow - 2, i));
                engine.AddObject(newTopBlock);
            }


            for (int i = startCol; i < endCol / 2; i++)
            {
                Block currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }
            for (int i = endCol / 2; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            TrailObject trailer = new TrailObject(new MatrixCoords(WorldRows / 2, WorldCols / 2), new char[,] { { 'H', 'E', 'L', 'L', 'O' } }, 5);
            engine.AddObject(trailer);

            // the ball is here 
            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 3), new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            // the racket - moves with A/D and space shoots
            Racket theRacket = new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);
        }
        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootingRacketEngine gameEngine = new ShootingRacketEngine(renderer, keyboard, 300);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
