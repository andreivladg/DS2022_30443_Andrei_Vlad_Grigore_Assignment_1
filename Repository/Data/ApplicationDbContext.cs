using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid,
        IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = Guid.NewGuid(),
                UserName = "Admin",
                NormalizedUserName = "Admin",
                Role= AppRoleEnum.ADMINISTRATOR,
                Email = "adminApplication@gmail.com",
                NormalizedEmail = "adminApplication@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, ".Mer!d!@n12."),
                SecurityStamp = Guid.NewGuid().ToString()
            }) ;


            builder.Entity<AppUser>().HasMany(u => u.Devices).WithOne(d => d.User);
        }
    }
}
