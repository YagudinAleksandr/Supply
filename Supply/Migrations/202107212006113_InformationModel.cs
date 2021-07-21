namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InformationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Topic = c.String(),
                        Status = c.Boolean(nullable: false),
                        StartInformation = c.String(),
                        EndInformation = c.String(),
                        CreatedAt = c.String(),
                        UpdatedAt = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Information");
        }
    }
}
