namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddElectricityOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElecricityOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        TenantID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(),
                        UpdatedAt = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.TenantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ElecricityOrders", "TenantID", "dbo.Tenants");
            DropIndex("dbo.ElecricityOrders", new[] { "TenantID" });
            DropTable("dbo.ElecricityOrders");
        }
    }
}
