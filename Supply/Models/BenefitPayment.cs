using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class BenefitPayment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("BenefitType")]
        public int BenefitTypeID { get; set; }
        public BenefitType BenefitType { get; set; }
        [ForeignKey("Hostel")]
        public int HostelID { get; set; }
        public Hostel Hostel { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal House { get; set; }
        [Required]
        public decimal Service { get; set; }
        [Required]
        public decimal Electricity { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }

    }
}
