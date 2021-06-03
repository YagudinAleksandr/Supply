using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class Order
    {
        [Key]
        [ForeignKey("Tenant")]
        public int ID { get; set; }
        public Tenant Tenant { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }
        [ForeignKey("License")]
        public int? LicenseID { get; set; }
        public License License { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
        public ICollection<Benefit> Benefits { get; set; }
        public ICollection<ChangeRoom> ChangeRooms { get; set; }
        public Order()
        {
            Benefits = new List<Benefit>();
            ChangeRooms = new List<ChangeRoom>();
        }
    }
}
