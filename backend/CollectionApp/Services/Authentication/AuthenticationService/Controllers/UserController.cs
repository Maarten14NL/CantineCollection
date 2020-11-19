using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationLogic;
using AuthenticationLogic.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Authenticate()
        {
            var token = _userService.Authenticate("maarten.jakobs@gmail.com", "sonu@123");

            if (token == null)
                return Ok(new { message = "Username or password is incorrect" });

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] Login loginParam)
        {
            var token = _userService.Authenticate(loginParam.Username, loginParam.Password);

            if (token == null)
                return Ok(new { message = "Username or password is incorrect" });

            return Ok(token);
        }
    }
}
