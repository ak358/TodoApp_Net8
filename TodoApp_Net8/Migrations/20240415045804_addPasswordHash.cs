using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp_Net8.Migrations
{
    /// <inheritdoc />
    public partial class addPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Limit",
                value: new DateTime(2024, 4, 18, 13, 58, 3, 790, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "Todoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Limit",
                value: new DateTime(2024, 4, 20, 13, 58, 3, 790, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "h+wHM5ZK2BdwH60Ju2sKe3KOHR8+X7fQUvuwDgNaydo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "9gv6Hh1cCMGcXaV0qgVm7kN/6GD0iRhV4Rfj01sI1Ak=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Todoes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Limit",
                value: new DateTime(2024, 4, 18, 0, 24, 21, 612, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "Todoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Limit",
                value: new DateTime(2024, 4, 20, 0, 24, 21, 612, DateTimeKind.Local).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "password");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "password");
        }
    }
}
