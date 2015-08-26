namespace FruitWarGame.GameObjects.Fruits
{
    using FruitWarGame.Misc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Fruit : GameObject
    {
        private Apple apples;
        private Pear pears;
        private int speedPoints;
        private int powerPoints;

        public Fruit(Position position, char[,] body)
            : base(position, body)
        {            
        }

        public Apple Apples
        {
            get
            {
                return this.apples;
            }

            set
            {
                this.apples = value;
            }
        }

        public Pear Pears
        {
            get
            {
                return this.pears;
            }

            set
            {
                this.pears = value;
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

        public override void Move()
        {
        }
    }
}