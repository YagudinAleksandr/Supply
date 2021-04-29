namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "ManagerID", "dbo.Managers");
            DropIndex("dbo.Payments", new[] { "ManagerID" });
            AddColumn("dbo.Payments", "UserID", c => c.Int());
            CreateIndex("dbo.Payments", "UserID");
            AddForeignKey("dbo.Payments", "UserID", "dbo.Users", "ID");
            DropColumn("dbo.Payments", "ManagerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "ManagerID", c => c.Int());
            DropForeignKey("dbo.Payments", "UserID", "dbo.Users");
            DropIndex("dbo.Payments", new[] { "UserID" });
            DropColumn("dbo.Payments", "UserID");
            CreateIndex("dbo.Payments", "ManagerID");
            AddForeignKey("dbo.Payments", "ManagerID", "dbo.Managers", "ID");
        }
    }
}
