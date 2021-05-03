using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Identification
    {
        [Key]
        [ForeignKey("Tenant")]
        public int ID { get; set; }
        [Required]
        public string Surename { get; set; }
        [Required]
        public string Name { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [ForeignKey("DocumentType")]
        public int DocumentTypeID { get; set; }
        public DocumentType DocumentType { get; set; }
        [Required]
        public string DocumentSeries { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]
        public string GivenDate { get; set; }
        [Required]
        public string Issued { get; set; }
        [Required]
        public string Cityzenship { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
        public Tenant Tenant { get; set; }
    }
}
