using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Shrapnel : MovingObject
    {
        public Shrapnel(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '^' } }, speed)
        {
        }

        public override void Update()
        {
            base.Update();
            IsDestroyed = true;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }
    }
}
