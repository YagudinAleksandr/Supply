using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class ElectricityPayment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Hostel")]
        public int HostelID { get; set; }
        public Hostel Hostel { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
    }
}
