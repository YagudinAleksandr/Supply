using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Hostel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? AddressID { get; set; }
        public Address Address { get; set; }
        public int? ManagerId { get; set; }
        public Manager Manager { get; set; }

        public ICollection<Enterance> Enterances { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public Hostel()
        {
            Enterances = new List<Enterance>();
            Payments = new List<Payment>();
        }
    }
}
