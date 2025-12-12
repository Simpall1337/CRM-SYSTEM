using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.DTO.Roles;
using CRM_SYSTEM.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService roleService, ILogger<RolesController> logger) : ControllerBase
    {
        [HttpGet("/roles")]
        public IActionResult GetAllRoles()
        {
            try
            {
                return Ok(roleService.GetAllRoles());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error in GetAllRoles");
                return StatusCode(500, new { message = "Internal server error" });
            }
            
        }
        [HttpPost("/roles")]
        public IActionResult CreateRole([FromBody] RequestCreate request)
        {
            try
            {
                var roleData = roleService.CreateRole(request);
                var response = new
                {
                    Message = "Role Creation Successful",
                    Role = roleData
                };
                return Ok(response);
            }
            catch(AlreadyExistsRoleException ex)
            {
                logger.LogWarning(ex, "Role already exists");
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in CreateRole");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
        [HttpPut("/roles")]
        public IActionResult UpdateRole([FromBody] RequestUpdate request)
        {
            try
            {
                var updatedRole = roleService.UpdateRole(request);
                return Ok(updatedRole);
            }
            catch (NotFoundRoleException ex)
            {
                logger.LogWarning(ex, "Role not found");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in UpdateRole");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
        [HttpDelete("/roles")]
        public IActionResult DeleteRole([FromQuery] int id)
        {
            try
            {
                roleService.DeleteRole(id);
                return NoContent();
            }
            catch (NotFoundRoleException ex)
            {
                logger.LogWarning(ex, "Role not found");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in DeleteRole");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
