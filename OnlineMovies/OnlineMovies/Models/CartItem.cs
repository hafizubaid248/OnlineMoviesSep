using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMovies.Models
{
    public class CartItem
    {
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int Quantity { get; set; }
        public int GenreID { get; set; }
        public int CartID { get; set; }

    }
}