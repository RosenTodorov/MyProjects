
namespace CinemaBookingSystem
{
    class StudentsTicket : Ticket, IPriceCalculator
    {
        const int PercentageDiscount = 20;

        public StudentsTicket(Movie movie, decimal price)
            : base(movie, price)
        {
        }

        public override void CalculatePrice()
        {
            decimal descount = price * (PercentageDiscount / 100);
            this.Price = price - descount;
        }
    }
}
