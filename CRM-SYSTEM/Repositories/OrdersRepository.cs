using CRM_SYSTEM.Data;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM_SYSTEM.Repositories
{
    public class OrdersRepository(ApplicationDbContext dbContext) : IOrdersRepository
    {
        public IEnumerable<Orders> GetAll(int page, int pageSize)
        {
            return dbContext.Orders.Skip((page - 1) * pageSize)
                                   .Take(pageSize).ToList();
        }

        public Orders Add(Orders order)
        {
            order.created_at = DateTime.UtcNow;
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            return order;
        }

        public Orders? GetById(int id)
        {
            return dbContext.Orders.FirstOrDefault(x => x.id == id);
        }

        public Orders Update(Orders order)
        {
            var existing = dbContext.Orders.FirstOrDefault(x => x.id == order.id);
            if (existing == null) return null;

            existing.total_amount = order.total_amount;
            existing.status_order_id = order.status_order_id;

            dbContext.SaveChanges();
            return existing;
        }
    }
}
