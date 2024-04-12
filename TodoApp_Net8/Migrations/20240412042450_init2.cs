using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp_Net8.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Todoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todoes_UserId",
                table: "Todoes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todoes_Users_UserId",
                table: "Todoes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todoes_Users_UserId",
                table: "Todoes");

            migrationBuilder.DropIndex(
                name: "IX_Todoes_UserId",
                table: "Todoes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todoes");
        }
    }
}
