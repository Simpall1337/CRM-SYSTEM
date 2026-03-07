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
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] LoginRequest request)
        {
            var userData = userService.Login(request);

            var response = new
            {
                Message = "Login Successful",
                User = userData
            };

            var token = jwtService.GenerateToken(
               userData.id,
               userData.email,
               userData.login);

            return Ok(new { token });
        }
        [HttpGet("profile")]
        public IActionResult ProfileUser()
        {
            var objResponse = new
            {
                userId = "1",
                email = "san",
                role = "adm"
            };
            return Ok(objResponse);
        }
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterRequest request)
        {
            var userData = userService.Register(request);

            var response = new
            {
                Message = "Registration Successful",
                User = userData
            };

            return Created($"/api/users/{userData.id}", response);
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
