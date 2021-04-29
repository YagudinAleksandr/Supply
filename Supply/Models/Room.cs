using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Places { get; set; }
        public int? RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }

        [ForeignKey("Flat")]
        public int FlatID { get; set; }
        public Flat Flat { get; set; }

        public ICollection<Property> Properties { get; set; }
        public Room()
        {
            Properties = new List<Property>();
        }

    }
}
