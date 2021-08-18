using Supply.Models;
using System.Data.Entity;

namespace Supply.Domain
{
    public class SupplyDbContext : DbContext
    {
        /*
        public SupplyDbContext()
                : base(AppSettings.GetTemplateSetting("connectionString"))
        { }*/

        public SupplyDbContext()
                : base(Properties.Settings.Default.connect)
        { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Enterance> Enterances { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TenantType> TenantTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Property> PropertiesR { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Identification> Identifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AdditionalInformationType> AdditionalInformationTypes { get; set; }
        public DbSet<AdditionalInformation> AdditionalInformation { get; set; }
        public DbSet<BenefitType> BenefitTypes { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<ChangeRoom> ChangeRooms { get; set; }
        public DbSet<ChangePassport> ChangePassports { get; set; }
        public DbSet<Termination> Terminations { get; set; }
        public DbSet<Accounting> Accountings { get; set; }
        public DbSet<ElectricityPayment> ElectricityPayments { get; set; }
        public DbSet<ElectricityElement> ElectricityElements { get; set; } 
        public DbSet<ElecricityOrder> ElecricityOrders { get; set; }
        public DbSet<AccountingElectricity> AccountingElectricities { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<ContinueOrder> ContinueOrders { get; set; }
        public DbSet<BenefitPayment> BenefitPayments { get; set; }
    }
}
