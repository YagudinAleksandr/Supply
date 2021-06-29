using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class AccountingElectricity
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ElecricityOrder")]
        public int ElecricityOrderID { get; set; }
        public ElecricityOrder ElecricityOrder { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string Coast { get; set; }
        [Required]
        public string PeriodStart { get; set; }
        [Required]
        public string PeriodEnd { get; set; }
    }
}
