namespace FruitWarGame.Misc
{
    using FruitWarGame.GameObjects;
    using FruitWarGame.GameObjects.Fruits;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollisionHandler
    {
        public static int totalMovePlayerOne;
        public static int totalMovePlayerTwo;
        public static int curentMovePlayerOne;
        public static int curentMovePlayerTwo;
        public static int totalPowerPlayerOne;
        public static int totalPowerPlayerTwo;

        public static void CollisionCheck(List<GameObject> staticObjects, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            foreach (var obj in staticObjects)
            {
                if (obj is Apple)
                {
                    if ((obj.Position.Row >= playerOne.Position.Row && obj.Position.Row <= playerOne.Position.Row) && (obj.Position.Col >= playerOne.Position.Col &&
                                        obj.Position.Col <= playerOne.Position.Col))
                    {
                        obj.Collide(playerOne);
                        playerOne.Collide(obj);
                        Engine.powerPlayerOne++;
                        totalPowerPlayerOne++;
                    }
                    if ((obj.Position.Row >= playerTwo.Position.Row && obj.Position.Row <= playerTwo.Position.Row) && (obj.Position.Col >= playerTwo.Position.Col &&
                                        obj.Position.Col <= playerTwo.Position.Col))
                    {
                        obj.Collide(playerTwo);
                        playerTwo.Collide(obj);
                        Engine.powerPlayerTwo++;
                        totalPowerPlayerTwo++;
                    }
                }
                else if (obj is Pear)
                {
                    if ((obj.Position.Row >= playerOne.Position.Row && obj.Position.Row <= playerOne.Position.Row) && (obj.Position.Col >= playerOne.Position.Col &&
                                        obj.Position.Col <= playerOne.Position.Col))
                    {
                        obj.Collide(playerOne);
                        playerOne.Collide(obj);
                        curentMovePlayerOne++;               
                    }
                    if ((obj.Position.Row >= playerTwo.Position.Row && obj.Position.Row <= playerTwo.Position.Row) && (obj.Position.Col >= playerTwo.Position.Col &&
                                        obj.Position.Col <= playerTwo.Position.Col))
                    {
                        obj.Collide(playerTwo);
                        playerTwo.Collide(obj);
                        curentMovePlayerTwo++;                     
                    }
                }
                totalMovePlayerOne = curentMovePlayerOne + Engine.movePlayerOne;
                totalMovePlayerTwo = curentMovePlayerTwo + Engine.movePlayerTwo;
            }

            if (playerOne is PlayerOne)
            {
                if ((playerTwo.Position.Row >= playerOne.Position.Row && playerTwo.Position.Row <= playerOne.Position.Row) && (playerTwo.Position.Col >= playerOne.Position.Col &&
                                    playerTwo.Position.Col <= playerOne.Position.Col))
                {
                    playerTwo.Collide(playerOne);
                    playerOne.Collide(playerTwo);
                }
            }
            if (playerTwo is PlayerTwo)
            {
                if ((playerOne.Position.Row >= playerTwo.Position.Row && playerOne.Position.Row <= playerTwo.Position.Row) && (playerOne.Position.Col >= playerTwo.Position.Col &&
                                    playerOne.Position.Col <= playerTwo.Position.Col))
                {
                    playerOne.Collide(playerTwo);
                    playerTwo.Collide(playerOne);
                }
            }
        }
    }
}

 