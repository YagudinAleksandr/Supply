namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoomMgr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        RoomID = c.Int(),
                        StartDate = c.String(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID)
                .Index(t => t.OrderID)
                .Index(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangeRooms", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.ChangeRooms", "OrderID", "dbo.Orders");
            DropIndex("dbo.ChangeRooms", new[] { "RoomID" });
            DropIndex("dbo.ChangeRooms", new[] { "OrderID" });
            DropTable("dbo.ChangeRooms");
        }
    }
}
