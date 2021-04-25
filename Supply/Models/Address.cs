using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    /*
     * Модель адресов (Служебный)
     */
    public class Address
    {
        public int ID { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Region { get; set; }
        [Required] 
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string House { get; set; }
        
        public string Housing { get; set; }
        [Required]
        public int ZipCode { get; set; }
    }
}
