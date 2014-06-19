using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CinemaBookingSystem
{
    public partial class MovieWindow : Window
    {
        ShowList ShowList;
        Movie Movie;

        public MovieWindow(Movie movie, ShowList showlist)
        {
            InitializeComponent();
            LoadMovieData(movie);
            this.ShowList = showlist;
            this.Movie = movie;
        }

        private void LoadMovieData(Movie movie)
        {
            movieInfo.Text = GetMovieInfo(movie);
            MovieImage.Source = LoadImage(movie.ImageSource);
            MovieLabel.Content = movie.Name;
        }

        private string GetMovieInfo(Movie movie)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Genre: ").Append(movie.MovieGenre);
            builder.Append(Environment.NewLine);
            builder.Append(Environment.NewLine);
            builder.Append("Time: ");
            builder.Append(movie.Duratation.Hours).Append(":").Append(movie.Duratation.Minutes);
            builder.Append(Environment.NewLine);
            builder.Append(Environment.NewLine);
            builder.Append("Director: ");
            builder.Append(movie.Director);
            builder.Append(Environment.NewLine);
            builder.Append(Environment.NewLine);
            builder.Append("Actors: ");
            builder.Append(GetActorsToString(movie.ArtistList));
            builder.Append(Environment.NewLine);
            builder.Append(Environment.NewLine);
            builder.Append("Story: ");
            builder.Append(movie.MovieInfo);
            builder.Append(Environment.NewLine);
            builder.Append(Environment.NewLine);

            return builder.ToString();
        }

        private string GetActorsToString(List<string> list)
        {
            StringBuilder actors = new StringBuilder();
            foreach (var name in list)
            {
                actors.Append(name);
                actors.Append(", ");
            }

            actors.Remove(actors.Length - 3, 2);
            return actors.ToString();
        }

        private BitmapImage LoadImage(string source)
        {
            string resource = "pack://application:,,,/" + source;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(resource);
            image.EndInit();
            return image;
        }

        private void reserveButton_Click(object sender, RoutedEventArgs e)
        {
            MovieList aMovie = new MovieList();
            aMovie.Add(this.Movie);
            ShowList ShowsForMovie = new ShowList(aMovie, this.ShowList.Halls);
            for (int i = 0; i < this.ShowList.Count(); i++)
            {
                if (this.ShowList[i].Movie == this.Movie)
                {
                    ShowsForMovie.Add(ShowList[i]);
                }
            }

            ProgramWindow window = new ProgramWindow(ShowsForMovie);
            window.Show();
        }
    }
}
