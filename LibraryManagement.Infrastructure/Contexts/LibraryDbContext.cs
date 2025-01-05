using LibraryManagement.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Contexts
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed users
            var hasher = new PasswordHasher<ApplicationUser>();

            var user1 = new ApplicationUser
            {
                Id = "1", // Primary key
                UserName = "test1",
                NormalizedUserName = "TEST1",
                Email = "test1@example.com",
                NormalizedEmail = "TEST1@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Test@123"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var user2 = new ApplicationUser
            {
                Id = "2",
                UserName = "test2",
                NormalizedUserName = "TEST2",
                Email = "test2@example.com",
                NormalizedEmail = "TEST2@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Test@123"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var admin = new ApplicationUser
            {
                Id = "3",
                UserName = "libraryadmin",
                NormalizedUserName = "LIBRARYADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            builder.Entity<ApplicationUser>().HasData(user1, user2, admin);

            // Seed roles
            var adminRole = new IdentityRole
            {
                Id = "101",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            builder.Entity<IdentityRole>().HasData(adminRole);

            // Seed user roles
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "3", // libraryadmin
                RoleId = "101" // Admin
            });
        }
    }

}