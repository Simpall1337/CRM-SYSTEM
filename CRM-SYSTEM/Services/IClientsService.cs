using CRM_SYSTEM.DTO.Clients;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Repositories;

namespace CRM_SYSTEM.Services
{
    public interface IClientsService
    {
        public IEnumerable<Clients> GetAllClients();
        public ClientsCreateResponse CreateClients(ClientsCreateRequest clients);
        public ClientsUpdateResponse UpdateClient(ClientsUpdateRequest clients);
        public void DeleteClient(int id);
    }
}

