using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddLogoPathToJobDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_PostedById",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_PostedById",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PostedById",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "PostedById",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PostedById",
                table: "Jobs",
                column: "PostedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_PostedById",
                table: "Jobs",
                column: "PostedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
