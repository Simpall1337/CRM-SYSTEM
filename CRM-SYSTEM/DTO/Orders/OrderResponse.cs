namespace CRM_SYSTEM.DTO.Orders
{
    public class OrderResponse
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public int statusId { get; set; }
        public decimal totalAmount { get; set; }
        public DateTime createdAt { get; set; }
    }
}
