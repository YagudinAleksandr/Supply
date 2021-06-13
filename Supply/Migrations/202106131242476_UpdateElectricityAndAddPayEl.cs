namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateElectricityAndAddPayEl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElectricityElements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ElectricityPaymentID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ElectricityPayments", t => t.ElectricityPaymentID, cascadeDelete: true)
                .Index(t => t.ElectricityPaymentID);
            
            DropColumn("dbo.ElectricityPayments", "Capacity");
            DropColumn("dbo.ElectricityPayments", "Payment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ElectricityPayments", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ElectricityPayments", "Capacity", c => c.Int(nullable: false));
            DropForeignKey("dbo.ElectricityElements", "ElectricityPaymentID", "dbo.ElectricityPayments");
            DropIndex("dbo.ElectricityElements", new[] { "ElectricityPaymentID" });
            DropTable("dbo.ElectricityElements");
        }
    }
}
