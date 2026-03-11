using System.ComponentModel.DataAnnotations;

namespace CRM_SYSTEM.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public int price { get; set; }
        public string description { get; set; }
    }
}
