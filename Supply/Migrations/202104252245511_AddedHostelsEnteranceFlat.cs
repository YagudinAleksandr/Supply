namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHostelsEnteranceFlat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enterances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HostelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hostels", t => t.HostelId, cascadeDelete: true)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.Flats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Enterance_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Enterances", t => t.Enterance_ID, cascadeDelete: true)
                .Index(t => t.Enterance_ID);
            
            CreateTable(
                "dbo.Hostels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressID = c.Int(),
                        ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .ForeignKey("dbo.Managers", t => t.ManagerId)
                .Index(t => t.AddressID)
                .Index(t => t.ManagerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enterances", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.Hostels", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Hostels", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Flats", "Enterance_ID", "dbo.Enterances");
            DropIndex("dbo.Hostels", new[] { "ManagerId" });
            DropIndex("dbo.Hostels", new[] { "AddressID" });
            DropIndex("dbo.Flats", new[] { "Enterance_ID" });
            DropIndex("dbo.Enterances", new[] { "HostelId" });
            DropTable("dbo.Hostels");
            DropTable("dbo.Flats");
            DropTable("dbo.Enterances");
        }
    }
}
