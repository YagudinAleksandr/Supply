﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Flat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("Enterance")]
        public int Enterance_ID { get; set; }
        public Enterance Enterance { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public Flat()
        {
            Rooms = new List<Room>();
        }
    }
}
