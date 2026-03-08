using CRM_SYSTEM.DTO.Users;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Services;
using CRM_SYSTEM.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    //[AllowAnonymous]
    [ApiController]
    public class UsersController(IUserService userService,JwtService jwtService) : ControllerBase
    {
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult LoginUser([FromBody] LoginRequest request)
        {
            var userData = userService.Login(request);

            var token = jwtService.GenerateToken(
               userData.id,
               userData.email,
               userData.role);

            return Ok(new { token });
        }
        [HttpGet("profile")]
        public IActionResult ProfileUser(string login)
        {
            var userProfile = userService.GetProfile(login);

            return Ok(userProfile);
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult RegisterUser([FromBody] RegisterRequest request)
        {
            var userData = userService.Register(request);

            var token = jwtService.GenerateToken(
              userData.id,
              userData.email,
              userData.role);

            return Created($"/api/users/{userData.id}", token);
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateRequest request)
        {
            var userResponse = userService.Update(request.id, request);
            return Ok(userResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            userService.Delete(id);
            return NoContent();
        }
    }
}
