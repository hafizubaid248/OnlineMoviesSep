using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMovies.Models
{
    public class MovieWithGenresRequest
    {

        public List<int> GenreIDs { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string  Description { get; set; }
        public string Title { get; set; }


    }
}