using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Garage
    {
        public int Id { get; set; } //ID
        public string Name { get; set; }//Название
        public string Numeric { get; set; }//Инвентарный номер
        public string DateStart { get; set; }//Поставлен на учет
        public string DateEnd { get; set; }//Снфт с учета
        public int? RoomsId { get; set; }//Номер комнаты
        public Rooms Rooms { get; set; }
    }
}
