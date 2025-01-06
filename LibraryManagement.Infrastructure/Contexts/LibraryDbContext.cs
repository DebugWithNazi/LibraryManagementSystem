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
                UserName = "john.doe",
                NormalizedUserName = "JOHN.DOE",
                Email = "john.doe@example.com",
                NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var user2 = new ApplicationUser
            {
                Id = "2",
                UserName = "jane.smith",
                NormalizedUserName = "JANE.SMITH",
                Email = "jane.smith@example.com",
                NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!"),
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

            // Seed books
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Edition = "1st",
                    Publisher = "J.B. Lippincott & Co.",
                    ISBN = "9780061120084",
                    Genre = "Fiction",
                    PageCount = 281,
                    Language = "English",
                    PublicationYear = 1960,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    Author = "George Orwell",
                    Edition = "1st",
                    Publisher = "Secker & Warburg",
                    ISBN = "9780451524935",
                    Genre = "Dystopian",
                    PageCount = 328,
                    Language = "English",
                    PublicationYear = 1949,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 3,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Edition = "2nd",
                    Publisher = "T. Egerton",
                    ISBN = "9780141439518",
                    Genre = "Romance",
                    PageCount = 279,
                    Language = "English",
                    PublicationYear = 1813,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 4,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Edition = "1st",
                    Publisher = "Charles Scribner's Sons",
                    ISBN = "9780743273565",
                    Genre = "Fiction",
                    PageCount = 180,
                    Language = "English",
                    PublicationYear = 1925,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 5,
                    Title = "Moby-Dick",
                    Author = "Herman Melville",
                    Edition = "1st",
                    Publisher = "Harper & Brothers",
                    ISBN = "9780142437247",
                    Genre = "Adventure",
                    PageCount = 635,
                    Language = "English",
                    PublicationYear = 1851,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 6,
                    Title = "War and Peace",
                    Author = "Leo Tolstoy",
                    Edition = "1st",
                    Publisher = "The Russian Messenger",
                    ISBN = "9780199232765",
                    Genre = "Historical Fiction",
                    PageCount = 1225,
                    Language = "English",
                    PublicationYear = 1869,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 7,
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Edition = "1st",
                    Publisher = "Little, Brown and Company",
                    ISBN = "9780316769488",
                    Genre = "Fiction",
                    PageCount = 277,
                    Language = "English",
                    PublicationYear = 1951,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 8,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    Edition = "1st",
                    Publisher = "George Allen & Unwin",
                    ISBN = "9780547928227",
                    Genre = "Fantasy",
                    PageCount = 310,
                    Language = "English",
                    PublicationYear = 1937,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 9,
                    Title = "Crime and Punishment",
                    Author = "Fyodor Dostoevsky",
                    Edition = "1st",
                    Publisher = "The Russian Messenger",
                    ISBN = "9780140449136",
                    Genre = "Psychological Fiction",
                    PageCount = 430,
                    Language = "English",
                    PublicationYear = 1866,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                },
                new Book
                {
                    Id = 10,
                    Title = "The Odyssey",
                    Author = "Homer",
                    Edition = "1st",
                    Publisher = "Penguin Classics",
                    ISBN = "9780140268867",
                    Genre = "Epic Poetry",
                    PageCount = 541,
                    Language = "English",
                    PublicationYear = -700,
                    IsDeleted = false,
                    AddedAt = DateTime.UtcNow
                }
            );
        }


    }

}