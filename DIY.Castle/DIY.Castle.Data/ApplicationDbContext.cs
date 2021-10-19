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

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Users
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser();
            adminUser.Id = new Guid().ToString();
            adminUser.UserName = "admin@abv.bg";
            adminUser.NormalizedUserName = "ADMIN@ABV.BG";
            adminUser.Email = "admin@abv.bg";
            adminUser.NormalizedEmail = "ADMIN@ABV.BG";
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "123123123");
            adminUser.SecurityStamp = Guid.NewGuid().ToString();

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

            // Products
            builder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                Price = 0.80M,
                Name = "Book",
                ProductType = "Icon",
                Description = "This is just a sample product with short description.",
                CreatedOn = DateTime.UtcNow,
                ImageSourcePath = "/images/stock/book1.jpg"
            });

            builder.Entity<Product>().HasData(new Product()
            {
                Id = 2,
                Price = 0.05M,
                Name = "Book2",
                ProductType = "BookSeparator",
                Description = "This is just a sample product with a medium description length.Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                CreatedOn = DateTime.UtcNow,
                ImageSourcePath = "/images/stock/book2.jpg"
            });

            builder.Entity<Product>().HasData(new Product()
            {
                Id = 3,
                Price = 150.00M,
                Name = "Book3",
                ProductType = "Candle",
                Description = "This is just a sample product with long description for testing the front-end.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam",
                CreatedOn = DateTime.UtcNow,
                ImageSourcePath = "/images/stock/book3.jpg"
            });

            base.OnModelCreating(builder);

        }
    }
}
