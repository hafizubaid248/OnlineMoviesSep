using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using OnlineMovies.Models;
using System.Data;
using System.Linq.Expressions;
using System.Configuration;

namespace OnlineMovies.DataLayer
{
    public class MoviesDataAccess
    {

        private readonly string connectionString;

        public MoviesDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
        public int AddMovie(Movie movie)
        {
            int newMovieID = 0; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddMovie", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Description", movie.Description);
                    command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                    SqlParameter movieIdParam = new SqlParameter("@MovieID", SqlDbType.Int);
                    movieIdParam.Direction = ParameterDirection.Output;
                    //command.Parameters.Add(userIdParam);

                    command.ExecuteNonQuery();
                    return Convert.ToInt32(movieIdParam.Value);


                    //newMovieID = (int)command.ExecuteScalar();
                }
            }

            //return newMovieID;
        }
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAllMovies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(new Movie
                            {
                                genreID = reader["MovieID"].ToString(),
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"])
                            });
                        }
                    }
                }
            }

            return movies;
        }





        //public int AddMovieWithGenres(Movie movieData, int[] genreIds)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand("AddMovieWithGenres", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@Title", movieData.Title);
        //            command.Parameters.AddWithValue("@Description", movieData.Description);
        //            command.Parameters.AddWithValue("@ReleaseDate", movieData.ReleaseDate);

        //            SqlParameter movieIdParam = new SqlParameter("@MovieID", SqlDbType.Int);
        //            movieIdParam.Direction = ParameterDirection.Output;
        //            command.Parameters.Add(movieIdParam);

        //            // Create a DataTable for genre IDs
        //            DataTable genreTable = new DataTable();
        //            genreTable.Columns.Add("GenreID", typeof(int));
        //            foreach (int genreId in genreIds)
        //            {
        //                genreTable.Rows.Add(genreId);
        //            }

        //            // Add parameter for genre IDs
        //            SqlParameter genreIdsParam = command.Parameters.AddWithValue("@GenreIDs", genreTable);
        //            genreIdsParam.SqlDbType = SqlDbType.Structured;
        //            genreIdsParam.TypeName = "dbo.IntList";

        //            command.ExecuteNonQuery();
        //            return Convert.ToInt32(movieIdParam.Value);


        //        }


        //    }
        //}



        //public int AddMovieWithGenres(Movie movie, List<int> genreIDs)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand("AddMovieWithGenres", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@Title", movie.Title);
        //            command.Parameters.AddWithValue("@Description", movie.Description);
        //            command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);



        //            string genreIDsString = string.Join(",", genreIDs);
        //            command.Parameters.AddWithValue("@GenreIDs", genreIDsString);

        //            command.ExecuteNonQuery();


        //            return (int)command.Parameters["@MovieID"].Value;
        //        }
        //    }
        //}



        public int AddMovieWithGenres(Movie movie)
        {
           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
              

                using (SqlCommand command = new SqlCommand("AddMovieWithGenres", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Description", movie.Description);
                    command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);




                    //string genreIDsString = string.Join(",", genreIDs.Where(id => id > 0));
                    command.Parameters.AddWithValue("@GenreIDs", movie.genreID);

                    SqlParameter movieIdParam = new SqlParameter("@MovieID", SqlDbType.Int);
                    movieIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(movieIdParam);

                    

                    command.ExecuteNonQuery();

                   
                    return (int)command.Parameters["@MovieID"].Value;
                }
            }
        }












        public List<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAllGenres", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genres.Add(new Genre
                            {
                                GenreID = Convert.ToInt32(reader["GenreID"]),
                                Name = reader["Name"].ToString()
                            });
                        }
                    }
                }
            }

            return genres;
        }




    }





}