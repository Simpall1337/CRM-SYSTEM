using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.Data;
using CRM_SYSTEM.DTO.Users;
using CRM_SYSTEM.Repositories;
using CRM_SYSTEM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost("/login")]
        public IActionResult LoginUser([FromBody] LoginRequest request)
        {
            try
            {
                var userData = userService.Login(request);

                var response = new
                {
                    Message = "Login Successful",
                    User = userData
                };

                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); 
            }
            catch (InvalidPasswordException ex)
            {
                return Unauthorized(new { message = ex.Message }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error"});
            }
        }
        [HttpPost("/register")]
        public IActionResult RegisterUser([FromBody] RegisterRequest request)
        {
            try
            {
                var userData = userService.Register(request);

                var response = new
                {
                    Message = "Registration Successful",
                    User = userData
                };

                return Created($"/api/users/{userData.id}", response);
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error"});
            }
        }
        [HttpDelete("/delete")]
        public IActionResult DeleteUser(int id)
        {
            return Ok("Login Successful");
        }
    }
}
