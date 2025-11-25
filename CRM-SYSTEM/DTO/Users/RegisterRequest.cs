namespace CRM_SYSTEM.DTO.Users
{
    public class RegisterRequest
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
