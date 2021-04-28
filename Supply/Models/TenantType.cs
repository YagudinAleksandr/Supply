using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class TenantType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public TenantType()
        {
            Payments = new List<Payment>();
        }
    }
}
