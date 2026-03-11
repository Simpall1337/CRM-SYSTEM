using System.ComponentModel.DataAnnotations;

namespace CRM_SYSTEM.Models
{
    public class Logs
    {
        [Key]
        public int id { get; set; }
        public string Timestamp { get; set; }
        public int Level { get; set; }
        public string Exeptoin { get; set; }
        public string RenderedMessage { get; set; }
        public string Properties { get; set; }
    }
}
