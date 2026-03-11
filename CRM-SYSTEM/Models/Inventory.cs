using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_SYSTEM.Models
{
    public class Inventory
    {
        [Key]
        public int id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }

        [ForeignKey("product_id")]
        public Products Products { get; set; } = null!;

    }
}
