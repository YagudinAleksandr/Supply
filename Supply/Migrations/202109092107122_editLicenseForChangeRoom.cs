namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editLicenseForChangeRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChangeRooms", "LicenseID", c => c.Int());
            CreateIndex("dbo.ChangeRooms", "LicenseID");
            AddForeignKey("dbo.ChangeRooms", "LicenseID", "dbo.Licenses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangeRooms", "LicenseID", "dbo.Licenses");
            DropIndex("dbo.ChangeRooms", new[] { "LicenseID" });
            DropColumn("dbo.ChangeRooms", "LicenseID");
        }
    }
}
