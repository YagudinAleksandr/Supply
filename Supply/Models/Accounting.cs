﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class Accounting
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Tenant")]
        public int TenantID { get; set; }
        public Tenant Tenant { get; set; }
        [Required]
        public string CreatedAt { get; set; }
        [Required]
        public string Coast { get; set; }
        [Required]
        public string Debt { get; set; }
        [Required]
        public string PeriodStart { get; set; }
        [Required]
        public string PeriodEnd { get; set; }
        public decimal LastPayEnterCoast { get; set; }
        public string LasPayDay { get; set; }
    }
}
