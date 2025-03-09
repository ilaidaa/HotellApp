using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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





        // 2 konstruktor och en metod ska läggas till nedan. Allt detta för koppla till databas
        // Konstruktor 1 --> Migration
        public ApplicationDbContext()
        {

        }


        // Konstruktor 2 --> Options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        // Metoden som heter OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }



 
}
