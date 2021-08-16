namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTermination : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Terminations", "LicenceID", c => c.Int(nullable: false));
            AddColumn("dbo.Terminations", "License_ID", c => c.Int());
            CreateIndex("dbo.Terminations", "License_ID");
            AddForeignKey("dbo.Terminations", "License_ID", "dbo.Licenses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Terminations", "License_ID", "dbo.Licenses");
            DropIndex("dbo.Terminations", new[] { "License_ID" });
            DropColumn("dbo.Terminations", "License_ID");
            DropColumn("dbo.Terminations", "LicenceID");
        }
    }
}
