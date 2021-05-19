namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ManagerID", c => c.Int());
            CreateIndex("dbo.Orders", "ManagerID");
            AddForeignKey("dbo.Orders", "ManagerID", "dbo.Managers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ManagerID", "dbo.Managers");
            DropIndex("dbo.Orders", new[] { "ManagerID" });
            DropColumn("dbo.Orders", "ManagerID");
        }
    }
}
