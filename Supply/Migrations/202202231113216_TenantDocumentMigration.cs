namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenantDocumentMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TenantDocuments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenantID = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.TenantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TenantDocuments", "TenantID", "dbo.Tenants");
            DropIndex("dbo.TenantDocuments", new[] { "TenantID" });
            DropTable("dbo.TenantDocuments");
        }
    }
}
