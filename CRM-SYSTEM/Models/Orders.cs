using System.ComponentModel.DataAnnotations;

namespace CRM_SYSTEM.Models
{
    public class Orders
    {
        [Key]
        public int id { get; set; }
        public int client_id { get; set; }
        public int user_id { get; set; }
        public int status_order_id { get; set; }
        public decimal total_amount { get; set; }
        public DateTime created_at { get; set; }
    }
}
