using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class DocumentType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Identification> Identifications { get; set; }
        public DocumentType()
        {
            Identifications = new List<Identification>();
        }
    }
}
