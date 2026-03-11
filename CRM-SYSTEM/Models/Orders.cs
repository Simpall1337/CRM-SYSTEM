using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("client_id")]
        public Clients Clients { get; set; } = null!;

        [ForeignKey("user_id")]
        public Users Users { get; set; } = null!;

        [ForeignKey("status_order_id")]
        public StatusOrder StatusOrder { get; set; } = null!;
    }
}
