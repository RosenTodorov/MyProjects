namespace FruitWarGame.Misc
{
    using FruitWarGame.GameObjects;
    using FruitWarGame.GameObjects.Fruits;
    using FruitWarGame.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Threading;

    public class Engine
    {
        const int startRow = 3;
        const int startCol = 3;
        const int endRow = 11;
        const int endCol = 11;
        private int sleepMilSeconds; 
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<GameObject> staticObjects;
        PlayerOne playerOne;
        PlayerTwo playerTwo;
        Fruit apples;
        Fruit pears;           
        public static int movePlayerOne;
        public static int movePlayerTwo;
        public static int powerPlayerOne;
        public static int powerPlayerTwo;
        public static bool keyPlayerOne = true;
        public static bool keyPlayerTwo = false;
        public static bool keyDrawGame = false;
        public static bool keyMove = false;

        public Engine(IRenderer renderer, IUserInterface userInterface, int sleepMilSeconds)
        {
            this.sleepMilSeconds = sleepMilSeconds;
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.staticObjects = new List<GameObject>();
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is PlayerOne || obj is PlayerTwo)
            {
                this.AddPlayers(obj);
            }
            else
            {
                this.AddStaticObject(obj);
            }
        }

        public void AddPlayers(GameObject obj)
        {
            if (obj is PlayerOne)
            {
                this.playerOne = obj as PlayerOne;
            }
            if (obj is PlayerTwo)
            {
                this.playerTwo = obj as PlayerTwo;
            }
            this.allObjects.Add(obj);
        }

        public void GeneratePlayersOnField()
        {
            Random randomGen = new Random();
            var map = new bool[,] 
                {
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true}
                };

            Warrior playerOne = new PlayerOne(new Position(
                randomGen.Next(startRow, endRow),
                randomGen.Next(startCol, endCol)));

            this.AddPlayers(playerOne);
            map[playerOne.Position.Col - 3, playerOne.Position.Row - 3] = false;

            var position = new Position(
                                    randomGen.Next(0, 8),
                                    randomGen.Next(0, 8));

            while (!IsPositionAvailable(position, map, 3))
            {
                position = new Position(
                                        randomGen.Next(0, 8),
                                        randomGen.Next(0, 8));

            }

            Warrior playerTwo = new PlayerTwo(new Position(
                    position.Row + 3,
                    position.Col + 3));

            this.AddPlayers(playerTwo);
        }

        public void GenerateFruitsOnField()
        {
            Random randomGen = new Random();

            var map = new bool[,] 
                {
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true},
                    {true, true, true, true, true, true, true, true}
                };
            
            GenerateApples(randomGen, 4, map);
            GeneratePears(randomGen, 3, map);
        }

        public void GenerateApples(Random randomGen, int numbers, bool[,] availabilityMap)
        {
            for (int i = 0; i < numbers; i++)
            {
                var position = new Position(
                                    randomGen.Next(0, 8),
                                    randomGen.Next(0, 8));

                if (IsPositionAvailable(position, availabilityMap, 2))
                {
                    apples = new Apple(new Position(position.Row + 3, position.Col + 3));
                    while ((apples.Position.Row >= playerOne.Position.Row && apples.Position.Row <= playerOne.Position.Row) && 
                           (apples.Position.Col >= playerOne.Position.Col && apples.Position.Col <= playerOne.Position.Col) ||
                           (apples.Position.Row >= playerTwo.Position.Row && apples.Position.Row <= playerTwo.Position.Row) &&
                           (apples.Position.Col >= playerTwo.Position.Col && apples.Position.Col <= playerTwo.Position.Col))
                    {
                        apples = new Apple(new Position(position.Row + 3, position.Col + 3));
                    }
                    this.AddStaticObject(apples);
                    availabilityMap[position.Col, position.Row] = false;
                }
                else
                {
                    i--;
                }
            }
        }

        public void GeneratePears(Random randomGen, int numbers, bool[,] availabilityMap)
        {
            for (int i = 0; i < numbers; i++)
            {
                var position = new Position(
                                    randomGen.Next(0, 8),
                                    randomGen.Next(0, 8));

                if (IsPositionAvailable(position, availabilityMap, 2))
                {
                    pears = new Pear(new Position(position.Row + 3, position.Col + 3));
                    while ((pears.Position.Row >= playerOne.Position.Row && pears.Position.Row <= playerOne.Position.Row) && 
                           (pears.Position.Col >= playerOne.Position.Col && pears.Position.Col <= playerOne.Position.Col) ||
                           (pears.Position.Row >= playerTwo.Position.Row && pears.Position.Row <= playerTwo.Position.Row) &&
                           (pears.Position.Col >= playerTwo.Position.Col && pears.Position.Col <= playerTwo.Position.Col))
                    {
                        pears = new Pear(new Position(position.Row + 3, position.Col + 3));
                    }
                    this.AddStaticObject(pears);
                    availabilityMap[position.Col, position.Row] = false;
                }
                else
                {
                    i--;
                }
            }
        }

        private bool IsPositionAvailable(Position position, bool[,] map, int distance)
        {
            var result = true;

            for (int i = position.Col - distance; i < position.Col + distance; i++)
            {
                if (i < 0)
                {
                    i++;
                    continue;
                }
                else if (i >= 8)
                {
                    break;
                }

                for (int j = position.Row - distance; j < position.Row + distance; j++)
                {
                    if (j < 0)
                    {
                        j++;
                        continue;
                    }
                    else if (j >= 8)
                    {
                        break;
                    }

                    result &= map[i, j];
                }
            }

            return result;
        }

        public virtual void Run()
        {
            WelcomeScreen.PrintWelcomeScreen();
            Game();

            while (true)
            {
                System.Threading.Thread.Sleep(sleepMilSeconds);

                foreach (var obj in this.allObjects)
                {
                    obj.Move();
                    this.renderer.EnqueObject(obj);
                }

                if (keyMove == false)
                {
                    if (keyPlayerOne == true)
                    {
                        this.userInterface.ProcessInputPlayerOne();
                    }
                    if (keyPlayerTwo == true)
                    {
                        this.userInterface.ProcessInputPlayerTwo();
                    }
                }

                ScoreDataPrinter();

                CollisionHandler.CollisionCheck(this.staticObjects, this.playerOne, this.playerTwo);

                if (keyDrawGame == false)
                {
                    this.renderer.Render();
                }

                this.allObjects.RemoveAll(obj => obj.IsEaten);
                this.staticObjects.RemoveAll(obj => obj.IsEaten);

                if (movePlayerOne <= 0)
                {
                    keyPlayerOne = false;
                    keyPlayerTwo = true;
                }

                if (movePlayerTwo <= 0)
                {
                    keyPlayerTwo = false;
                    keyPlayerOne = true;
                    Game();
                }
   
                this.renderer.ClearObjectGrid();
            }
        }

        public void Game()
        {
            if (WelcomeScreen.gameModeOne == 1)
            {
                if (keyPlayerOne == true)
                {
                    this.playerOne.SpeedPoints = 1;
                    this.playerOne.PowerPoints = 3;

                    CalculatorPlayerOne();
                }
            }
            if (WelcomeScreen.gameModeTwo == 1)
            {
                if (keyPlayerTwo == false)
                {
                    this.playerTwo.SpeedPoints = 1;
                    this.playerTwo.PowerPoints = 3;

                    CalculatorPlayerTwo();
                }
            }
            if (WelcomeScreen.gameModeOne == 2)
            {
                if (keyPlayerOne == true)
                {
                    this.playerOne.SpeedPoints = 2;
                    this.playerOne.PowerPoints = 2;

                    CalculatorPlayerOne();
                }
            }
            if (WelcomeScreen.gameModeTwo == 2)
            {
                if (keyPlayerTwo == false)
                {
                    this.playerTwo.SpeedPoints = 2;
                    this.playerTwo.PowerPoints = 2;

                    CalculatorPlayerTwo();
                }
            }
            if (WelcomeScreen.gameModeOne == 3)
            {
                if (keyPlayerOne == true)
                {
                    this.playerOne.SpeedPoints = 3;
                    this.playerOne.PowerPoints = 1;

                    CalculatorPlayerOne();
                }
            }
            if (WelcomeScreen.gameModeTwo == 3)
            {
                if (keyPlayerTwo == false)
                {
                    this.playerTwo.SpeedPoints = 3;
                    this.playerTwo.PowerPoints = 1;

                    CalculatorPlayerTwo();
                }
            }
        }

        private void CalculatorPlayerOne()
        {
            this.playerOne.SpeedPoints += CollisionHandler.curentMovePlayerOne;
            CollisionHandler.curentMovePlayerOne = 0;
            movePlayerOne = this.playerOne.SpeedPoints;
            this.playerOne.PowerPoints += CollisionHandler.totalPowerPlayerOne;
            powerPlayerOne = this.playerOne.PowerPoints;
        }

        private void CalculatorPlayerTwo()
        {
            this.playerTwo.SpeedPoints += CollisionHandler.curentMovePlayerTwo;
            CollisionHandler.curentMovePlayerTwo = 0;
            movePlayerTwo = this.playerTwo.SpeedPoints;
            this.playerTwo.PowerPoints += CollisionHandler.totalPowerPlayerTwo;
            powerPlayerTwo = this.playerTwo.PowerPoints;
        }

        public virtual void MovePlayerOneRight()
        {
            this.playerOne.MoveRight();
        }

        public virtual void MovePlayerOneLeft()
        {
            this.playerOne.MoveLeft();
        }

        public virtual void MovePlayerOneUp()
        {
            this.playerOne.MoveUp();
        }

        public virtual void MovePlayerOneDown()
        {
            this.playerOne.MoveDown();
        }

        public virtual void MovePlayerTwoRight()
        {
            this.playerTwo.MoveRight();
        }

        public virtual void MovePlayerTwoLeft()
        {
            this.playerTwo.MoveLeft();
        }

        public virtual void MovePlayerTwoUp()
        {
            this.playerTwo.MoveUp();
        }

        public virtual void MovePlayerTwoDown()
        {
            this.playerTwo.MoveDown();
        }

        private void ScoreDataPrinter()
        {
            Console.SetCursorPosition(3, 18);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Player1: {0} Power; {1} Speed", powerPlayerOne, CollisionHandler.totalMovePlayerOne);
            Console.SetCursorPosition(3, 19);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Player2: {0} Power; {1} Speed", powerPlayerTwo, CollisionHandler.totalMovePlayerTwo);
        }
    }
}



