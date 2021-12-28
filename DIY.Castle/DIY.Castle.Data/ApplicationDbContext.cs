using DIY.Castle.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DIY.Castle.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variation> Variations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Users
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser();
            adminUser.Id = "000AFADMIN000";
            adminUser.UserName = "admin@abv.bg";
            adminUser.NormalizedUserName = "ADMIN@ABV.BG";
            adminUser.Email = "admin@abv.bg";
            adminUser.NormalizedEmail = "ADMIN@ABV.BG";
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "123123123");
            adminUser.SecurityStamp = "000AFSECURITYSTAMP000";

            builder.Entity<ApplicationUser>().HasData(adminUser);

            // Roles
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole {
                   Id = "1", Name = GlobalConstants.UserRoles.USER_ROLE_NAME,
                   NormalizedName = GlobalConstants.UserRoles.USER_ROLE_NAME.ToUpper(),
               },
               new IdentityRole {
                   Id = "0", Name = GlobalConstants.UserRoles.ADMIN_ROLE_NAME,
                   NormalizedName = GlobalConstants.UserRoles.ADMIN_ROLE_NAME.ToUpper() 
               });

            // User Roles
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = "0", UserId = adminUser.Id });

            base.OnModelCreating(builder);

        }
    }
}
