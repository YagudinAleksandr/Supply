namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTenantInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Identifications",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Surename = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(),
                        DateOfBirth = c.String(nullable: false),
                        DocumentTypeID = c.Int(nullable: false),
                        DocumentSeries = c.String(nullable: false),
                        DocumentNumber = c.String(nullable: false),
                        GivenDate = c.String(nullable: false),
                        Issued = c.String(nullable: false),
                        Cityzenship = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Tenants", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.DocumentTypeID);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Identifications", "ID", "dbo.Tenants");
            DropForeignKey("dbo.Identifications", "DocumentTypeID", "dbo.DocumentTypes");
            DropIndex("dbo.Identifications", new[] { "DocumentTypeID" });
            DropIndex("dbo.Identifications", new[] { "ID" });
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Identifications");
        }
    }
}
