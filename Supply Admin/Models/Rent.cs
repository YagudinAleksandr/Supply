using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public Rent()
        {
            Rates = new List<Rate>();
        }
    }
}
