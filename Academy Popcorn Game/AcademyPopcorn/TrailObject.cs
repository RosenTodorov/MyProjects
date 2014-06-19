using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // 5. Implementing the TrailObject class
    public class TrailObject : GameObject
    {
        private int lifeTime;

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime)
            : base(topLeft, body)
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            lifeTime--;
            if (lifeTime == 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
