namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBenefitPaymentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BenefitPayments", "House", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BenefitPayments", "Service", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BenefitPayments", "Electricity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BenefitPayments", "Electricity");
            DropColumn("dbo.BenefitPayments", "Service");
            DropColumn("dbo.BenefitPayments", "House");
        }
    }
}
