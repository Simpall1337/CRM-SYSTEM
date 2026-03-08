using System.ComponentModel.DataAnnotations;

namespace CRM_SYSTEM.DTO.Users
{
    public class UserResponse
    {
        public int id { get; set; }
        public string? email { get; set; }
        public string? role { get; set; }
    }
}
