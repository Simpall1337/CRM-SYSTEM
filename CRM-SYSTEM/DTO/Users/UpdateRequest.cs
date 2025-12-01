namespace CRM_SYSTEM.DTO.Users
{
    public class UpdateRequest
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? password { get; set; }
    }
}
