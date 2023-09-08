using OnlineMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineMovies.DataLayer;
using OnlineMovies.BusinessLayer;


namespace OnlineMovies.Controllers
{
    public class MoviesController : ApiController




    {
        private readonly MoviesLogic moviesLogic;

        public MoviesController()
        {
            moviesLogic = new MoviesLogic(); 
        }


        [HttpPost]
        [Route("admin/addmovie")]
        public IHttpActionResult AddMovie([FromBody] Movie movie)
        {
          

            moviesLogic.AddMovie(movie);
            return Ok("Movie added successfully.");
        }
        [HttpGet]
        [Route("movies/getall")]
        public IHttpActionResult GetAllMovies()
        {
            List<Movie> movies = moviesLogic.GetAllMovies();
            return Ok(movies);
        }

        [HttpPost]
        [Route("admin/addmoviewithgenres")]
        public IHttpActionResult AddMovieWithGenres([FromBody] Movie movie)
        {
            //List<int> genreIDs = request.GenreIDs;
            Movie newmovie = new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate, 
                genreID = movie.genreID
            };

            int movieID = moviesLogic.AddMovieWithGenres(movie);


            if (movieID != 0)
            {

                return Ok("Movie added successfully.");
            }

            return BadRequest("Failed to add movie.");
        }


        [HttpGet]
        [Route("movies/getallgenres")]
        public IHttpActionResult GetAllGenres()
        {
            List<Genre> genres = moviesLogic.GetAllGenres();
            return Ok(genres);
        }




    }
}
