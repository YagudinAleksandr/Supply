using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
