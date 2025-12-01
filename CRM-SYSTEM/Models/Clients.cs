namespace CRM_SYSTEM.Models
{
    public class Clients
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime created_at { get; set; }
    }
}
