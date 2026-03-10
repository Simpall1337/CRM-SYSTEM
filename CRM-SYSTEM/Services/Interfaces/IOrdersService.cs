using CRM_SYSTEM.DTO.Orders;

namespace CRM_SYSTEM.Services.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderResponse> GetAllOrders(int page, int pageSize);
        OrderResponse GetOrder(int id);
        OrderResponse CreateOrder(OrderCreateRequest request);
        OrderResponse? UpdateOrder(OrderUpdateRequest request);
    }
}
