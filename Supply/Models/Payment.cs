using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Rent { get; set; }
        [Required]
        public decimal Service { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string PaymentType { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }

        public int? TenantTypeID { get; set; }
        public TenantType TenantType { get; set; }
        [ForeignKey("RoomType")]
        public int? RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }
        [ForeignKey("Hostel")]
        public int? HostelID { get; set; }
        public Hostel Hostel { get; set; }

        public ICollection<Tenant> Tenants { get; set; }
        public Payment()
        {
            Tenants = new List<Tenant>();
        }
    }
}
