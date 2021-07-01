namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LastEnter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastEnter");
        }
    }
}
