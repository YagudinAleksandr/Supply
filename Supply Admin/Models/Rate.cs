using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Rate
    {
        public int Id { get; set; }//ID
        public string Name { get; set; }//Наименование тарифа
        public string CreationDate { get; set; }//Дата создания
        public double Price { get; set; }//Цена
        public int? Taks { get; set; }//НДС
        public double? TaksProcent { get; set; }//Процент НДС
        public string Description { get; set; }//Описание


        public int? RentId { get; set; }//Тип арендатора
        public Rent Rent { get; set; }//Типы аренды


        public int? HostelsId { get; set; }//ID общежития
        public Hostels Hostels { get; set; }//Общежития
    }
}
