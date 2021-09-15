namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class electricitySpecialPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecialPayments", "ElectricityPaymentID", c => c.Int());
            AddColumn("dbo.SpecialPayments", "ElectricityPaymentPlaces", c => c.Int());
            CreateIndex("dbo.SpecialPayments", "ElectricityPaymentID");
            AddForeignKey("dbo.SpecialPayments", "ElectricityPaymentID", "dbo.ElectricityPayments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecialPayments", "ElectricityPaymentID", "dbo.ElectricityPayments");
            DropIndex("dbo.SpecialPayments", new[] { "ElectricityPaymentID" });
            DropColumn("dbo.SpecialPayments", "ElectricityPaymentPlaces");
            DropColumn("dbo.SpecialPayments", "ElectricityPaymentID");
        }
    }
}
