using CRM_SYSTEM.Models;

namespace CRM_SYSTEM.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        IEnumerable<Orders> GetAll(int page, int pageSize);
        Orders Add(Orders order);
        Orders? GetById(int id);
        Orders Update(Orders order);
    }
}
