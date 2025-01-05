using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "101", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "d6081a51-9448-476b-8791-f1904c744d11", "test1@example.com", true, false, null, "TEST1@EXAMPLE.COM", "TEST1", "AQAAAAIAAYagAAAAEM2OHV9a/DkE5fyAohUF9KnCRTRMf7IRqZVzqDmsiudOnzLHKLKomBonaBE1EA0Ocw==", null, false, "124def31-3071-4614-ab37-4282d1131797", false, "test1" },
                    { "2", 0, "01a0d8d8-3328-4a28-8d1a-82fde8e22b9a", "test2@example.com", true, false, null, "TEST2@EXAMPLE.COM", "TEST2", "AQAAAAIAAYagAAAAEPGKEoQLKolsRC4J/RzylG90EHhx0O4PoT0l5nOkMM2azrkKvvKZqSDPVr+RdKNpFw==", null, false, "119f66a1-9efd-417f-a078-ae3461467b2b", false, "test2" },
                    { "3", 0, "f30e7cf6-5cbb-42f1-b7ac-2e59c5f79ef5", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "LIBRARYADMIN", "AQAAAAIAAYagAAAAEIQRRuhFUTuWB9c5Y6RiGABoJyCr8G6ngg0MRBP8sjZ/M2MPJGJKa3Duro4IF1ulUw==", null, false, "06992699-76e0-4b3c-847c-47ec67e316d6", false, "libraryadmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "101", "3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "101", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "101");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
