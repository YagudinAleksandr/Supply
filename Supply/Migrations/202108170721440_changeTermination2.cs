namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTermination2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Terminations", "License_ID", "dbo.Licenses");
            DropIndex("dbo.Terminations", new[] { "License_ID" });
            RenameColumn(table: "dbo.Terminations", name: "License_ID", newName: "LicenseID");
            AlterColumn("dbo.Terminations", "LicenseID", c => c.Int(nullable: true));
            CreateIndex("dbo.Terminations", "LicenseID");
            AddForeignKey("dbo.Terminations", "LicenseID", "dbo.Licenses", "ID", cascadeDelete: true);
            DropColumn("dbo.Terminations", "LicenceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Terminations", "LicenceID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Terminations", "LicenseID", "dbo.Licenses");
            DropIndex("dbo.Terminations", new[] { "LicenseID" });
            AlterColumn("dbo.Terminations", "LicenseID", c => c.Int());
            RenameColumn(table: "dbo.Terminations", name: "LicenseID", newName: "License_ID");
            CreateIndex("dbo.Terminations", "License_ID");
            AddForeignKey("dbo.Terminations", "License_ID", "dbo.Licenses", "ID");
        }
    }
}
