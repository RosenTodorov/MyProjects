using System.Collections.Generic;

namespace CinemaBookingSystem
{
    public class MovieList : ICinemaList
    {
        const string OUT_OF_RANGE_ERR_MESSAGE = "Index out of range";
        List<Movie> movies;
        public int Count = 0;

        public MovieList()
        {
            movies = new List<Movie>();
        }

        public MovieList(MovieList list)
        {
            movies = new List<Movie>();

            for (int i = 0; i < list.Count; i++)
            {
                Add(list[i]);
            }
        }


        public void Add(Movie movie)
        {
            movies.Add(movie);
            this.Count++;
        }

        public void Remove(int index)
        {
            movies.RemoveAt(index);
            this.Count--;
        }


        public void RemoveRange(int start, int end)
        {
            ValidationUtil.ValidateRange(0, movies.Count, start, OUT_OF_RANGE_ERR_MESSAGE);
            ValidationUtil.ValidateRange(0, movies.Count, end, OUT_OF_RANGE_ERR_MESSAGE);

            for (int i = start; i < end; i++)
            {
                movies.RemoveAt(i);
                this.Count--;
            }
        }

        public Movie FindMovie(string name)
        {
            if (ValidationUtil.IsStringNullOrEmpty(name))
            {
                return null;
            }

            foreach (var movie in movies)
            {
                if (movie.Name.ToLower().Contains(name.ToLower()))
                {
                    return movie;
                }
            }
            return null;
        }

        public Movie this[int index]
        {
            get
            {
                ValidationUtil.ValidateRange(0, movies.Count, index, OUT_OF_RANGE_ERR_MESSAGE);
                return movies[index];
            }
            set
            {
                ValidationUtil.ValidateRange(0, movies.Count, index, OUT_OF_RANGE_ERR_MESSAGE);
                movies[index] = value;
            }
        }
    }
}
