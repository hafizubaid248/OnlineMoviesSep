using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMovies.Models
{
    public class SignInResponse
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
    }
}