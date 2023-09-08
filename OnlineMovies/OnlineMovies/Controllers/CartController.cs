using OnlineMovies.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineMovies.Models;


namespace OnlineMovies.Controllers
{
    //public class CartController : ApiController
    //{

    //    private readonly CartLogic cartLogic;

    //    public CartController()
    //    {
    //        cartLogic = new CartLogic();
    //    }

    //    [HttpPost]
    //    [Route("customer/addtocart")]
    //    public IHttpActionResult AddToCart([FromBody] CartItem cartItem)
    //    {
    //        int result = cartLogic.AddToCart(cartItem.UserID, cartItem.MovieID, cartItem.GenreID, cartItem.Quantity);

    //        if (result > 0)
    //        {
    //            return Ok("Item added to cart successfully.");
    //        }
    //        else
    //        {
    //            return BadRequest("Failed to add item to cart.");
    //        }
    //    }
    public class CartController : ApiController
    {

        private readonly CartLogic cartLogic;

        public CartController()
        {
            cartLogic = new CartLogic();
        }







        [HttpPost]
        [Route("shoppingcart/add")]
        public IHttpActionResult AddToCart(CartItem request)
        {
            cartLogic.AddToCart(request.UserID, request.MovieID, request.Quantity);
            return Ok("Item added to cart.");
        }

        //[HttpPost]
        //[Route("remove")]
        //public IHttpActionResult RemoveFromCart(int shoppingCartID)
        //{
        //    cartLogic.RemoveFromCart(shoppingCartID);
        //    return Ok("Item removed from cart.");
        //}

        [HttpPost]
        [Route("shoppingcart/remove")]
        public IHttpActionResult RemoveFromCart(CartItem request)
        {
            cartLogic.RemoveFromCart(request.CartID);
            return Ok("Item removed from cart.");
        }

















    }
}

























//}
