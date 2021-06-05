namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccounting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenantID = c.Int(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        Coast = c.String(nullable: false),
                        PeriodStart = c.String(nullable: false),
                        PeriodEnd = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.TenantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accountings", "TenantID", "dbo.Tenants");
            DropIndex("dbo.Accountings", new[] { "TenantID" });
            DropTable("dbo.Accountings");
        }
    }
}
