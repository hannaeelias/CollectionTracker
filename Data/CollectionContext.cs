using CollectionTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTracker.Data
{
    public class CollectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Wishlist> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
               "server=localhost;database=CollectionTrackerDB;user=root;password=Jessica7793",
                new MySqlServerVersion(new Version(8, 0, 37)) 
            );

        }
    }
}
