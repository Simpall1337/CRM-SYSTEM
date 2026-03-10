namespace CRM_SYSTEM.DTO.Orders
{
    public class OrderCreateRequest
    {
        public int clientId { get; set; }
        public int userId { get; set; }
        public int statusId { get; set; }
        public decimal totalAmount { get; set; }
    }
}
