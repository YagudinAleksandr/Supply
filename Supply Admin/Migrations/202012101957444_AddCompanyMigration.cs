namespace Supply_Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Hostels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Address = c.String(),
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
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Places = c.Int(),
                        Type = c.String(),
                        FlatId = c.Int(),
                        Hostels_Id = c.Int(),
                        Enterance_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flats", t => t.FlatId)
                .ForeignKey("dbo.Hostels", t => t.Hostels_Id)
                .ForeignKey("dbo.Enterances", t => t.Enterance_Id)
                .Index(t => t.FlatId)
                .Index(t => t.Hostels_Id)
                .Index(t => t.Enterance_Id);
            
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
                        Patronymic = c.String(),
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
                        Taks = c.Int(nullable:true),
                        TaksProcent = c.Double(nullable:true),
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
                        Name = c.String(),
                        CreatedDate = c.String(),
                        HostelsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelsId)
                .Index(t => t.HostelsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Enterance_Id", "dbo.Enterances");
            DropForeignKey("dbo.Enterances", "HostelsId", "dbo.Hostels");
            DropForeignKey("dbo.Supplies", "HostelsId", "dbo.Hostels");
            DropForeignKey("dbo.Rooms", "Hostels_Id", "dbo.Hostels");
            DropForeignKey("dbo.Rates", "RentId", "dbo.Rents");
            DropForeignKey("dbo.Rates", "HostelsId", "dbo.Hostels");
            DropForeignKey("dbo.Flats", "Hostels_Id", "dbo.Hostels");
            DropForeignKey("dbo.Humen", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Garages", "RoomsId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "FlatId", "dbo.Flats");
            DropForeignKey("dbo.Flats", "EnteranceId", "dbo.Enterances");
            DropIndex("dbo.Supplies", new[] { "HostelsId" });
            DropIndex("dbo.Rates", new[] { "HostelsId" });
            DropIndex("dbo.Rates", new[] { "RentId" });
            DropIndex("dbo.Humen", new[] { "RoomId" });
            DropIndex("dbo.Garages", new[] { "RoomsId" });
            DropIndex("dbo.Rooms", new[] { "Enterance_Id" });
            DropIndex("dbo.Rooms", new[] { "Hostels_Id" });
            DropIndex("dbo.Rooms", new[] { "FlatId" });
            DropIndex("dbo.Flats", new[] { "Hostels_Id" });
            DropIndex("dbo.Flats", new[] { "EnteranceId" });
            DropIndex("dbo.Enterances", new[] { "HostelsId" });
            DropTable("dbo.Supplies");
            DropTable("dbo.Rents");
            DropTable("dbo.Rates");
            DropTable("dbo.Humen");
            DropTable("dbo.Garages");
            DropTable("dbo.Rooms");
            DropTable("dbo.Flats");
            DropTable("dbo.Hostels");
            DropTable("dbo.Enterances");
        }
    }
}
