using OnlineMovies.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static OnlineMovies.DataLayer.CartDataAccess;

namespace OnlineMovies.BusinessLayer
{

    //public class CartLogic
    //{
    //    private readonly CartDataAccess cartDataAccess;

    //    public CartLogic()
    //    {
    //        cartDataAccess = new CartDataAccess();
    //    }
    //public int AddToCart(int userID, int movieID, int genreID, int quantity)
    //{
    //    return cartDataAccess.AddToCart(userID, movieID, genreID, quantity);
    //}


    public class CartLogic
    {
        private readonly CartDataAccess cartDataAccess;

        public CartLogic()
        {
            cartDataAccess = new CartDataAccess();
        }


        public void AddToCart(int userID, int movieID, int quantity)
        {
            cartDataAccess.AddToCart(userID, movieID, quantity);
        }

  
        public void RemoveFromCart(int shoppingCartID)
        {
            cartDataAccess.RemoveFromCart(shoppingCartID);
        }





















    }
}
