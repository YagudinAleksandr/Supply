using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class AdditionalInformation
    {
        public int ID { get; set; }
        public int AdditionalInformationTypeID { get; set; }
        public AdditionalInformationType AdditionalInformationType { get; set; }
        [Required]
        public string Value { get; set; }
        [ForeignKey("Tenant")]
        public int TenantID { get; set; }
        public Tenant Tenant { get; set; }
    }
}
