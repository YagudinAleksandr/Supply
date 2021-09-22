using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class ChangePassport
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Tenant")]
        public int TenantID { get; set; }
        public Tenant Tenant { get; set; }
        public string Surename { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        [ForeignKey("DocumentType")]
        public int DocumentTypeID { get; set; }
        public DocumentType DocumentType { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Series { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string GivenDate { get; set; }
        [Required]
        public string Issued { get; set; }
        public string Citizenship { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public bool Status { get; set; }
        [ForeignKey("License")]
        public int? LicenseID { get; set; }
        public License License { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
    }
}
