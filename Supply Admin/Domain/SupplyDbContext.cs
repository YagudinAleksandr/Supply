using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supply_Admin.Models;

namespace Supply_Admin.Domain
{
    
    public class SupplyDbContext:DbContext
    {
        public SupplyDbContext()
                : base("DbConnection")
        { }

        public DbSet<Hostels> Hostels { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Human> Humen { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Enterance> Enterances { get; set; }
    }
}
