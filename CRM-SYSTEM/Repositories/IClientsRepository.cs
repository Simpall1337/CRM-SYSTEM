using CRM_SYSTEM.DTO.Clients;
using CRM_SYSTEM.Models;
using Microsoft.AspNetCore.Http.Metadata;

namespace CRM_SYSTEM.Repositories
{
    public interface IClientsRepository
    {
        public IEnumerable<Clients> GetAllClients();
        public ClientsCreateResponse CreateClients(Clients client);
        public ClientsUpdateResponse UpdateClient(Clients client);
        public void DeleteClient(int id);
    }
}
