using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingTracker.Migrations
{
    /// <inheritdoc />
    public partial class Hours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "CodingGoals");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "CodingGoals",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "CodingGoals");

            migrationBuilder.AddColumn<string>(
                name: "Progress",
                table: "CodingGoals",
                type: "TEXT",
                nullable: true);
        }
    }
}
