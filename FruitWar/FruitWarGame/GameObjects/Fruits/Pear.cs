namespace FruitWarGame.GameObjects.Fruits
{
    using FruitWarGame.Misc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Pear : Fruit
    {
        public Pear(Position position)
            : base(position, new char[,] {{'P'}})
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

