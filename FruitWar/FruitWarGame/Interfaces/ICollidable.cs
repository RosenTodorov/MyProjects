namespace FruitWarGame.Interfaces
{
    using FruitWarGame.GameObjects;
    using System;
    using System.Linq;

    public interface ICollidable
    {
        void Collide(GameObject obj);
    }
}
