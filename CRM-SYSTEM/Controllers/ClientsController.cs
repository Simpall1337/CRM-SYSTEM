using CRM_SYSTEM.DTO.Clients;
using CRM_SYSTEM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IClientsService clientsService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = clientsService.GetAllClients();
            return Ok(clients);
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientsCreateRequest request)
        {
            var clientData = clientsService.CreateClients(request);

            var response = new
            {
                Message = "Client Creation Successful",
                Client = clientData
            };
            return Created($"/api/clients/{clientData.id}", response);
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientsUpdateRequest request)
        {
            var updatedClient = clientsService.UpdateClient(request);
            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            clientsService.DeleteClient(id);
            return NoContent();
        }
    }
}
