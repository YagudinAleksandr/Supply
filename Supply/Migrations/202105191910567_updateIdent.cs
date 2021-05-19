namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateIdent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Identifications", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Identifications", "Code");
        }
    }
}
