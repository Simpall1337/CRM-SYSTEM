using CRM_SYSTEM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("/login")]
        public IActionResult LoginUser([FromBody] LoginRequest request)
        {
           
            return Ok("wtf"); 
        }
        [HttpPost("/register")]
        public IActionResult RegisterUser([FromBody] RegisterRequest request)
        {
            return Ok("Login Successful");
        }
        [HttpDelete("/delete")]
        public IActionResult DeleteUser(int id)
        {
            return Ok("Login Successful");
        }
    }
}
