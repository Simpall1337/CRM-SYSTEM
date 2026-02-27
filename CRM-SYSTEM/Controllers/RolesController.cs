using CRM_SYSTEM.DTO.Roles;
using CRM_SYSTEM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(roleService.GetAllRoles());
        }

        [HttpPost]
        public IActionResult CreateRole([FromBody] RequestCreate request)
        {
            var roleData = roleService.CreateRole(request);
            var response = new
            {
                Message = "Role Creation Successful",
                Role = roleData
            };
            return Ok(response);
        }
        [HttpPut]
        public IActionResult UpdateRole([FromBody] RequestUpdate request)
        {
            var updatedRole = roleService.UpdateRole(request);
            return Ok(updatedRole);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            roleService.DeleteRole(id);
            return NoContent();
        }
    }
}
