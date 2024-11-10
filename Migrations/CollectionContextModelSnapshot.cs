﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollectionTracker.Migrations
{
    [DbContext(typeof(CollectionContext))]
    partial class CollectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CollectionTracker.Models.Collection", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CollectionId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CollectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Collections");

                    b.HasData(
                        new
                        {
                            CollectionId = 1,
                            Description = "Collection of Marvel comics",
                            Name = "Comics",
                            UserId = 1
                        },
                        new
                        {
                            CollectionId = 2,
                            Description = "Various superhero action figures",
                            Name = "Action Figures",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("CollectionTracker.Models.CollectionItem", b =>
                {
                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("CollectionId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("CollectionItems");

                    b.HasData(
                        new
                        {
                            CollectionId = 1,
                            ItemId = 1
                        },
                        new
                        {
                            CollectionId = 2,
                            ItemId = 2
                        });
                });

            modelBuilder.Entity("CollectionTracker.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Category = "Comic",
                            Description = "First issue of Spider-Man",
                            Name = "Spider-Man #1",
                            Series = "Marvel Comics"
                        },
                        new
                        {
                            ItemId = 2,
                            Category = "Figure",
                            Description = "Iron Man figurine",
                            Name = "Iron Man Action Figure",
                            Series = "Marvel"
                        });
                });

            modelBuilder.Entity("CollectionTracker.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("AccessKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            AccessKey = "defaultAccessKey",
                            PasswordHash = "AQAAAAIAAYagAAAAEEP3tNXKyjqNRbKsN5m7hxVM+TMliDLtK11iFyTQ+nIWcnLXrGEhIYiRN/IOsIXlCA==",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("CollectionTracker.Models.Wishlist", b =>
                {
                    b.Property<int>("WishlistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("WishlistId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WishlistId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("CollectionTracker.Models.Collection", b =>
                {
                    b.HasOne("CollectionTracker.Models.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollectionTracker.Models.CollectionItem", b =>
                {
                    b.HasOne("CollectionTracker.Models.Collection", "Collection")
                        .WithMany("CollectionItems")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollectionTracker.Models.Item", "Item")
                        .WithMany("CollectionItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CollectionTracker.Models.Wishlist", b =>
                {
                    b.HasOne("CollectionTracker.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollectionTracker.Models.User", "User")
                        .WithMany("Wishlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollectionTracker.Models.Collection", b =>
                {
                    b.Navigation("CollectionItems");
                });

            modelBuilder.Entity("CollectionTracker.Models.Item", b =>
                {
                    b.Navigation("CollectionItems");
                });

            modelBuilder.Entity("CollectionTracker.Models.User", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Wishlists");
                });
#pragma warning restore 612, 618
        }
    }
}
