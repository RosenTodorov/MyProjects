using System;
using System.Collections.Generic;

namespace CinemaBookingSystem
{
    public class ShowList
    {
        List<Show> shows { get; set; }
        public MovieList Movies { get; set; }
        public CinemaHallList Halls { get; set; }

        public ShowList(MovieList movies, CinemaHallList halls)
        {
            this.shows = new List<Show>();
            this.Movies = movies;
            this.Halls = halls;
        }

        public ShowList()
            : this(null, null)
        {
        }

        public void LoadShows()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < Movies.Count; i++)
            {
                List<MovieDate> date = Movies[i].ProjectionTime;

                for (int j = 0; j < date.Count; j++)
                {
                    List<Time> time = date[j].ShowTime;
                    for (int k = 0; k < time.Count; k++)
                    {
                        this.shows.Add(new Show(Halls[random.Next(0, 3)], Movies[i], date[j].DayOfWeek, time[k]));
                    }
                }
            }
        }

        public Show FindShow(string MovieName, DayOfWeek dayOfWeek, Time time)
        {
            Movie movie = Movies.FindMovie(MovieName);
            int showIndex = -1;
            for (int i = 0; i < shows.Count; i++)
            {
                Show show = shows[i];
                int dayOfWeekIndex = show.Movie.ProjectionTime.FindIndex(item => item.DayOfWeek == (DayOfWeek)dayOfWeek);
                if (dayOfWeekIndex < 0)
                {
                    continue;
                }
                int timeOfWeekIndex = show.Movie.ProjectionTime[dayOfWeekIndex].ShowTime.FindIndex(item => item.Hours == time.Hours && item.Minutes == time.Minutes);
                if (timeOfWeekIndex < 0)
                {
                    continue;
                }
                showIndex = shows.FindIndex(item => item.Movie == movie && item.Time == show.Movie.ProjectionTime[dayOfWeekIndex].ShowTime[timeOfWeekIndex] && show.Date == show.Movie.ProjectionTime[dayOfWeekIndex].DayOfWeek);
                if (showIndex >= 0)
                {
                    break;
                }
            }
            return shows[showIndex];
        }

        public Show this[int index]
        {
            get { return this.shows[index]; }
            set { this.shows[index] = value; }
        }

        public int Count()
        {
            return this.shows.Count;
        }

        public void Add(Show show)
        {
            this.shows.Add(show);
        }

    }
}
