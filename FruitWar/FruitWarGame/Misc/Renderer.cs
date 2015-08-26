namespace FruitWarGame.Misc
{
    using FruitWarGame.GameObjects;
    using FruitWarGame.Interfaces;
    using System;
    using System.Linq;
    using System.Text;

    public class Renderer : IRenderer
    {
        private int gameFieldRows;
        private int gameFieldCols;
        private char[,] objectBody;

        public Renderer(int rows, int cols)
        {
            this.objectBody = new char[rows, cols];
            this.gameFieldRows = this.objectBody.GetLength(0);
            this.gameFieldCols = this.objectBody.GetLength(1);
            this.ClearObjectGrid();
        }

        public void EnqueObject(GameObject obj)
        {
            char[,] objectImage = obj.GetImage();
            int objectHeight = objectImage.GetLength(0);
            int objectWidth = objectImage.GetLength(1);
            Position objectPosition = obj.Position;

            for (int rows = obj.Position.Row; rows < objectPosition.Row + objectHeight; rows++)
            {
                for (int cols = obj.Position.Col; cols < objectPosition.Col + objectWidth; cols++)
                {
                    if (rows >= 0 && rows < gameFieldRows && cols >= 0 && cols < gameFieldCols)
                    {
                        objectBody[rows, cols] = objectImage[rows - objectPosition.Row, cols - objectPosition.Col];
                    }
                }
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(3, 4);
            var scene = new StringBuilder();

            for (int row = 0; row < this.gameFieldRows; row++)
            {
                for (int col = 0; col < this.gameFieldCols; col++)
                {
                    scene.Append(this.objectBody[row, col]);
                }

                scene.Append(Environment.NewLine);
            }

            Console.OutputEncoding = new System.Text.UnicodeEncoding();
            Console.WriteLine(scene.ToString());
        }

        public virtual void ClearObjectGrid()
        {
            for (int row = 0; row < this.gameFieldRows; row++)
            {
                for (int col = 0; col < this.gameFieldCols; col++)
                {
                    objectBody[row, col] = ' ';
                }
            }
        }
    }
}
