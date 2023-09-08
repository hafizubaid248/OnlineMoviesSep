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
    public class UserDataAccess
    {
        private readonly string connectionString;

        public UserDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }

       
        public User GetUser(string username, string passwordHash)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UserSignIn", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                        else
                        {
                            return null; 
                        }
                    }
                }
            }
        }

     


        public int AddUser(User user)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("AddUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

                    SqlParameter userIdParam = new SqlParameter("@UserID", SqlDbType.Int);
                    userIdParam.Direction = ParameterDirection.Output;
                    //command.Parameters.Add(userIdParam);

                    command.ExecuteNonQuery();
                    return Convert.ToInt32(userIdParam.Value);


                }

            }
    }

    }
}