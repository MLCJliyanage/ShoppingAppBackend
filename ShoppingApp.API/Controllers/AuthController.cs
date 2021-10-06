using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.ManagerClasses.Interfaces;
using ShoppingApp.Common;
using ShoppingApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        #region Public Methods
        /// <summary>
        /// To register new users
        /// </summary>
        /// <param name="userForRegisterDto">requires userDto object cotains username and password</param>
        /// <returns>returns 201 created if user is created else bad request</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userForRegisterDto)
        {
            if (await _authManager.Register(userForRegisterDto))
            {
                return StatusCode(201);
            } else {
                return BadRequest(Constants.UserExists);
            }

            

        }

        /// <summary>
        /// To register new users
        /// </summary>
        /// <param name="userForRegisterDto">requires userDto object cotains username and password</param>
        /// <returns>returns an object with username and generated JWT token</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userForRegisterDto)
        {
            ReturnUser user = await _authManager.Login(userForRegisterDto);
            if (user.isValid == false)
                return Unauthorized(user.ErrorMessage);

            TokenReturn returnUser = new()
            {
                id = user.Id,
                username = user.username,
                token = user.Token
            };
            return Ok(returnUser);
        }
        #endregion
    }
}
