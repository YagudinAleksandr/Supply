namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Properties", new[] { "RoomID" });
            DropTable("dbo.Properties");
        }
    }
}
