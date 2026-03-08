using System.ComponentModel.DataAnnotations;

namespace CRM_SYSTEM.Models
{
    public class Roles
    {
        [Key]
        public int role_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
