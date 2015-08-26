namespace FruitWarGame.GameObjects
{
    using FruitWarGame.Misc;
    using FruitWarGame.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class GameObject : IRenderable, ICollidable
    {
        protected Position position;
        protected char[,] body;
        protected bool eaten = false;

        public GameObject(Position initialPosition, char[,] objectBody, ConsoleColor color = ConsoleColor.DarkGray)
        {
            this.position = initialPosition;
            this.body = this.CopyGridBody(objectBody);
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            protected set
            {
                this.position = new Position(value.Row, value.Col);
            }
        }

        public bool IsEaten
        {
            get
            {
                return this.eaten;
            }

            set
            {
                this.eaten = value;
            }
        }

        private char[,] CopyGridBody(char[,] gridToCopy)
        {
            int rows = gridToCopy.GetLength(0);
            int cols = gridToCopy.GetLength(1);
            char[,] copiedGrid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copiedGrid[i, j] = gridToCopy[i, j];
                }
            }

            return copiedGrid;
        }

        public char[,] GetImage()
        {
            return CopyGridBody(body);
        }

        public abstract void Move();

        public virtual void Collide(GameObject obj)
        {
            this.IsEaten = true;
        }
    }
}
