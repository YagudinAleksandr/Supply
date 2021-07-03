namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTerminationModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Terminations", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Terminations", "Date");
        }
    }
}
