using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Jeppesen.Data;
using Jeppesen.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jeppesen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(Boolean), (int)HttpStatusCode.OK)]
        public IActionResult Login(string login, string password)
        {
            var loginSuccessul = this._userService.Login(login, password);

            return Ok(loginSuccessul);
        }
    }
}
