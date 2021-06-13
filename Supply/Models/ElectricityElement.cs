using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class ElectricityElement
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ElectricityPayment")]
        public int ElectricityPaymentID { get; set; }
        public ElectricityPayment ElectricityPayment { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public decimal Payment { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
    }
}
