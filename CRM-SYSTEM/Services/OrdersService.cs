using CRM_SYSTEM.DTO.Orders;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Repositories.Interfaces;
using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM_SYSTEM.Services
{
    public class OrdersService(IOrdersRepository ordersRepository) : IOrdersService
    {
        public IEnumerable<OrderResponse> GetAllOrders(int page, int pageSize)
        {
            return ordersRepository.GetAll(page, pageSize).Select(o => new OrderResponse
            {
                id = o.id,
                clientId = o.client_id,
                statusId = o.status_order_id,
                totalAmount = o.total_amount,
                createdAt = o.created_at
            });
        }
        public OrderResponse GetOrder(int id)
        {
            var o = ordersRepository.GetById(id);

            if (o == null)
                throw new OrderNotFoundException($"Order with id {id} not found");

            return new OrderResponse
            {
                id = o.id,
                clientId = o.client_id,
                statusId = o.status_order_id,
                totalAmount = o.total_amount,
                createdAt = o.created_at
            };
        }
        public OrderResponse CreateOrder(OrderCreateRequest request)
        {
            var order = new Orders
            {
                user_id = request.userId,
                client_id = request.clientId,
                status_order_id = request.statusId,
                total_amount = request.totalAmount,
                created_at = DateTime.UtcNow
            };

            var created = ordersRepository.Add(order);

            return new OrderResponse
            {
                id = created.id,
                clientId = created.client_id,
                statusId = created.status_order_id,
                totalAmount = created.total_amount,
                createdAt = created.created_at
            };
        }
        public OrderResponse UpdateOrder(OrderUpdateRequest request)
        {
            var existing = ordersRepository.GetById(request.id);
            if (existing == null)
                throw new OrderNotFoundException($"Order with id {request.id} not found");

            existing.total_amount = request.totalAmount;
            existing.status_order_id = request.statusId;

            var updated = ordersRepository.Update(existing);

            if (updated == null)
                throw new OrderNotFoundException($"Unable to update order with id {request.id}");

            return new OrderResponse
            {
                id = updated.id,
                clientId = updated.client_id,
                statusId = updated.status_order_id,
                totalAmount = updated.total_amount,
                createdAt = updated.created_at
            };
        }
    }
}
