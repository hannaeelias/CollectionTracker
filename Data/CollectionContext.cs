using CollectionTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class CollectionContext : DbContext
{
   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;database=CollectionTrackerDB;user=root;password=Jessica7793",
            new MySqlServerVersion(new Version(8, 0, 37))
        );
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<CollectionItem> CollectionItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var passwordHasher = new PasswordHasher<User>();

        var PasswordHash = passwordHasher.HashPassword(null, "admin!");

        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,  // Ensure positive UserId
                Username = "admin",
                PasswordHash = PasswordHash,
                AccessKey = "defaultAccessKey"
            }

        );

        // Seed initial data for the Collection table
        modelBuilder.Entity<Collection>().HasData(
            new Collection { CollectionId = 1, Name = "Comics", Description = "Collection of Marvel comics", UserId = 1 },
            new Collection { CollectionId = 2, Name = "Action Figures", Description = "Various superhero action figures", UserId = 1 }
        );

        // Seed initial data for the Item tale
        modelBuilder.Entity<Item>().HasData(
            new Item { ItemId = 1, Name = "Spider-Man #1", Category = "Comic", Description = "First issue of Spider-Man", Series = "Marvel Comics" },
            new Item { ItemId = 2, Name = "Iron Man Action Figure", Category = "Figure", Description = "Iron Man figurine", Series = "Marvel" }
        );

        // Seed initial data for the CollectionItem table
        modelBuilder.Entity<CollectionItem>().HasKey(ci => new { ci.CollectionId, ci.ItemId }); // Composite primary key
        modelBuilder.Entity<CollectionItem>().HasData(
            new CollectionItem { CollectionId = 1, ItemId = 1 }, // Correct IDs for Collection and Item
            new CollectionItem { CollectionId = 2, ItemId = 2 }  // Correct IDs for Collection and Item
        );
    }

    public void InitializeDatabase()
    {
        Database.EnsureCreated(); // Creates the database if it doesn’t exist
    }
}