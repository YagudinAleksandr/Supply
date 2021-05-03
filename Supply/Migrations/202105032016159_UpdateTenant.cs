namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTenant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tenants", "TenantTypeID", "dbo.TenantTypes");
            DropIndex("dbo.Tenants", new[] { "TenantTypeID" });
            AlterColumn("dbo.Tenants", "TenantTypeID", c => c.Int());
            CreateIndex("dbo.Tenants", "TenantTypeID");
            AddForeignKey("dbo.Tenants", "TenantTypeID", "dbo.TenantTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenants", "TenantTypeID", "dbo.TenantTypes");
            DropIndex("dbo.Tenants", new[] { "TenantTypeID" });
            AlterColumn("dbo.Tenants", "TenantTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tenants", "TenantTypeID");
            AddForeignKey("dbo.Tenants", "TenantTypeID", "dbo.TenantTypes", "ID", cascadeDelete: true);
        }
    }
}
