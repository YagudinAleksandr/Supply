namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "PaymentType");
        }
    }
}
