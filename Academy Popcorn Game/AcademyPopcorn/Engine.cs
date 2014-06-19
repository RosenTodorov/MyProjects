using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        protected Racket playerRacket;
        private int sleepMilSeconds;

        // repairing the Engine's constructor to taka additional parameter, who moderates the sleep time
        public Engine(IRenderer renderer, IUserInterface userInterface, int sleepMilSeconds)
        {
            this.sleepMilSeconds = sleepMilSeconds;
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddRacket(GameObject obj)
        {
            //TODO: we should remove the previous racket from this.allObjects
            // 3. Removing the rackets from allObjects and staticObjects

            this.playerRacket = obj as Racket;
            this.allObjects.RemoveAll(item => item is Racket); // this line should be as comment if we use multiple rackets
            this.staticObjects.RemoveAll(item => item is Racket);
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerRacketLeft()
        {
            // the following commented lines work when adding multiple rackets
            //foreach (var item in allObjects)
            //{
            //    var newItem = item as Racket;
            //    if(newItem != null)
            //    {
            //        newItem.MoveLeft();
            //    }
            //}
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            // the following commented lines work when adding multiple rackets
            //foreach (var item in allObjects)
            //{
            //    var newItem = item as Racket;
            //    if (newItem != null)
            //    {
            //        newItem.MoveRight();
            //    }
            //}
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(sleepMilSeconds);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}