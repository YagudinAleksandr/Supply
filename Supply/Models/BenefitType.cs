using System.Collections.Generic;

namespace Supply.Models
{
    public class BenefitType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Benefit> Benefits { get; set; }
        public BenefitType()
        {
            Benefits = new List<Benefit>();
        }
    }
}
