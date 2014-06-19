using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class BaseTicket : Ticket, IPriceCalculator
    {
                const int PercentageDiscount = 0;

        public BaseTicket(Movie movie, decimal price)
            : base(movie, price)
        {
        }

        public override void CalculatePrice()
        {
            decimal discount = price * (PercentageDiscount / 100);
            this.Price = price - discount;
        }
    }
}
