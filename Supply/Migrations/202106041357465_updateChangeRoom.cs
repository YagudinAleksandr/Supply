namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateChangeRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChangeRooms", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChangeRooms", "Status");
        }
    }
}
