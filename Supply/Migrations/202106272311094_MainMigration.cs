namespace Supply.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountingElectricities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ElecricityOrderID = c.Int(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        Coast = c.String(nullable: false),
                        PeriodStart = c.String(nullable: false),
                        PeriodEnd = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ElecricityOrders", t => t.ElecricityOrderID, cascadeDelete: true)
                .Index(t => t.ElecricityOrderID);
            
            CreateTable(
                "dbo.ElecricityOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        TenantID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(),
                        UpdatedAt = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.TenantID);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(),
                        UpdatedAt = c.String(),
                        TenantTypeID = c.Int(),
                        RoomID = c.Int(nullable: false),
                        PaymentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payments", t => t.PaymentID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.TenantTypes", t => t.TenantTypeID)
                .Index(t => t.TenantTypeID)
                .Index(t => t.RoomID)
                .Index(t => t.PaymentID);
            
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
            
            CreateTable(
                "dbo.ChangePassports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenantID = c.Int(nullable: false),
                        Surename = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        DocumentTypeID = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Series = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        GivenDate = c.String(nullable: false),
                        Issued = c.String(nullable: false),
                        Citizenship = c.String(),
                        Address = c.String(),
                        DateOfBirth = c.String(),
                        StartDate = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.TenantID)
                .Index(t => t.DocumentTypeID);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Identifications",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Surename = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Patronymic = c.String(),
                        DateOfBirth = c.String(nullable: false),
                        DocumentTypeID = c.Int(nullable: false),
                        DocumentSeries = c.String(nullable: false),
                        DocumentNumber = c.String(nullable: false),
                        GivenDate = c.String(nullable: false),
                        Issued = c.String(nullable: false),
                        Code = c.String(),
                        Cityzenship = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Tenants", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.DocumentTypeID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        OrderNumber = c.String(nullable: false),
                        RoomID = c.Int(nullable: false),
                        LicenseID = c.Int(),
                        CreatedAt = c.String(nullable: false),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Licenses", t => t.LicenseID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.Tenants", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.RoomID)
                .Index(t => t.LicenseID);
            
            CreateTable(
                "dbo.Benefits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        BasedOn = c.String(),
                        Payment = c.Double(nullable: false),
                        DecreeNumber = c.String(),
                        DecreeDate = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(),
                        UpdatedAt = c.String(),
                        BenefitTypeID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ManagerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BenefitTypes", t => t.BenefitTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.BenefitTypeID)
                .Index(t => t.OrderID)
                .Index(t => t.ManagerID);
            
            CreateTable(
                "dbo.BenefitTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Surename = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hostels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressID = c.Int(),
                        ManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .ForeignKey("dbo.Managers", t => t.ManagerId)
                .Index(t => t.AddressID)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        House = c.String(nullable: false),
                        Housing = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ElectricityPayments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HostelID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hostels", t => t.HostelID, cascadeDelete: true)
                .Index(t => t.HostelID);
            
            CreateTable(
                "dbo.Enterances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HostelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hostels", t => t.HostelId, cascadeDelete: true)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.Flats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Enterance_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Enterances", t => t.Enterance_ID, cascadeDelete: true)
                .Index(t => t.Enterance_ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Places = c.Int(nullable: false),
                        RoomTypeID = c.Int(),
                        ElectricityPaymentID = c.Int(),
                        FlatID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ElectricityPayments", t => t.ElectricityPaymentID)
                .ForeignKey("dbo.Flats", t => t.FlatID, cascadeDelete: true)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeID)
                .Index(t => t.RoomTypeID)
                .Index(t => t.ElectricityPaymentID)
                .Index(t => t.FlatID);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Service = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        PaymentType = c.String(nullable: false),
                        CreatedAt = c.String(),
                        UpdatedAt = c.String(),
                        UserID = c.Int(),
                        TenantTypeID = c.Int(),
                        RoomTypeID = c.Int(),
                        HostelID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hostels", t => t.HostelID)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeID)
                .ForeignKey("dbo.TenantTypes", t => t.TenantTypeID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.TenantTypeID)
                .Index(t => t.RoomTypeID)
                .Index(t => t.HostelID);
            
            CreateTable(
                "dbo.TenantTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        Type = c.String(),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.ChangeRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        RoomID = c.Int(),
                        StartDate = c.String(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID)
                .Index(t => t.OrderID)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.Accountings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenantID = c.Int(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        Coast = c.String(nullable: false),
                        PeriodStart = c.String(nullable: false),
                        PeriodEnd = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tenants", t => t.TenantID, cascadeDelete: true)
                .Index(t => t.TenantID);
            
            CreateTable(
                "dbo.ElectricityElements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ElectricityPaymentID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ElectricityPayments", t => t.ElectricityPaymentID, cascadeDelete: true)
                .Index(t => t.ElectricityPaymentID);
            
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
            DropForeignKey("dbo.ElectricityElements", "ElectricityPaymentID", "dbo.ElectricityPayments");
            DropForeignKey("dbo.Accountings", "TenantID", "dbo.Tenants");
            DropForeignKey("dbo.AccountingElectricities", "ElecricityOrderID", "dbo.ElecricityOrders");
            DropForeignKey("dbo.ElecricityOrders", "TenantID", "dbo.Tenants");
            DropForeignKey("dbo.Tenants", "TenantTypeID", "dbo.TenantTypes");
            DropForeignKey("dbo.Tenants", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Tenants", "PaymentID", "dbo.Payments");
            DropForeignKey("dbo.Orders", "ID", "dbo.Tenants");
            DropForeignKey("dbo.Orders", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Orders", "LicenseID", "dbo.Licenses");
            DropForeignKey("dbo.ChangeRooms", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.ChangeRooms", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Benefits", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Benefits", "ManagerID", "dbo.Managers");
            DropForeignKey("dbo.Licenses", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Payments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Payments", "TenantTypeID", "dbo.TenantTypes");
            DropForeignKey("dbo.Payments", "RoomTypeID", "dbo.RoomTypes");
            DropForeignKey("dbo.Payments", "HostelID", "dbo.Hostels");
            DropForeignKey("dbo.Hostels", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Enterances", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.Rooms", "RoomTypeID", "dbo.RoomTypes");
            DropForeignKey("dbo.Properties", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "FlatID", "dbo.Flats");
            DropForeignKey("dbo.Rooms", "ElectricityPaymentID", "dbo.ElectricityPayments");
            DropForeignKey("dbo.Flats", "Enterance_ID", "dbo.Enterances");
            DropForeignKey("dbo.ElectricityPayments", "HostelID", "dbo.Hostels");
            DropForeignKey("dbo.Hostels", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Benefits", "BenefitTypeID", "dbo.BenefitTypes");
            DropForeignKey("dbo.ChangePassports", "TenantID", "dbo.Tenants");
            DropForeignKey("dbo.ChangePassports", "DocumentTypeID", "dbo.DocumentTypes");
            DropForeignKey("dbo.Identifications", "ID", "dbo.Tenants");
            DropForeignKey("dbo.Identifications", "DocumentTypeID", "dbo.DocumentTypes");
            DropForeignKey("dbo.AdditionalInformations", "TenantID", "dbo.Tenants");
            DropForeignKey("dbo.AdditionalInformations", "AdditionalInformationTypeID", "dbo.AdditionalInformationTypes");
            DropIndex("dbo.Logs", new[] { "UserID" });
            DropIndex("dbo.ElectricityElements", new[] { "ElectricityPaymentID" });
            DropIndex("dbo.Accountings", new[] { "TenantID" });
            DropIndex("dbo.ChangeRooms", new[] { "RoomID" });
            DropIndex("dbo.ChangeRooms", new[] { "OrderID" });
            DropIndex("dbo.Licenses", new[] { "ManagerId" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Payments", new[] { "HostelID" });
            DropIndex("dbo.Payments", new[] { "RoomTypeID" });
            DropIndex("dbo.Payments", new[] { "TenantTypeID" });
            DropIndex("dbo.Payments", new[] { "UserID" });
            DropIndex("dbo.Properties", new[] { "RoomID" });
            DropIndex("dbo.Rooms", new[] { "FlatID" });
            DropIndex("dbo.Rooms", new[] { "ElectricityPaymentID" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeID" });
            DropIndex("dbo.Flats", new[] { "Enterance_ID" });
            DropIndex("dbo.Enterances", new[] { "HostelId" });
            DropIndex("dbo.ElectricityPayments", new[] { "HostelID" });
            DropIndex("dbo.Hostels", new[] { "ManagerId" });
            DropIndex("dbo.Hostels", new[] { "AddressID" });
            DropIndex("dbo.Benefits", new[] { "ManagerID" });
            DropIndex("dbo.Benefits", new[] { "OrderID" });
            DropIndex("dbo.Benefits", new[] { "BenefitTypeID" });
            DropIndex("dbo.Orders", new[] { "LicenseID" });
            DropIndex("dbo.Orders", new[] { "RoomID" });
            DropIndex("dbo.Orders", new[] { "ID" });
            DropIndex("dbo.Identifications", new[] { "DocumentTypeID" });
            DropIndex("dbo.Identifications", new[] { "ID" });
            DropIndex("dbo.ChangePassports", new[] { "DocumentTypeID" });
            DropIndex("dbo.ChangePassports", new[] { "TenantID" });
            DropIndex("dbo.AdditionalInformations", new[] { "TenantID" });
            DropIndex("dbo.AdditionalInformations", new[] { "AdditionalInformationTypeID" });
            DropIndex("dbo.Tenants", new[] { "PaymentID" });
            DropIndex("dbo.Tenants", new[] { "RoomID" });
            DropIndex("dbo.Tenants", new[] { "TenantTypeID" });
            DropIndex("dbo.ElecricityOrders", new[] { "TenantID" });
            DropIndex("dbo.AccountingElectricities", new[] { "ElecricityOrderID" });
            DropTable("dbo.Logs");
            DropTable("dbo.ElectricityElements");
            DropTable("dbo.Accountings");
            DropTable("dbo.ChangeRooms");
            DropTable("dbo.Licenses");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.TenantTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Properties");
            DropTable("dbo.Rooms");
            DropTable("dbo.Flats");
            DropTable("dbo.Enterances");
            DropTable("dbo.ElectricityPayments");
            DropTable("dbo.Addresses");
            DropTable("dbo.Hostels");
            DropTable("dbo.Managers");
            DropTable("dbo.BenefitTypes");
            DropTable("dbo.Benefits");
            DropTable("dbo.Orders");
            DropTable("dbo.Identifications");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.ChangePassports");
            DropTable("dbo.AdditionalInformationTypes");
            DropTable("dbo.AdditionalInformations");
            DropTable("dbo.Tenants");
            DropTable("dbo.ElecricityOrders");
            DropTable("dbo.AccountingElectricities");
        }
    }
}
