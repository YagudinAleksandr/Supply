namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateChangePassport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChangePassports", "LicenseID", c => c.Int());
            CreateIndex("dbo.ChangePassports", "LicenseID");
            AddForeignKey("dbo.ChangePassports", "LicenseID", "dbo.Licenses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangePassports", "LicenseID", "dbo.Licenses");
            DropIndex("dbo.ChangePassports", new[] { "LicenseID" });
            DropColumn("dbo.ChangePassports", "LicenseID");
        }
    }
}
