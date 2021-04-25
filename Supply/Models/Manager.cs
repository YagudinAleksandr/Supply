using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Manager
    {
        public int ID { get; set; }
        public string Surename { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public ICollection<License> Licenses { get; set; }
        public Manager()
        {
            Licenses = new List<License>();
        }
    }
}
