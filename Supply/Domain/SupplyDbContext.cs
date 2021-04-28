using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Domain
{
    public class SupplyDbContext : DbContext
    {
        public SupplyDbContext()
                : base(Properties.Settings.Default.DatabaseConnection.ToString())
        { }

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
    }
}
