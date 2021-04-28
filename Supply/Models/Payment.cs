using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Rent { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public int? ManagerID { get; set; }
        public Manager Manager { get; set; }

        public int? TenantTypeID { get; set; }
        public TenantType TenantType { get; set; }

        public int? RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }
        [ForeignKey("Hostel")]
        public int HostelID { get; set; }
        public Hostel Hostel { get; set; }
    }
}
