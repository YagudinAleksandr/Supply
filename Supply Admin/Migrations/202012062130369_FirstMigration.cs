namespace Supply_Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flats",
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
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.String(),
                        Price = c.Double(nullable: false),
                        Taks = c.Int(nullable:true),
                        TaksProcent = c.Double(nullable:true),
                        Description = c.String(nullable:true),
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
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Places = c.Int(),
                        Type = c.String(),
                        FlatId = c.Int(),
                        Hostels_Id = c.Int(nullable:true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flats", t => t.FlatId)
                .ForeignKey("dbo.Hostels", t => t.Hostels_Id)
                .Index(t => t.FlatId)
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
                        EducationType = c.String(),
                        ToTime = c.String(),
                        OrderStart = c.String(),
                        OrderEnd = c.String(),
                        Benifit = c.Int(nullable: false),
                        BenifitCategory = c.String(),
                        BenifitBase = c.String(),
                        BenefitStart = c.String(),
                        BenefitEnd = c.String(),
                        Status = c.Int(nullable: false),
                        RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.RoomId);
            
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
            DropForeignKey("dbo.Supplies", "HostelsId", "dbo.Hostels");
            DropForeignKey("dbo.Rooms", "Hostels_Id", "dbo.Hostels");
            DropForeignKey("dbo.Humen", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Garages", "RoomsId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "FlatId", "dbo.Flats");
            DropForeignKey("dbo.Rates", "RentId", "dbo.Rents");
            DropForeignKey("dbo.Rates", "HostelsId", "dbo.Hostels");
            DropForeignKey("dbo.Flats", "HostelsId", "dbo.Hostels");
            DropIndex("dbo.Supplies", new[] { "HostelsId" });
            DropIndex("dbo.Humen", new[] { "RoomId" });
            DropIndex("dbo.Garages", new[] { "RoomsId" });
            DropIndex("dbo.Rooms", new[] { "Hostels_Id" });
            DropIndex("dbo.Rooms", new[] { "FlatId" });
            DropIndex("dbo.Rates", new[] { "HostelsId" });
            DropIndex("dbo.Rates", new[] { "RentId" });
            DropIndex("dbo.Flats", new[] { "HostelsId" });
            DropTable("dbo.Supplies");
            DropTable("dbo.Humen");
            DropTable("dbo.Garages");
            DropTable("dbo.Rooms");
            DropTable("dbo.Rents");
            DropTable("dbo.Rates");
            DropTable("dbo.Hostels");
            DropTable("dbo.Flats");
        }
    }
}
