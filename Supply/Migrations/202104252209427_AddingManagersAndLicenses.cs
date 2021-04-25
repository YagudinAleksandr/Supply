namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingManagersAndLicenses : DbMigration
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
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Surename = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "ManagerId", "dbo.Managers");
            DropIndex("dbo.Licenses", new[] { "ManagerId" });
            DropTable("dbo.Managers");
            DropTable("dbo.Licenses");
            DropTable("dbo.Addresses");
        }
    }
}
