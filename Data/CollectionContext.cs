using CollectionTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTracker.Data
{
    class CollectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Wishlist> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connection string herer");
            ///ik heb een probleem met sql server ik ben het aan het oplossen
        }
    }
}
