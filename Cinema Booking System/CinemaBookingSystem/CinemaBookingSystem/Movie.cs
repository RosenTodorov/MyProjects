using System;
using System.Collections.Generic;

namespace CinemaBookingSystem
{
    public class Movie
    {
        private string name;
        public Genre MovieGenre { get; private set; }
        public Time Duratation { get; private set; }
        private string director;
        public List<string> ArtistList { get; private set; }
        private string movieInfo;
        public bool IsPremiere { get; set; }
        public string ImageSource { get; set; }
        public List<MovieDate> ProjectionTime { get; set; }

        public Movie(string name, Genre genre, Time duratation, string director, List<string> artists, string movieInfo, bool isPremiere, List<MovieDate> projection)
        {
            this.Name = name;
            this.MovieGenre = genre;
            this.Duratation = duratation;
            this.Director = director;
            this.ArtistList = artists;
            this.MovieInfo = movieInfo;
            this.IsPremiere = isPremiere;
            this.ProjectionTime = projection;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                ValidationUtil.NullOrEmptyStringValidation(value, "Movie name should be provided. ");
                this.name = value;
            }
        }

        public string Director
        {
            get { return this.director; }
            set
            {
                string errMessage = "\"" + Name + "\"'s director name should be provided. ";
                ValidationUtil.NullOrEmptyStringValidation(value, errMessage);
                this.director = value;
            }
        }

        public string MovieInfo
        {
            get { return this.movieInfo; }
            set
            {
                if (ValidationUtil.IsStringNullOrEmpty(value))
                {
                    this.movieInfo = String.Format("Information about the movie: \"{0}\" is not provided", name);
                }
                else
                {
                    this.movieInfo = value;
                }
            }
        }
    }
}
