namespace FruitWarGame.Interfaces
{
    using System;
    using System.Linq;

    public interface IUserInterface
    {
        event EventHandler OnLeftPressedPlayerOne;

        event EventHandler OnRightPressedPlayerOne;

        event EventHandler OnUpPressedPlayerOne;

        event EventHandler OnDownPressedPlayerOne;


        event EventHandler OnLeftPressedPlayerTwo;

        event EventHandler OnRightPressedPlayerTwo;

        event EventHandler OnUpPressedPlayerTwo;

        event EventHandler OnDownPressedPlayerTwo;

        void ProcessInputPlayerOne();

        void ProcessInputPlayerTwo();
    }
}