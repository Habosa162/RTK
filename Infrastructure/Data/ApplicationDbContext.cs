using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Models;
using RetailEcommerce.Domain.Models.Core;
using RetailEcommerce.Domain.Models.CUSTOMERS___CREDIT;
using RetailEcommerce.Domain.Models.E_COMMERCE;
using RetailEcommerce.Domain.Models.INVENTORY;
using RetailEcommerce.Domain.Models.RETAIL;
using RetailEcommerce.Domain.Models.SHIPPING;

namespace RetailEcommerce.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        // Core Models
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // Orders (if you're using orders)
        public DbSet<Order> Orders { get; set; }
        // Inventory
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Domain.Models.INVENTORY.Branch> Branches { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        // Retail
        public DbSet<RetailTransaction> RetailTransactions { get; set; }
        public DbSet<RetailTransactionItem> RetailTransactionItems { get; set; }

        // Shipping
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
              new IdentityRole { Id = "1", ConcurrencyStamp = "1", Name = "Master", NormalizedName = "MASTER" },
              new IdentityRole { Id = "2", ConcurrencyStamp = "2", Name = "Admin", NormalizedName = "ADMIN" },
              new IdentityRole { Id = "3", ConcurrencyStamp = "3", Name = "Client", NormalizedName = "GYMOWNER" }
            );
        }
    }
}
