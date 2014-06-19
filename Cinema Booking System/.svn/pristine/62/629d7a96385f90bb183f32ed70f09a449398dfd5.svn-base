
namespace CinemaBookingSystem
{
   public class Date
    {
        private uint month;
        private uint day;
        public uint Year { get; set; }

        public Date(uint day, uint month, uint year)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }


        public uint Month
        {
            get { return this.month; }
            set
            {
                ValidationUtil.ValidateRange<uint>(1, 12, value, "Month should be between 1 and 12");
                this.month = value;
            }
        }

        public uint Day
        {
            get { return this.month; }
            set
            {
                ValidationUtil.ValidateDate(Year, Month, value, "Invalid date");
                this.day = value;
            }
        }

        public override string ToString()
        {
            return Day + "." + Month + "." + Year;
        }
    }
}
