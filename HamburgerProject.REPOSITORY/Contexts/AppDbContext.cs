using HamburgerProject.CORE.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.REPOSITORY.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasMany(o => o.Sauces)
                .WithMany(s => s.Orders)
                .UsingEntity(x => x.ToTable("OrderSauce"));

            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Name = "admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Name = "user", NormalizedName = "USER" }
                );

            base.OnModelCreating(builder);
        }
    }
}
