namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLicenseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Licenses", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Licenses", "Status");
        }
    }
}
