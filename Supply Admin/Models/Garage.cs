using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Garage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Numeric { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public int? RoomsId { get; set; }
        public Rooms Rooms { get; set; }
    }
}
