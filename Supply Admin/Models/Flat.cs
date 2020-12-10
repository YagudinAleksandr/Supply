﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int? EnteranceId { get; set; }
        public Enterance Enterance { get; set; }

        public ICollection<Rooms> Rooms { get; set; }
        public Flat()
        {
            Rooms = new List<Rooms>();
        }
    }
}
