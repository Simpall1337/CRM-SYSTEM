using CRM_SYSTEM.DTO.Clients;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Repositories;

namespace CRM_SYSTEM.Services
{
    public class ClientsService(IClientsRepository clientsRepository) : IClientsService
    {
        public IEnumerable<Clients> GetAllClients()
        {
            return clientsRepository.GetAllClients();
        }
        public ClientsCreateResponse CreateClients(ClientsCreateRequest request)
        {
            var client = new Clients
            {
                first_name = request.firstName,
                last_name = request.lastName,
                email = request.email,
                phone = request.phone,
                address = request.address,
                created_at = DateTime.UtcNow
            };

            return clientsRepository.CreateClients(client);
        }

        public ClientsUpdateResponse UpdateClient(ClientsUpdateRequest clients)
        {
            var client = new Clients
            {
                id = clients.id,
                first_name = clients.first_name,
                last_name = clients.last_name,
                email = clients.email,
                phone = clients.phone,
                address = clients.address
            };

            return clientsRepository.UpdateClient(client);
        }
        public void DeleteClient(int id)
        {
            clientsRepository.DeleteClient(id);
        }
    }
}
