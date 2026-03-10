using CRM_SYSTEM.DTO.Orders;
using CRM_SYSTEM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrdersService ordersService) : ControllerBase
    {
        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders(int page, int pageSize)
        {
            var orders = ordersService.GetAllOrders(page,pageSize);
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var orders = ordersService.GetOrder(id);
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderCreateRequest request)
        {
            var orderData = ordersService.CreateOrder(request);

            var response = new
            {
                Message = "Order Creation Successful",
                Order = orderData
            };
            return Created($"/api/orders/{orderData.id}", response);
        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody] OrderUpdateRequest request)
        {
            var updated = ordersService.UpdateOrder(request);
            if (updated == null) return NotFound();

            var response = new
            {
                Message = "Order Update Successful",
                Order = updated
            };

            return Ok(response);
        }
    }
}
