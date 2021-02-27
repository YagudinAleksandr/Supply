using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Additianal
    {
        //Дополнительные соглашения к договору
        public int ID { get; set; }//ID
        public int? OrderId { get; set; }//Номер договора
    }
}
