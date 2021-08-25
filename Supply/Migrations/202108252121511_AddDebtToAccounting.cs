namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDebtToAccounting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accountings", "Debt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accountings", "Debt");
        }
    }
}
