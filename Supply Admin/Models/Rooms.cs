using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Places { get; set; }
        public string Type { get; set; }



        public int? FlatId { get; set; }
        public Flat Flat { get; set; }

        public ICollection<Human> Humen { get; set; }
        public Rooms()
        {
            Humen = new List<Human>();
        }
    }
}
