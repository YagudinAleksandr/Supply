namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateElectricityPayments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ElectricityPayments", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ElectricityPayments", "Name");
        }
    }
}
