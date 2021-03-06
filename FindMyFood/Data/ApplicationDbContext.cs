﻿using System;
using FindMyFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindMyFood.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public static ApplicationDbContext instance;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
            instance = this;
        }

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Client> Client { get; set; }

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Restaurant>();
            builder.Entity<Client>();
            builder.Entity<Promotion>();
            builder.Entity<Rating>();
            builder.ApplyConfiguration(new AppUserConfig());
            builder.ApplyConfiguration(new RestaurantConfig());
            builder.ApplyConfiguration(new ClientConfig());
            builder.ApplyConfiguration(new AppRoleConfig());
            builder.ApplyConfiguration(new AppRoleClaimConfig());
            builder.ApplyConfiguration(new AppUserClaimConfig());
            builder.ApplyConfiguration(new AppUserLoginConfig());
            builder.ApplyConfiguration(new AppUserRoleConfig());
            builder.ApplyConfiguration(new AppUserTokenConfig());
            builder.ApplyConfiguration(new PromotionConfig());
            builder.ApplyConfiguration(new RatingConfig());
        }
    }
}