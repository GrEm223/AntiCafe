using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class AccessContext: DbContext
    {
        public AccessContext():base ("DbConnection")
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
