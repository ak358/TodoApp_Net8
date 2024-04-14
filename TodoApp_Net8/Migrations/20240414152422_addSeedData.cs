using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoApp_Net8.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "administrator" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, "password", 1, "admin" },
                    { 2, "password", 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Todoes",
                columns: new[] { "Id", "Detail", "Done", "Limit", "Summary", "UserId" },
                values: new object[,]
                {
                    { 1, "This is the detail of Sample Todo 1", false, new DateTime(2024, 4, 18, 0, 24, 21, 612, DateTimeKind.Local).AddTicks(1928), "Sample Todo 1", 1 },
                    { 2, "This is the detail of Sample Todo 2", false, new DateTime(2024, 4, 20, 0, 24, 21, 612, DateTimeKind.Local).AddTicks(1943), "Sample Todo 2", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
