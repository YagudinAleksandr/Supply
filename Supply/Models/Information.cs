using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Models
{
    public class Information
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public bool Status { get; set; }
        public string StartInformation { get; set; }
        public string EndInformation { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
