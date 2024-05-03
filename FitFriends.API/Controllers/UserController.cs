using FitFriends.API.Contracts.Users;
using FitFriends.Application.Interfaces;
using FitFriends.Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitFriends.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromServices] IUserService userService,
            [FromBody] RegisterUserRequest request)
        {
            await userService.RegisterAsync(request.UserName, request.Email, request.Password);
            
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromServices] IUserService userService,
            [FromBody] LoginUserRequest request)
        {
            string token = await userService.LoginAsync(request.Email, request.Password);

            HttpContext.Response.Cookies.Append("is-not-token", token);

            return Ok();
        }
    }
}
