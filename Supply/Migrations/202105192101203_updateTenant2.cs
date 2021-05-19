namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTenant2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenants", "PaymentID", c => c.Int());
            CreateIndex("dbo.Tenants", "PaymentID");
            AddForeignKey("dbo.Tenants", "PaymentID", "dbo.Payments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenants", "PaymentID", "dbo.Payments");
            DropIndex("dbo.Tenants", new[] { "PaymentID" });
            DropColumn("dbo.Tenants", "PaymentID");
        }
    }
}
