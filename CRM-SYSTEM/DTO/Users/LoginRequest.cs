namespace CRM_SYSTEM.DTO.Users
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }  = string.Empty;
    }
}
