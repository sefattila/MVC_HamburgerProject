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
            var adminRoleId = Guid.NewGuid().ToString();

            builder.Entity<Order>()
                .HasMany(o => o.Sauces)
                .WithMany(s => s.Orders)
                .UsingEntity(x => x.ToTable("OrderSauce"));

            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Id = adminRoleId, Name = "admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id= Guid.NewGuid().ToString(), Name = "user", NormalizedName = "USER" }
                );


            var hash = new PasswordHasher<AppUser>();
            var adminUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "sefa",
                LastName = "attila",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = hash.HashPassword(null, "admin"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            builder.Entity<AppUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUser.Id
            });
            base.OnModelCreating(builder);
        }
    }
}
