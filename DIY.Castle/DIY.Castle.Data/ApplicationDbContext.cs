using DIY.Castle.Data.Models;
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
            builder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                Price = 0.80M,
                Name = "Book",
                Description = "This is just a sample product with short description.",
                CreatedOn = DateTime.UtcNow,
                ImageSourcePath = "/images/stock/book1.jpg"
            });

            builder.Entity<Product>().HasData(new Product()
            {
                Id = 2,
                Price = 0.05M,
                Name = "Book2",
                Description = "This is just a sample product with a medium description length.Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                CreatedOn = DateTime.UtcNow,
                ImageSourcePath = "/images/stock/book2.jpg"
            });

            builder.Entity<Product>().HasData(new Product()
            {
                Id = 3,
                Price = 150.00M,
                Name = "Book3",
                Description = "This is just a sample product with long description for testing the front-end.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam",
                CreatedOn = DateTime.UtcNow,
                ImageSourcePath = "/images/stock/book3.jpg"
            });

            base.OnModelCreating(builder);

        }
    }
}
