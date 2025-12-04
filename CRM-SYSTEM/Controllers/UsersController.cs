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
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    public class UsersController(IUserService userService, ILogger<UsersController> logger) : ControllerBase
    {
        [HttpPost("/login")]
        public IActionResult LoginUser([FromBody] LoginRequest request)
        {
            try
            {
                //logger.LogInformation("Запрос пользователя ID = {id}", request.login);

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
                logger.LogError(ex, $"Error in LoginUser, login: {request.login},");
                return NotFound(new { message = ex.Message }); 
            }
            catch (InvalidPasswordException ex)
            {
                logger.LogError(ex, $"Error in LoginUser, login: {request.login},");
                return Unauthorized(new { message = ex.Message }); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error in LoginUser, login: {request.login},");
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
        [HttpPut("/update")]
        public IActionResult UpdateUser([FromBody] UpdateRequest request)
        {
            try
            {
                // var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub"); FOR JWT AUTHENTICATION
                // if (userIdClaim == null) return Unauthorized();

                var userResponse = userService.Update(request.id, request);

                return Ok("Login Successful");
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }   
        [HttpDelete("/delete")]
        public IActionResult DeleteUser(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub");

            return Ok("Login Successful");
        }
    }
}
