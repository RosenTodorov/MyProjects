namespace FruitWarGame.Interfaces
{
    using FruitWarGame.GameObjects;
    using System;
    using System.Linq;

    public interface IRenderer
    {
        void EnqueObject(GameObject obj);

        void Render();

        void ClearObjectGrid();
    }
}
