using System;
using System.Collections.Generic;

namespace CinemaBookingSystem
{
    public struct MovieDate
    {
        DayOfWeek dayOfWeek;
        List<Time> showTime;

        public List<Time> ShowTime
        {
            get { return showTime; }
            set
            {
                this.showTime = value;
            }
        }

        public DayOfWeek DayOfWeek
        {
            get { return dayOfWeek; }
            set
            {
                this.dayOfWeek = value;
            }
        }
    }
}
