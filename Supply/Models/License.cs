using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class License
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Type { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        public bool Status { get; set; }
    }
}
