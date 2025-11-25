using System.ComponentModel.DataAnnotations;

namespace CRM_SYSTEM.DTO.Users
{
    public class UserResponse
    {
        public int id { get; set; }
        public string login { get; set; }
        public string fullName { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
    }
}
