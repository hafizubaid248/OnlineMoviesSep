using OnlineMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineMovies.BusinessLayer;


namespace OnlineMovies.Controllers
{
    
    public class UserController : ApiController
    {
        private readonly BusinessLogic userLogic;

        public UserController()
        {
            userLogic = new BusinessLogic();
        }



        [HttpPost]
        [Route("user/signin")]
        public IHttpActionResult SignIn([FromBody] SignInRequest request)
        {

            User user = userLogic.SignIn(request.Username, request.PasswordHash);

            if (user == null)
            {
                return Unauthorized();
            }


            return Ok(user);
        }

        [HttpPost]
    [Route("user/signup")]
    public IHttpActionResult SignUp([FromBody] User user)
    {
        
        int userId = userLogic.SignUp(user);

        if (userId == -1)
        {
            return BadRequest("User registration failed."); 
        }

    
        return Ok(userId);
    }
    }
}
