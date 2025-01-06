using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedsampledata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c8558ee9-4580-4c44-91d7-2a67b31c1d95", "john.doe@example.com", "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "AQAAAAIAAYagAAAAEEfbofCD/IvYW7nT3YTpDYXIR5NxcHhEa5G7MbVyltMb7sew6SmA5KUNs2HdXs/0fA==", "a3ce68ee-5a92-4986-851f-930d749d5e6d", "john.doe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8377cbe9-d3d4-41ce-b302-31861705336e", "jane.smith@example.com", "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "AQAAAAIAAYagAAAAEBiAoLuqLeINGNMy7LjIPs4Rmfwl/48dJCkQEIKl61rNzTior4LTK+fV5+rGsk7HJA==", "dc5ca069-1a57-4493-b743-8a5c0552f927", "jane.smith" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b8e62ff-647e-4bc3-a457-05855b2257fd", "AQAAAAIAAYagAAAAEMyLTMe07aTRayVFBLOuOhKl4OYFyqGBR6V9tEchQ2WuuwqfOTUX0s1FxAhc8/EHZQ==", "d840fda0-1786-4e32-8d4f-04fd55131161" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AddedAt", "Author", "Edition", "Genre", "ISBN", "IsDeleted", "Language", "PageCount", "PublicationYear", "Publisher", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6243), "Harper Lee", "1st", "Fiction", "9780061120084", false, "English", 281, 1960, "J.B. Lippincott & Co.", "To Kill a Mockingbird", null },
                    { 2, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6249), "George Orwell", "1st", "Dystopian", "9780451524935", false, "English", 328, 1949, "Secker & Warburg", "1984", null },
                    { 3, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6253), "Jane Austen", "2nd", "Romance", "9780141439518", false, "English", 279, 1813, "T. Egerton", "Pride and Prejudice", null },
                    { 4, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6265), "F. Scott Fitzgerald", "1st", "Fiction", "9780743273565", false, "English", 180, 1925, "Charles Scribner's Sons", "The Great Gatsby", null },
                    { 5, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6269), "Herman Melville", "1st", "Adventure", "9780142437247", false, "English", 635, 1851, "Harper & Brothers", "Moby-Dick", null },
                    { 6, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6274), "Leo Tolstoy", "1st", "Historical Fiction", "9780199232765", false, "English", 1225, 1869, "The Russian Messenger", "War and Peace", null },
                    { 7, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6278), "J.D. Salinger", "1st", "Fiction", "9780316769488", false, "English", 277, 1951, "Little, Brown and Company", "The Catcher in the Rye", null },
                    { 8, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6288), "J.R.R. Tolkien", "1st", "Fantasy", "9780547928227", false, "English", 310, 1937, "George Allen & Unwin", "The Hobbit", null },
                    { 9, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6292), "Fyodor Dostoevsky", "1st", "Psychological Fiction", "9780140449136", false, "English", 430, 1866, "The Russian Messenger", "Crime and Punishment", null },
                    { 10, new DateTime(2025, 1, 6, 6, 28, 33, 235, DateTimeKind.Utc).AddTicks(6296), "Homer", "1st", "Epic Poetry", "9780140268867", false, "English", 541, -700, "Penguin Classics", "The Odyssey", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d6081a51-9448-476b-8791-f1904c744d11", "test1@example.com", "TEST1@EXAMPLE.COM", "TEST1", "AQAAAAIAAYagAAAAEM2OHV9a/DkE5fyAohUF9KnCRTRMf7IRqZVzqDmsiudOnzLHKLKomBonaBE1EA0Ocw==", "124def31-3071-4614-ab37-4282d1131797", "test1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "01a0d8d8-3328-4a28-8d1a-82fde8e22b9a", "test2@example.com", "TEST2@EXAMPLE.COM", "TEST2", "AQAAAAIAAYagAAAAEPGKEoQLKolsRC4J/RzylG90EHhx0O4PoT0l5nOkMM2azrkKvvKZqSDPVr+RdKNpFw==", "119f66a1-9efd-417f-a078-ae3461467b2b", "test2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f30e7cf6-5cbb-42f1-b7ac-2e59c5f79ef5", "AQAAAAIAAYagAAAAEIQRRuhFUTuWB9c5Y6RiGABoJyCr8G6ngg0MRBP8sjZ/M2MPJGJKa3Duro4IF1ulUw==", "06992699-76e0-4b3c-847c-47ec67e316d6" });
        }
    }
}
