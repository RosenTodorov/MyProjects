namespace FruitWarGame.GameObjects
{
    using FruitWarGame.GameObjects.Fruits;
    using FruitWarGame.Misc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class Warrior : GameObject
    {
        private PlayerOne playerOne;
        private PlayerTwo playerTwo;
        private int speedPoints;
        private int powerPoints;

        public Warrior(Position position, char[,] body)
            : base(position, body)
        {
        }

        public PlayerOne PlayerOne
        {
            get
            {
                return this.playerOne;
            }

            set
            {
                this.playerOne = value;
            }
        }

        public PlayerTwo PlayerTwo
        {
            get
            {
                return this.playerTwo;
            }

            set
            {
                this.playerTwo = value;
            }
        }

        public int SpeedPoints
        {
            get
            {
                return this.speedPoints;
            }

            set
            {
                this.speedPoints = value;
            }
        }

        public int PowerPoints
        {
            get
            {
                return this.powerPoints;
            }

            set
            {
                this.powerPoints = value;
            }
        }

        public void MoveUp()
        {
            if (this.position.Row > 3)
            {
                this.position.Row--;
            }
        }

        public void MoveDown()
        {
            if (this.position.Row < 10)
            {
                this.position.Row++;
            }
        }

        public void MoveLeft()
        {
            if (this.position.Col > 3)
            {
                this.position.Col--;
            }
        }

        public void MoveRight()
        {
            if (this.position.Col < 10)
            {
                this.position.Col++;
            }
        }

        public override void Collide(GameObject obj)
        {
            if (obj is Apple)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                this.PowerPoints++;
            }
            else if (obj is Pear)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        public override void Move()
        {
        }
    }
}
