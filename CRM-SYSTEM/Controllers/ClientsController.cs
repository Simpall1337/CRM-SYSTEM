using CRM_SYSTEM.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IClientsService clientsService) : ControllerBase
    {
        
    }
}
