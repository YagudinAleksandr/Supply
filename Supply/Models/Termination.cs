﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Termination
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string UpdatedAt { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Date { get; set; }
    }
}
