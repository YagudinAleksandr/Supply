namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBenefitPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BenefitPayments", "HostelID", c => c.Int(nullable: false));
            CreateIndex("dbo.BenefitPayments", "HostelID");
            AddForeignKey("dbo.BenefitPayments", "HostelID", "dbo.Hostels", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BenefitPayments", "HostelID", "dbo.Hostels");
            DropIndex("dbo.BenefitPayments", new[] { "HostelID" });
            DropColumn("dbo.BenefitPayments", "HostelID");
        }
    }
}
