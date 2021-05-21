using System.ComponentModel.DataAnnotations.Schema;

namespace Supply.Models
{
    public class Benefit
    {
        public int ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string BasedOn { get; set; }
        public double Payment { get; set; }
        public string DecreeNumber { get; set; }
        public string DecreeDate { get; set; }
        public bool Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        [ForeignKey("BenefitType")]
        public int BenefitTypeID { get; set; }
        public BenefitType BenefitType { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Manager")]
        public int ManagerID { get; set; }
        public Manager Manager { get; set; }
    }
}
