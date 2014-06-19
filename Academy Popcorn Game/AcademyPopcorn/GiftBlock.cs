using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        // 12. Implementing GiftBlock class
        public const char GiftBlockSymbol = 'G';

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = GiftBlockSymbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<Gift> gift = new List<Gift>();
                gift.Add(new Gift(topLeft));
                return gift;
            }
            else
            {
                return new List<Gift>();
            }
        }
    }
}
