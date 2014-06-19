using System;
using System.Windows;
using System.Windows.Controls;

namespace CinemaBookingSystem
{
    public class Show
    {
        private CinemaHall hall;
        private Movie movie;
        private bool[,] seatReserved;
        public DayOfWeek Date { get; set; }
        public Time Time { get; set; }

        public Show(CinemaHall hall, Movie movie, DayOfWeek date, Time time)
        {
            this.Hall = hall;
            this.Movie = movie;
            this.seatReserved = new bool[Hall.Rows, Hall.Seats];
            this.Date = date;
            this.Time = time;
        }

        public void ReserveSeat(Seat seat)
        {
            this.seatReserved[seat.Row, seat.SeatNo] = true;
        }

        public void CancelSeatReservation(Seat seat)
        {
            this.seatReserved[seat.Row, seat.SeatNo] = false;
        }

        public bool IsSeatReserved(Seat seat)
        {
            return this.seatReserved[seat.Row, seat.SeatNo];
        }

        public CinemaHall Hall
        {
            get { return this.hall; }
            set { this.hall = value; }
        }

        public Movie Movie
        {
            get { return this.movie; }
            set { this.movie = value; }
        }

    }
}
