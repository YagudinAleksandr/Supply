using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Hostels
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Address { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
        public ICollection<Flat> Flats { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Supply> Supplies { get; set; }
        public Hostels()
        {
            Rooms = new List<Rooms>();
            Flats = new List<Flat>();
            Rates = new List<Rate>();
            Supplies = new List<Supply>();
        }
    }
}
