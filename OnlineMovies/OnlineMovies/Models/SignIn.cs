﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMovies.Models
{
    public class SignInRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}