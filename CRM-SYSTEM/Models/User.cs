using System.ComponentModel.DataAnnotations;

namespace CRM_SYSTEM.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone{ get; set; }
        public string login{ get; set; }
        public string password{ get; set; }
        public DateTime created_at{ get; set; }
        public int role_id{ get; set; }
    }
}
