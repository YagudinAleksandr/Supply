namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BenefitPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BenefitPayments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BenefitTypeID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BenefitTypes", t => t.BenefitTypeID, cascadeDelete: true)
                .Index(t => t.BenefitTypeID);
            
            CreateTable(
                "dbo.ContinueOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        LicenseID = c.Int(nullable: false),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Licenses", t => t.LicenseID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.LicenseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContinueOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.ContinueOrders", "LicenseID", "dbo.Licenses");
            DropForeignKey("dbo.BenefitPayments", "BenefitTypeID", "dbo.BenefitTypes");
            DropIndex("dbo.ContinueOrders", new[] { "LicenseID" });
            DropIndex("dbo.ContinueOrders", new[] { "OrderID" });
            DropIndex("dbo.BenefitPayments", new[] { "BenefitTypeID" });
            DropTable("dbo.ContinueOrders");
            DropTable("dbo.BenefitPayments");
        }
    }
}
