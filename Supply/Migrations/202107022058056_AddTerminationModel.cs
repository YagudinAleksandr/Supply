namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTerminationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Terminations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Terminations", "OrderID", "dbo.Orders");
            DropIndex("dbo.Terminations", new[] { "OrderID" });
            DropTable("dbo.Terminations");
        }
    }
}
