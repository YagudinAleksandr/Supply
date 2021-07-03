namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTerminationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Terminations", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Terminations", "Status");
        }
    }
}
