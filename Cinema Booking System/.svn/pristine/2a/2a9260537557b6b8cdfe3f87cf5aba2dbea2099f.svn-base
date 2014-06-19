using System.Collections.Generic;

namespace CinemaBookingSystem
{
    public class CinemaHallList
    {
        List<CinemaHall> halls;

        public CinemaHallList()
        {
            halls = new List<CinemaHall>();
        }

        public CinemaHall this[int index]
        {
            get { return this.halls[index]; }
            set { this.halls[index] = value; }
        }

        public void LoadHalls()
        {
            halls.Add(new CinemaHall("1", 10, 19));
            halls.Add(new CinemaHall("2", 9, 17));
            halls.Add(new CinemaHall("3", 8, 15));
        }
    }
}
