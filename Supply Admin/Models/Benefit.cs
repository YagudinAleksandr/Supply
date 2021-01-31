using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Benefit
    {
        public int Id { get; set; }//Id
        public string Proxy { get; set; }//Доверенность номер
        public string ProxyDate { get; set; }//Дата доверенности
        public string BenifitCat { get; set; }//Категория льготы
        public string Decree { get; set; }//Приказ
        public string DecreeDate { get; set; }//Дата приказа
        public string StartDate { get; set; }//Начало льготы
        public string EndDate { get; set; }//Окончание льготы
        public int Price { get; set; }//Стоимость
        public int? OrderId { get; set; }//Договор №
        public Order Order { get; set; }
    }
}
