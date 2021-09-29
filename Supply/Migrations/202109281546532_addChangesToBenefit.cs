namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChangesToBenefit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Benefits", "House", c => c.Double(nullable: false));
            AddColumn("dbo.Benefits", "Service", c => c.Double(nullable: false));
            AddColumn("dbo.Benefits", "Electricity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Benefits", "Electricity");
            DropColumn("dbo.Benefits", "Service");
            DropColumn("dbo.Benefits", "House");
        }
    }
}
