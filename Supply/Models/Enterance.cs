using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Supply.Models
{
    public class Enterance
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("Hostel")]
        public int HostelId { get; set; }
        public Hostel Hostel { get; set; }
        public ICollection<Flat> Flats { get; set; }
        public Enterance()
        {
            Flats = new List<Flat>();
        }
    }
}
