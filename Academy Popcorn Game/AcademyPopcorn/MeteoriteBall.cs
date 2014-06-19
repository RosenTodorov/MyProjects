using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        // 6. Implementing the MeteoriteBall class
        private int lifeInTurns;
        public MeteoriteBall(MatrixCoords topleft, MatrixCoords speed)
            : base(topleft, speed)
        {
            this.lifeInTurns = 3;
        }

        public override void Update()
        {
            base.Update();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> trail = new List<GameObject>();
            trail.Add(new TrailObject(this.topLeft, new char[,] { { '*' } }, this.lifeInTurns));
            return trail;
        }
    }
}