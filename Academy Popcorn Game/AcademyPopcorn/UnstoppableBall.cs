using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        // 8. Implementing the Unstoppableball class
        private const char symbol = 'O';
        public new const string CollisionGroupString = "unstoppableBall";
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block" || otherCollisionGroupString == "unpassableBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            List<string> collisionObjects = collisionData.hitObjectsCollisionGroupStrings;
            foreach (var item in collisionObjects)
            {
                if (item.Equals(UnpassableBlock.CollisionGroupString) || item.Equals(Racket.CollisionGroupString))
                {
                    base.RespondToCollision(collisionData);
                }
            }
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }
    }
}
