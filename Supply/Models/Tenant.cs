using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class Tenant
    {
        public int ID { get; set; }
        public bool Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        [ForeignKey("TenantType")]
        public int? TenantTypeID { get; set; }
        public TenantType TenantType { get; set; }
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public Identification Identification { get; set; }
        [ForeignKey("Payment")]
        public int? PaymentID { get; set; }
        public Payment Payment { get; set; }

        public Order Order { get; set; }
        public ICollection<AdditionalInformation> AdditionalInformation { get; set; }
        public Tenant()
        {
            AdditionalInformation = new List<AdditionalInformation>();
        }

    }
}
