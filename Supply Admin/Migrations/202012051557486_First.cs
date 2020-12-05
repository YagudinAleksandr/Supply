namespace Supply_Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
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
                        SupplyManager = c.String(),
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
                        Type = c.String(),
                        Price = c.Double(nullable: false),
                        Taks = c.Int(nullable: false),
                        HostelId = c.Int(),
                        Hostels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.Hostels_Id)
                .Index(t => t.Hostels_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Places = c.Int(nullable: false),
                        Type = c.String(),
                        HostelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelId)
                .Index(t => t.HostelId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Humen", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.Rates", "Hostels_Id", "dbo.Hostels");
            DropForeignKey("dbo.Flats", "HostelsId", "dbo.Hostels");
            DropIndex("dbo.Humen", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "HostelId" });
            DropIndex("dbo.Rates", new[] { "Hostels_Id" });
            DropIndex("dbo.Flats", new[] { "HostelsId" });
            DropTable("dbo.Humen");
            DropTable("dbo.Rooms");
            DropTable("dbo.Rates");
            DropTable("dbo.Hostels");
            DropTable("dbo.Flats");
        }
    }
}
