namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBenefit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Benefits", "ManagerID", "dbo.Managers");
            DropIndex("dbo.Benefits", new[] { "ManagerID" });
            AddColumn("dbo.Benefits", "LicenseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Benefits", "LicenseID");
            AddForeignKey("dbo.Benefits", "LicenseID", "dbo.Licenses", "ID", cascadeDelete: true);
            DropColumn("dbo.Benefits", "ManagerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Benefits", "ManagerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Benefits", "LicenseID", "dbo.Licenses");
            DropIndex("dbo.Benefits", new[] { "LicenseID" });
            DropColumn("dbo.Benefits", "LicenseID");
            CreateIndex("dbo.Benefits", "ManagerID");
            AddForeignKey("dbo.Benefits", "ManagerID", "dbo.Managers", "ID", cascadeDelete: true);
        }
    }
}
