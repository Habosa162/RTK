using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Models;

namespace RetailEcommerce.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
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
