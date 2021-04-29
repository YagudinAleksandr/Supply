namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "Name", c => c.Int(nullable: false));
        }
    }
}
