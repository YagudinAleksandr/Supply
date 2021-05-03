namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLogModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Caption = c.String(),
                        UserID = c.Int(),
                        Type = c.String(),
                        CreatedAt = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "UserID", "dbo.Users");
            DropIndex("dbo.Logs", new[] { "UserID" });
            DropTable("dbo.Logs");
        }
    }
}
