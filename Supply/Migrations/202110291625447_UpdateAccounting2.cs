namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccounting2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accountings", "LastPayEnterCoast", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Accountings", "LasPayDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accountings", "LasPayDay");
            DropColumn("dbo.Accountings", "LastPayEnterCoast");
        }
    }
}
