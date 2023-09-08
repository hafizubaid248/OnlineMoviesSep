using OnlineMovies.DataLayer;
using OnlineMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OnlineMovies.BusinessLayer
{
    public class BusinessLogic
    {
        private readonly UserDataAccess userDataAccess;

        public BusinessLogic()
        {
            userDataAccess = new UserDataAccess();
        }

        public User SignIn(string username, string passwordHash)
        {
          
            return userDataAccess.GetUser(username, passwordHash);
        }
        public int SignUp(User user)
        {
            
            return userDataAccess.AddUser(user);
        }


      







    }
}