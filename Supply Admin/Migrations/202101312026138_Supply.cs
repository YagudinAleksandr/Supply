namespace Supply_Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Benefits", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Benefits", "Price");
        }
    }
}
