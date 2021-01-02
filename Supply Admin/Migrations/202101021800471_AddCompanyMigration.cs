namespace Supply_Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Benefits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Proxy = c.String(),
                        ProxyDate = c.String(),
                        BenifitCat = c.String(),
                        Decree = c.String(),
                        DecreeDate = c.String(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartOrder = c.String(),
                        EndOrder = c.String(),
                        RentId = c.Int(),
                        HumanId = c.Int(),
                        Benifit = c.Int(nullable: false),
                        EducationType = c.String(),
                        Status = c.Int(nullable: false),
                        HostelsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelsId)
                .ForeignKey("dbo.Humen", t => t.HumanId)
                .ForeignKey("dbo.Rents", t => t.RentId)
                .Index(t => t.RentId)
                .Index(t => t.HumanId)
                .Index(t => t.HostelsId);
            
            CreateTable(
                "dbo.Hostels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Address = c.String(),
                        FlatCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        EnteranceId = c.Int(),
                        Hostels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enterances", t => t.EnteranceId)
                .ForeignKey("dbo.Hostels", t => t.Hostels_Id)
                .Index(t => t.EnteranceId)
                .Index(t => t.Hostels_Id);
            
            CreateTable(
                "dbo.Enterances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        HostelsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelsId)
                .Index(t => t.HostelsId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Places = c.Int(),
                        Type = c.String(),
                        FlatId = c.Int(),
                        Enterance_Id = c.Int(),
                        Hostels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flats", t => t.FlatId)
                .ForeignKey("dbo.Enterances", t => t.Enterance_Id)
                .ForeignKey("dbo.Hostels", t => t.Hostels_Id)
                .Index(t => t.FlatId)
                .Index(t => t.Enterance_Id)
                .Index(t => t.Hostels_Id);
            
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Numeric = c.String(),
                        DateStart = c.String(),
                        DateEnd = c.String(),
                        RoomsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomsId)
                .Index(t => t.RoomsId);
            
            CreateTable(
                "dbo.Humen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surename = c.String(),
                        Patronymic = c.String(nullable:true),
                        PhoneNumber = c.String(),
                        DocType = c.String(),
                        Series = c.String(),
                        Number = c.String(),
                        Given = c.String(),
                        GivenDate = c.String(),
                        GivenCode = c.String(),
                        Registration = c.String(),
                        Citizenship = c.String(),
                        RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.String(),
                        Price = c.Double(nullable: false),
                        Taks = c.Int(),
                        TaksProcent = c.Double(),
                        Description = c.String(),
                        RentId = c.Int(),
                        HostelsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelsId)
                .ForeignKey("dbo.Rents", t => t.RentId)
                .Index(t => t.RentId)
                .Index(t => t.HostelsId);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surename = c.String(),
                        Name = c.String(),
                        Patronimic = c.String(),
                        Proxy = c.String(),
                        ProxyDate = c.String(),
                        CreatedDate = c.String(),
                        HostelsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelsId)
                .Index(t => t.HostelsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Benefits", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "RentId", "dbo.Rents");
            DropForeignKey("dbo.Orders", "HumanId", "dbo.Humen");
            DropForeignKey("dbo.Orders", "HostelsId", "dbo.Hostels");
            DropForeignKey("dbo.Supplies", "HostelsId", "dbo.Hostels");
            DropForeignKey("dbo.Rooms", "Hostels_Id", "dbo.Hostels");
            DropForeignKey("dbo.Rates", "RentId", "dbo.Rents");
            DropForeignKey("dbo.Rates", "HostelsId", "dbo.Hostels");
            DropForeignKey("dbo.Flats", "Hostels_Id", "dbo.Hostels");
            DropForeignKey("dbo.Flats", "EnteranceId", "dbo.Enterances");
            DropForeignKey("dbo.Rooms", "Enterance_Id", "dbo.Enterances");
            DropForeignKey("dbo.Humen", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Garages", "RoomsId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "FlatId", "dbo.Flats");
            DropForeignKey("dbo.Enterances", "HostelsId", "dbo.Hostels");
            DropIndex("dbo.Supplies", new[] { "HostelsId" });
            DropIndex("dbo.Rates", new[] { "HostelsId" });
            DropIndex("dbo.Rates", new[] { "RentId" });
            DropIndex("dbo.Humen", new[] { "RoomId" });
            DropIndex("dbo.Garages", new[] { "RoomsId" });
            DropIndex("dbo.Rooms", new[] { "Hostels_Id" });
            DropIndex("dbo.Rooms", new[] { "Enterance_Id" });
            DropIndex("dbo.Rooms", new[] { "FlatId" });
            DropIndex("dbo.Enterances", new[] { "HostelsId" });
            DropIndex("dbo.Flats", new[] { "Hostels_Id" });
            DropIndex("dbo.Flats", new[] { "EnteranceId" });
            DropIndex("dbo.Orders", new[] { "HostelsId" });
            DropIndex("dbo.Orders", new[] { "HumanId" });
            DropIndex("dbo.Orders", new[] { "RentId" });
            DropIndex("dbo.Benefits", new[] { "OrderId" });
            DropTable("dbo.Supplies");
            DropTable("dbo.Rents");
            DropTable("dbo.Rates");
            DropTable("dbo.Humen");
            DropTable("dbo.Garages");
            DropTable("dbo.Rooms");
            DropTable("dbo.Enterances");
            DropTable("dbo.Flats");
            DropTable("dbo.Hostels");
            DropTable("dbo.Orders");
            DropTable("dbo.Benefits");
        }
    }
}
