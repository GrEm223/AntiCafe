using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccessContext : DbContext
    {
        public AccessContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<AccessContext>(new DropCreateDatabaseAlways<AccessContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
