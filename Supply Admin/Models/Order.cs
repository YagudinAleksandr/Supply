using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Order
    {
        public int Id { get; set; } //Номер договора
        public string StartOrder { get; set; }//Дата начала договора
        public string EndOrder { get; set; }//Дата окончания договора
        public int? RentId { get; set; }
        public Rent Rent { get; set; }
        public int? HumanId { get; set; }
        public Human Human { get; set; }
        public int Benifit { get; set; }
        public string EducationType { get; set; }
        public int Status { get; set; }//Статус договра
        public int? HostelsId { get; set; }
        public Hostels Hostels { get; set; }
    }
}
