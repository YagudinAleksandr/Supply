using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Rooms
    {
        public int Id { get; set; }//ID
        public int Name { get; set; }//Название(номер)
        public int? Places { get; set; }//Кол-во мест
        public string Type { get; set; }//Тип помещения



        public int? FlatId { get; set; }//ID этажа
        public Flat Flat { get; set; }//Этаж

        public ICollection<Human> Humen { get; set; }
        public ICollection<Garage> Garages { get; set; }
        public Rooms()
        {
            Humen = new List<Human>();
            Garages = new List<Garage>();
        }
    }
}
