using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        // 10. Implementing the ExplodingBlock class, connected with the Shrapnel class (which objects are initiated after explosion)
        private const char symbol = 'B';
        public new const string CollisionGroupString = "explodingBlock";
        private bool isHit = false;
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.isHit = true;
            ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (isHit)
            {
                List<GameObject> shrapnells = new List<GameObject>();
                shrapnells.Add(new Shrapnel(topLeft, new MatrixCoords(-1, -1)));
                shrapnells.Add(new Shrapnel(topLeft, new MatrixCoords(-1, 0)));
                shrapnells.Add(new Shrapnel(topLeft, new MatrixCoords(-1, 1)));
                shrapnells.Add(new Shrapnel(topLeft, new MatrixCoords(0, 1)));
                shrapnells.Add(new Shrapnel(topLeft, new MatrixCoords(1, 1)));
                shrapnells.Add(new Shrapnel(topLeft, new MatrixCoords(1, 1)));
                shrapnells.Add(new Shrapnel(topLeft, new MatrixCoords(1, -1)));
                shrapnells.Add(new Shrapnel(topLeft, new MatrixCoords(0, -1)));

                return shrapnells;
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}
