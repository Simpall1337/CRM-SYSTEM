using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.DTO.Clients;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IClientsService clientsService, ILogger<UsersController> logger) : ControllerBase
    {
        [HttpGet("/clients")]
        public IActionResult GetClients()
        {
            try
            {
                var clients = clientsService.GetAllClients();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in GetClients");
                return StatusCode(500, new { message = "Internal server error" });
            }

        }
        [HttpPost("/clients")]
        public IActionResult CreateClient([FromBody] ClientsCreateRequest request)
        {
            try
            {
                var clientData = clientsService.CreateClients(request);

                var response = new
                {
                    Message = "Client Creation Successful",
                    Client = clientData
                };
                return Ok(response);
            }
            catch (ClientAlreadyExistsException ex)
            {
                logger.LogError(ex, "Error in CreateClient");
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in CreateClient");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
        [HttpPut("/clients")]
        public IActionResult UpdateClient([FromBody] ClientsUpdateRequest request)
        {
            try
            {
                var updatedClient = clientsService.UpdateClient(request);
                return Ok(updatedClient);
            }
            catch (ClientNotFoundException ex)
            {
                logger.LogError(ex, "Error in UpdateClient");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in UpdateClient");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
        [HttpDelete("/clients")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                clientsService.DeleteClient(id);
                return NoContent();
            }
            catch (ClientNotFoundException ex)
            {
                logger.LogError(ex, "Error in DeleteClient");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in DeleteClient");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
