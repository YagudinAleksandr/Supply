using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class ElecricityOrder
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [ForeignKey("Tenant")]
        public int TenantID { get; set; }
        public Tenant Tenant { get; set; }
        
        [Required]
        public bool Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

    }
}
