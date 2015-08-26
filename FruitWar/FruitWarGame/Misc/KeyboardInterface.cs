namespace FruitWarGame.Misc
{
    using FruitWarGame.Interfaces;
    using System;
    using System.Linq;

    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInputPlayerOne()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow) && Engine.movePlayerOne > 0 && Engine.keyPlayerOne == true)
                {
                    if (this.OnLeftPressedPlayerOne != null)
                    {
                        this.OnLeftPressedPlayerOne(this, new EventArgs());
                        Engine.movePlayerOne--;
                    }
                }           

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow) && Engine.movePlayerOne > 0 && Engine.keyPlayerOne == true)
                {
                    if (this.OnRightPressedPlayerOne != null)
                    {
                        this.OnRightPressedPlayerOne(this, new EventArgs());
                        Engine.movePlayerOne--;
                    }
                }
      
                if (keyInfo.Key.Equals(ConsoleKey.UpArrow) && Engine.movePlayerOne > 0 && Engine.keyPlayerOne == true)
                {
                    if (this.OnUpPressedPlayerOne != null)
                    {
                        this.OnUpPressedPlayerOne(this, new EventArgs());
                        Engine.movePlayerOne--;
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.DownArrow) && Engine.movePlayerOne > 0 && Engine.keyPlayerOne == true)
                {
                    if (this.OnDownPressedPlayerOne != null)
                    {
                        this.OnDownPressedPlayerOne(this, new EventArgs());
                        Engine.movePlayerOne--;
                    }               
                }
            }
        }

        public void ProcessInputPlayerTwo()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow) && Engine.movePlayerTwo > 0 && Engine.keyPlayerTwo == true)
                {
                    if (this.OnLeftPressedPlayerTwo != null)
                    {
                        this.OnLeftPressedPlayerTwo(this, new EventArgs());
                        Engine.movePlayerTwo--;
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow) && Engine.movePlayerTwo > 0 && Engine.keyPlayerTwo == true)
                {
                    if (this.OnRightPressedPlayerTwo != null)
                    {
                        this.OnRightPressedPlayerTwo(this, new EventArgs());
                        Engine.movePlayerTwo--;
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.UpArrow) && Engine.movePlayerTwo > 0 && Engine.keyPlayerTwo == true)
                {
                    if (this.OnUpPressedPlayerTwo != null)
                    {
                        this.OnUpPressedPlayerTwo(this, new EventArgs());
                        Engine.movePlayerTwo--;
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.DownArrow) && Engine.movePlayerTwo > 0 && Engine.keyPlayerTwo == true)
                {
                    if (this.OnDownPressedPlayerTwo != null)
                    {
                        this.OnDownPressedPlayerTwo(this, new EventArgs());
                        Engine.movePlayerTwo--;
                    }
                }
            }
        }
        public event EventHandler OnLeftPressedPlayerOne;

        public event EventHandler OnRightPressedPlayerOne;

        public event EventHandler OnUpPressedPlayerOne;

        public event EventHandler OnDownPressedPlayerOne;


        public event EventHandler OnLeftPressedPlayerTwo;

        public event EventHandler OnRightPressedPlayerTwo;

        public event EventHandler OnUpPressedPlayerTwo;

        public event EventHandler OnDownPressedPlayerTwo;
    }
}