using OnlineMovies.DataLayer;
using OnlineMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;




namespace OnlineMovies.BusinessLayer
{
    public class MoviesLogic
    {
        private readonly MoviesDataAccess moviesDataAccess;

        public MoviesLogic()
        {
            moviesDataAccess = new MoviesDataAccess();
        }

        public int AddMovie(Movie movie)
        {
            
            return moviesDataAccess.AddMovie(movie);
        }

        public List<Movie> GetAllMovies()
        {
           
            return moviesDataAccess.GetAllMovies();
        }

        public int AddMovieWithGenres(Movie movie)
        {
          
            return moviesDataAccess.AddMovieWithGenres(movie);
        }


   

        public List<Genre> GetAllGenres()
        {
          
            return moviesDataAccess.GetAllGenres();
        }


      






    }
}