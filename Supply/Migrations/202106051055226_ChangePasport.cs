namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePasport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangePassports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenantID = c.Int(nullable: false),
                        Surename = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        DocumentTypeID = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Series = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        GivenDate = c.String(nullable: false),
                        Issued = c.String(nullable: false),
                        Citizenship = c.String(),
                        Address = c.String(),
                        DateOfBirth = c.String(),
                        StartDate = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.TenantID)
                .Index(t => t.DocumentTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangePassports", "TenantID", "dbo.Tenants");
            DropForeignKey("dbo.ChangePassports", "DocumentTypeID", "dbo.DocumentTypes");
            DropIndex("dbo.ChangePassports", new[] { "DocumentTypeID" });
            DropIndex("dbo.ChangePassports", new[] { "TenantID" });
            DropTable("dbo.ChangePassports");
        }
    }
}
