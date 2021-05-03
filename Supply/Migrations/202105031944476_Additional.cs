namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Additional : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalInformations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdditionalInformationTypeID = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                        TenantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AdditionalInformationTypes", t => t.AdditionalInformationTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.AdditionalInformationTypeID)
                .Index(t => t.TenantID);
            
            CreateTable(
                "dbo.AdditionalInformationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdditionalInformations", "TenantID", "dbo.Tenants");
            DropForeignKey("dbo.AdditionalInformations", "AdditionalInformationTypeID", "dbo.AdditionalInformationTypes");
            DropIndex("dbo.AdditionalInformations", new[] { "TenantID" });
            DropIndex("dbo.AdditionalInformations", new[] { "AdditionalInformationTypeID" });
            DropTable("dbo.AdditionalInformationTypes");
            DropTable("dbo.AdditionalInformations");
        }
    }
}
