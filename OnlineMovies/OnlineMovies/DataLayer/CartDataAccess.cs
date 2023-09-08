using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace OnlineMovies.DataLayer
{
    public class CartDataAccess
    {
        private readonly string connectionString;

        public CartDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
        //public int AddToCart(int userID, int movieID, int genreID, int quantity)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand("AddToCart", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@UserID", userID);
        //            command.Parameters.AddWithValue("@MovieID", movieID);
        //            command.Parameters.AddWithValue("@GenreID", genreID);
        //            command.Parameters.AddWithValue("@Quantity", quantity);

        //            return command.ExecuteNonQuery();
        //        }
        //    }
        //}

























        public void AddToCart(int userID, int movieID, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddToCart", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@MovieID", movieID);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveFromCart(int shoppingCartID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("RemoveFromCart", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartID", shoppingCartID);
                    command.ExecuteNonQuery();
                }
            }
        }











    }
}