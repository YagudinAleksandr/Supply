namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreaeteOrderModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        OrderNumber = c.String(nullable: false),
                        RoomID = c.Int(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.Tenants", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ID", "dbo.Tenants");
            DropForeignKey("dbo.Orders", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Orders", new[] { "RoomID" });
            DropIndex("dbo.Orders", new[] { "ID" });
            DropTable("dbo.Orders");
        }
    }
}
