using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Context
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Classes.Customer> Customers { get; set; }
        public DbSet<Classes.Room> Rooms { get; set; } 
        public DbSet<Classes.Booking> Bookings { get; set; }
    }
}
