namespace FruitWarGame.GameObjects
{
    using FruitWarGame.Misc;
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class Grid : GameObject
    {
        public Grid(Position position)
            : base(position, new char[,] {{'-'}})
        {      
        }
        public override void Move()
        {
        }
    }
}
