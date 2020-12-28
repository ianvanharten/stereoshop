using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StereoShop.Models
{
    public class StereoShopContext : DbContext
    {
        public StereoShopContext(DbContextOptions options) :
            base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Record Player"},
                new Category { CategoryId = 2, Name = "Receiver"},
                new Category { CategoryId = 3, Name = "Speakers"}
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Code = "rp-sony",
                    Name = "Sony PS-LX310",
                    Price = 289.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    Code = "rp-audio-technica",
                    Name = "Audio-Technica AT-LP60",
                    Price = 229.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 1,
                    Code = "rp-toshiba",
                    Name = "Toshiba TY-LP200",
                    Price = 299.95,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 1,
                    Code = "rp-crosley",
                    Name = "Crosley CR800",
                    Price = 129.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 5,
                    CategoryId = 1,
                    Code = "rp-victrola",
                    Name = "Victrola VS-990",
                    Price = 99.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 6,
                    CategoryId = 2,
                    Code = "rec-yamaha",
                    Name = "Yamaha RX-397",
                    Price = 599.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 7,
                    CategoryId = 2,
                    Code = "rec-sony",
                    Name = "Sony STR-DH190",
                    Price = 249.95,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 8,
                    CategoryId = 2,
                    Code = "rec-pioneer",
                    Name = "Pioneer SX10",
                    Price = 349.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 9,
                    CategoryId = 2,
                    Code = "rec-onkyo",
                    Name = "Onkyo TX8220",
                    Price = 499.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 10,
                    CategoryId = 2,
                    Code = "rec-insignia",
                    Name = "Insignia NS-STR",
                    Price = 159.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 11,
                    CategoryId = 3,
                    Code = "sp-klipsch",
                    Name = "Klipsch R-820F",
                    Price = 550.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 12,
                    CategoryId = 3,
                    Code = "sp-polk",
                    Name = "Polk T50",
                    Price = 299.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 13,
                    CategoryId = 3,
                    Code = "sp-totem",
                    Name = "Totem Forest",
                    Price = 899.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 14,
                    CategoryId = 3,
                    Code = "sp-sony",
                    Name = "Sony SS-CS3",
                    Price = 389.99,
                    Quantity = 0
                },
                new Product
                {
                    ProductId = 15,
                    CategoryId = 3,
                    Code = "sp-jbl",
                    Name = "JBL A170",
                    Price = 409.99,
                    Quantity = 0
                }

            );
        }
    }
}
