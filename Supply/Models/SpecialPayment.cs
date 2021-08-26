using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class SpecialPayment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Tenant")]
        public int TenantID { get; set; }
        public Tenant Tenant { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string CreatedAt { get; set; }
    }
}
