namespace CRM_SYSTEM.DTO.Clients
{
    public class ClientsCreateResponse
    {
        public int id{ get; set; }
        public string firstName{ get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
}
