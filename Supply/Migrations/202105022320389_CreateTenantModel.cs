namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTenantModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(),
                        UpdatedAt = c.String(),
                        TenantTypeID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.TenantTypes", t => t.TenantTypeID, cascadeDelete: true)
                .Index(t => t.TenantTypeID)
                .Index(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenants", "TenantTypeID", "dbo.TenantTypes");
            DropForeignKey("dbo.Tenants", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Tenants", new[] { "RoomID" });
            DropIndex("dbo.Tenants", new[] { "TenantTypeID" });
            DropTable("dbo.Tenants");
        }
    }
}
