﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public string Surename { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }
        public string Proxy { get; set; }
        public string ProxyDate { get; set; }
        public string CreatedDate { get; set; }
        public int? HostelsId { get; set; }

        public Hostels hostels { get; set; }
    }
}
