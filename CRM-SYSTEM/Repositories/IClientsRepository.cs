using CRM_SYSTEM.DTO.Clients;
using CRM_SYSTEM.Models;
using Microsoft.AspNetCore.Http.Metadata;

namespace CRM_SYSTEM.Repositories
{
    public interface IClientsRepository: IRepository<Clients>
    {
        public IEnumerable<Clients> GetAllClients();
        public bool GetAnyPhone(string phone);
        public bool GetAnyEmail(string email);
    }
}