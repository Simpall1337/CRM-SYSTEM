namespace CRM_SYSTEM.DTO.Orders
{
    public class OrderUpdateRequest
    {
        public int id { get; set; }
        public decimal totalAmount { get; set; }
        public int statusId { get; set; }
    }
}
