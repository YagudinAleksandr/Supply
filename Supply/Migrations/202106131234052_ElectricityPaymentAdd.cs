namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ElectricityPaymentAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElectricityPayments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HostelID = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hostels", t => t.HostelID, cascadeDelete: true)
                .Index(t => t.HostelID);
            
            AddColumn("dbo.Rooms", "ElectricityPaymentID", c => c.Int());
            CreateIndex("dbo.Rooms", "ElectricityPaymentID");
            AddForeignKey("dbo.Rooms", "ElectricityPaymentID", "dbo.ElectricityPayments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "ElectricityPaymentID", "dbo.ElectricityPayments");
            DropForeignKey("dbo.ElectricityPayments", "HostelID", "dbo.Hostels");
            DropIndex("dbo.ElectricityPayments", new[] { "HostelID" });
            DropIndex("dbo.Rooms", new[] { "ElectricityPaymentID" });
            DropColumn("dbo.Rooms", "ElectricityPaymentID");
            DropTable("dbo.ElectricityPayments");
        }
    }
}
