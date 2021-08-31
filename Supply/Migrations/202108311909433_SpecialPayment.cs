namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecialPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialPayments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenantID = c.Int(nullable: false),
                        RoomID = c.Int(),
                        Places = c.Int(nullable: false),
                        StartDate = c.String(),
                        EndDate = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomID)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.TenantID)
                .Index(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecialPayments", "TenantID", "dbo.Tenants");
            DropForeignKey("dbo.SpecialPayments", "RoomID", "dbo.Rooms");
            DropIndex("dbo.SpecialPayments", new[] { "RoomID" });
            DropIndex("dbo.SpecialPayments", new[] { "TenantID" });
            DropTable("dbo.SpecialPayments");
        }
    }
}
