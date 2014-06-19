using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace CinemaBookingSystem
{
    public partial class ReservationWindow : Window
    {
        Show show;
        List<Seat> pressedSeats = new List<Seat>();
        ushort ticketsCount;
        bool canSelect = false;

        public ReservationWindow(Show show)
        {
            InitializeComponent();
            this.show = show;
            PopulateWithCells();
            reservationButton.IsEnabled = false;
            MovieInfo.Content = string.Format("{0}, {1}, {2:00}:{3:00}, hall {4}", show.Movie.Name, show.Date, show.Time.Hours, show.Time.Minutes, show.Hall.Id);
        }

        private void PopulateWithCells()
        {
            List<List<Button>> lsts = new List<List<Button>>();

            for (int i = 1; i < show.Hall.Rows; i++)
            {
                lsts.Add(new List<Button>());

                for (int j = 1; j < show.Hall.Seats; j++)
                {
                    Seat item = new Seat(i, j);
                    Button btn = CreateSeatButton(item);

                    lsts[i - 1].Add(btn);
                }
            }
            lst.ItemsSource = lsts;
        }

        private Button CreateSeatButton(Seat item)
        {
            Button btn = new Button();
            btn.Width = 28;
            btn.Height = 28;
            btn.Content = item;
            btn.Margin = new Thickness(3, 3, 3, 3);
            btn.Style = this.FindResource("SeatButtonStyle") as Style;
            btn.Click += new RoutedEventHandler(ButtonSeat_Click);

            if (show.IsSeatReserved(item) == true)
            {
                btn.IsEnabled = false;
            }

            return btn;
        }

        private void ButtonSeat_Click(object sender, RoutedEventArgs e)
        {

            if (canSelect == false)
            {
                MessageBox.Show("You should first select how many tickets you want to reserve.");
                return;
            }

            Button _btn = sender as Button;

            Seat value = (Seat)_btn.Content;

            if (pressedSeats.Contains(value))
            {
                _btn.Style = this.FindResource("SeatButtonStyle") as Style;
                pressedSeats.Remove(value);
                return;
            }

            if (ticketsCount <= pressedSeats.Count)
            {
                MessageBox.Show("You cannot reserve more tickets. For reserving more tickets change the amount of tickets or unmark some of the green seats by left click on them");
                return;
            }

            pressedSeats.Add(value);
            _btn.Style = this.FindResource("MyButtonStyle") as Style;

        }

        private void ReservationButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Seat seat in pressedSeats)
            {
                this.show.ReserveSeat(seat);
            }

            MessageBox.Show(String.Format("You have reserved {0} tickets. In order to receive them you should go to the cash table at least 15 minutes before the movie start - {1}. You will need to show the following ID to the cashier: {2}", ticketsCount, show.Time, RandomString(10)));

            this.Close();
        }

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random(DateTime.Now.Millisecond);
            char ch;
            for (int i = 0; i < size; i++)
            {
                if (i % 2 == 0)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                }
                else
                {
                    ch = (char)(random.Next(0, 9) + 48);
                }

                builder.Append(ch);
            }

            return builder.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string content = txtBoxTicketsCount.Text;
            if (ValidationUtil.IsTextAllowed(content) == false)
            {
                txtBoxTicketsCount.BorderBrush = Brushes.Red;
                txtBoxTicketsCount.ToolTip = "Only numubers between 1 and 50 allowed.";
                canSelect = false;
                return;
            }

            ushort numberOfTickets = ushort.Parse(content);

            if (numberOfTickets <= 0 || numberOfTickets > 50)
            {
                txtBoxTicketsCount.BorderBrush = Brushes.Red;
                txtBoxTicketsCount.ToolTip = "You cannot reserve more than 50 or less than 1 tickets.";
                canSelect = false;
                return;
            }

            txtBoxTicketsCount.BorderBrush = Brushes.Green;
            ticketsCount = numberOfTickets;
            canSelect = true;
            reservationButton.IsEnabled = true;
        }
    }
}

