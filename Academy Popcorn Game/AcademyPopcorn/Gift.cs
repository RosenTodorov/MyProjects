using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // 11. Implementing the Gift class
    public class Gift : MovingObject
    {
        public const char giftSymbo = '♥';
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { giftSymbo } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var item in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (item.Equals(Racket.CollisionGroupString))
                {
                    this.IsDestroyed = true;
                }
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                ShootingRacket shooter = new ShootingRacket(new MatrixCoords(topLeft.Row + 1, topLeft.Col - 3), 6);
                List<GameObject> shooterList = new List<GameObject>();
                shooterList.Add(shooter);
                return shooterList;
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}