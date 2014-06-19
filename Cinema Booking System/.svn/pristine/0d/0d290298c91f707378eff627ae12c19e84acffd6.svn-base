using System;

namespace CinemaBookingSystem
{
    public class Seat
    {
        private int row;
        private int seatNo;

        public const int maxRows = 50;
        public const int maxSeats = 50;

        public Seat(int row, int seatNo)
        {
            this.Row = row;
            this.SeatNo = seatNo;
        }

        public int Row
        {
            get { return this.row; }
            protected set
            {
                ValidationUtil.ValidateRange<int>(0, maxRows, value, String.Format("Number of rows should be from 1 to {0}", maxRows));
                this.row = value;
            }
        }

        public int SeatNo
        {
            get { return this.seatNo; }
            protected set
            {
                this.seatNo = value;
                ValidationUtil.ValidateRange<int>(0, maxSeats, value, String.Format("Number of seats should be from 1 to {0}", maxSeats));
            }
        }

        public override string ToString()
        {
            return seatNo.ToString();
        }
    }
}
