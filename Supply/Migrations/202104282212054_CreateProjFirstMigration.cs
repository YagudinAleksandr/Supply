namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProjFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        House = c.String(nullable: false),
                        Housing = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Places = c.Int(nullable: false),
                        RoomTypeID = c.Int(),
                        FlatID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Flats", t => t.FlatID, cascadeDelete: true)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeID)
                .Index(t => t.RoomTypeID)
                .Index(t => t.FlatID);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Surename = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        Type = c.String(),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(),
                        UpdatedAt = c.String(),
                        ManagerID = c.Int(),
                        TenantTypeID = c.Int(),
                        RoomTypeID = c.Int(),
                        HostelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hostels", t => t.HostelID, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerID)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeID)
                .ForeignKey("dbo.TenantTypes", t => t.TenantTypeID)
                .Index(t => t.ManagerID)
                .Index(t => t.TenantTypeID)
                .Index(t => t.RoomTypeID)
                .Index(t => t.HostelID);
            
            CreateTable(
                "dbo.TenantTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Payments", "TenantTypeID", "dbo.TenantTypes");
            DropForeignKey("dbo.Payments", "RoomTypeID", "dbo.RoomTypes");
            DropForeignKey("dbo.Payments", "ManagerID", "dbo.Managers");
            DropForeignKey("dbo.Payments", "HostelID", "dbo.Hostels");
            DropForeignKey("dbo.Licenses", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Hostels", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Enterances", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.Rooms", "RoomTypeID", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "FlatID", "dbo.Flats");
            DropForeignKey("dbo.Flats", "Enterance_ID", "dbo.Enterances");
            DropForeignKey("dbo.Hostels", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Payments", new[] { "HostelID" });
            DropIndex("dbo.Payments", new[] { "RoomTypeID" });
            DropIndex("dbo.Payments", new[] { "TenantTypeID" });
            DropIndex("dbo.Payments", new[] { "ManagerID" });
            DropIndex("dbo.Licenses", new[] { "ManagerId" });
            DropIndex("dbo.Rooms", new[] { "FlatID" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeID" });
            DropIndex("dbo.Flats", new[] { "Enterance_ID" });
            DropIndex("dbo.Enterances", new[] { "HostelId" });
            DropIndex("dbo.Hostels", new[] { "ManagerId" });
            DropIndex("dbo.Hostels", new[] { "AddressID" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.TenantTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.Licenses");
            DropTable("dbo.Managers");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Flats");
            DropTable("dbo.Enterances");
            DropTable("dbo.Hostels");
            DropTable("dbo.Addresses");
        }
    }
}
