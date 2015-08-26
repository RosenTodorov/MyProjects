namespace FruitWarGame.GameObjects.Fruits
{
    using FruitWarGame.Misc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Apple : Fruit
    {     
        public Apple(Position position)
            : base(position, new char[,] {{'A'}})
        {
        }

        public override void Move()
        {            
        }

        public override void Collide(GameObject obj)
        {
            this.IsEaten = true;
        }
    }
}
