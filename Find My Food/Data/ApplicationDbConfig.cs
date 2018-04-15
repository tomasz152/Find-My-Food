﻿using FindMyFood.Areas.Restaurant.Models;
using Find_My_Food.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindMyFood.Areas.Restaurant.Data
{
    internal class AppUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder) {
            builder.ToTable("AppUsers");
            builder.Ignore(user => user.PhoneNumber);
            builder.Ignore(user => user.PhoneNumberConfirmed);
            builder.Ignore(user => user.UserName);
            builder.Ignore(user => user.NormalizedUserName);
            builder.HasIndex(e => e.ClientId);
            builder.HasIndex(e => e.RestaurantId);
            builder.HasOne(d => d.Client)
                   .WithMany(p => p.ApplicationUser)
                   .HasForeignKey(d => d.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Restaurant)
                   .WithMany(p => p.ApplicationUser)
                   .HasForeignKey(d => d.RestaurantId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(e => new { e.Email })
                   .HasName("EmailUnique")
                   .IsUnique();
            builder.HasIndex(e => new { e.NormalizedEmail })
                   .HasName("NormEmailUnique")
                   .IsUnique();
        }
    }

    internal class RestaurantConfig : IEntityTypeConfiguration<Models.Restaurant>
    {
        public void Configure(EntityTypeBuilder<Models.Restaurant> builder) {
            builder.ToTable("Restaurants");
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.Address).IsRequired();
            builder.Property(user => user.Latitude).IsRequired();
            builder.Property(user => user.Longitude).IsRequired();
            //builder.Property(user => user.AppUser).IsRequired();
        }
    }

    internal class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder) {
            builder.ToTable("Clients");
            builder.Property(user => user.Name).IsRequired();
            //builder.Property(user => user.AppUser).IsRequired();
        }
    }

    internal class AppRoleConfig : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder) {
            builder.ToTable("AppRoles");
        }
    }

    internal class AppRoleClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder) {
            builder.ToTable("AppRoleClaims");
        }
    }

    internal class AppUserLoginConfig : IEntityTypeConfiguration<IdentityUserLogin<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> builder) {
            builder.ToTable("AppUserLogins");
        }
    }

    internal class AppUserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder) {
            builder.ToTable("AppUserClaims");
        }
    }

    internal class AppUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder) {
            builder.ToTable("AppUserRoles");
        }
    }

    internal class AppUserTokenConfig : IEntityTypeConfiguration<IdentityUserToken<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder) {
            builder.ToTable("AppUserTokens");
        }
    }

    internal class PromotionConfig : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder) {
            builder.ToTable("Promotions");
            builder.Property(promotion => promotion.Description).IsRequired();
            builder.Property(promotion => promotion.ShortDesc).IsRequired();
            builder.HasIndex(e => e.RestaurantId);
            builder.HasOne(d => d.Restaurant)
                   .WithMany(p => p.Promotions)
                   .HasForeignKey(d => d.RestaurantId);
        }
    }

    internal class FavoritesConfig : IEntityTypeConfiguration<Favorites>
    {
        public void Configure(EntityTypeBuilder<Favorites> builder) {
            builder.ToTable("Favorites");
            builder.HasIndex(e => e.ClientId);

            builder.HasIndex(e => e.RestaurantId);

            builder.HasIndex(e => new {e.ClientId, e.RestaurantId})
                   .HasName("FavUnique")
                   .IsUnique();

            builder.HasOne(d => d.Client)
                   .WithMany(p => p.Favorites)
                   .HasForeignKey(d => d.ClientId);

            builder.HasOne(d => d.Restaurant)
                   .WithMany(p => p.Favorites)
                   .HasForeignKey(d => d.RestaurantId);
        }
    }
}