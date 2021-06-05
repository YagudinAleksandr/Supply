namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePasportUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChangePassports", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChangePassports", "Status", c => c.String(nullable: false));
        }
    }
}
