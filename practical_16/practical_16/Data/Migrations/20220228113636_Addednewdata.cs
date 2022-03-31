using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace practical_16.Data.Migrations
{
    public partial class Addednewdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "094afa8c-69e3-4103-a542-8aee12940f9a", "29c2ac64-4c57-4e2f-8b14-01d110fece48", "Admin", "ADMIN" },
                    { "9f074bba-372c-474e-81a2-92e877a73075", "45ae4187-6ae4-4765-a28b-ae088d6cacf3", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "DateOfjoined", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNo", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5b2546a3-3e7a-454e-ac18-52d4cae97b2f", 0, "4606f606-630b-49e1-9f3f-8265fdc3529b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin31@gmail.com", true, "Deval", "Patel", false, null, "ADMIN31@GMAIL.COM", "ADMIN31@GMAIL.COM", "AQAAAAEAACcQAAAAECOau3pfO4jQgPgkJFET/J0oxzHFX+Q8MoMB0zfJhaZfsqJtslEhaWWKwfEOduV3tw==", null, null, false, "6e40d3dd-5377-4f2c-bf6d-288614b6a768", false, "admin31@gmail.com" },
                    { "4b2546a3-3e7a-424e-ac18-52d4cae97b2f", 0, "3c9303da-ba0e-4d52-948d-9d4ae71cd677", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", true, "system", "user", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEC3GKEkrw0B02eY6N6yzFLChU43qldS51Bm3WqplkIQDjp9iSHcU6tBeErRB8a4k1Q==", null, null, false, "1f764354-ee26-4b77-abba-b9f88b9bfd2c", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "094afa8c-69e3-4103-a542-8aee12940f9a", "5b2546a3-3e7a-454e-ac18-52d4cae97b2f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f074bba-372c-474e-81a2-92e877a73075", "4b2546a3-3e7a-424e-ac18-52d4cae97b2f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f074bba-372c-474e-81a2-92e877a73075", "4b2546a3-3e7a-424e-ac18-52d4cae97b2f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "094afa8c-69e3-4103-a542-8aee12940f9a", "5b2546a3-3e7a-454e-ac18-52d4cae97b2f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094afa8c-69e3-4103-a542-8aee12940f9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f074bba-372c-474e-81a2-92e877a73075");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b2546a3-3e7a-424e-ac18-52d4cae97b2f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b2546a3-3e7a-454e-ac18-52d4cae97b2f");
        }
    }
}
