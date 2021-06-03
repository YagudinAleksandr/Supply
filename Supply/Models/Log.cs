﻿using System;

namespace Supply.Models
{
    public class Log
    {
        public Guid ID { get; set; }
        public string Caption { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
        public string Type { get; set; }
        public string CreatedAt { get; set; }

    }
}
