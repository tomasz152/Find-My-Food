﻿// <auto-generated />
using Find_My_Food.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FindMyFood.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180415160228_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Find_My_Food.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("ClientId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<int?>("RestaurantId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("EmailUnique");

                    b.HasIndex("NormalizedEmail")
                        .IsUnique()
                        .HasName("NormEmailUnique");

                    b.HasIndex("RestaurantId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("FindMyFood.Areas.Restaurant.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("FindMyFood.Areas.Restaurant.Models.Favorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<int>("RestaurantId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("ClientId", "RestaurantId")
                        .IsUnique()
                        .HasName("FavUnique");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("FindMyFood.Areas.Restaurant.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateEnd");

                    b.Property<DateTime?>("DateStart");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("RestaurantId");

                    b.Property<string>("ShortDesc")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("FindMyFood.Areas.Restaurant.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("Find_My_Food.Models.ApplicationUser", b =>
                {
                    b.HasOne("FindMyFood.Areas.Restaurant.Models.Client", "Client")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindMyFood.Areas.Restaurant.Models.Restaurant", "Restaurant")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindMyFood.Areas.Restaurant.Models.Favorites", b =>
                {
                    b.HasOne("FindMyFood.Areas.Restaurant.Models.Client", "Client")
                        .WithMany("Favorites")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FindMyFood.Areas.Restaurant.Models.Restaurant", "Restaurant")
                        .WithMany("Favorites")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FindMyFood.Areas.Restaurant.Models.Promotion", b =>
                {
                    b.HasOne("FindMyFood.Areas.Restaurant.Models.Restaurant", "Restaurant")
                        .WithMany("Promotions")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Find_My_Food.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Find_My_Food.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Find_My_Food.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Find_My_Food.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
