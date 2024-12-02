using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeReviewAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeGener : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Animes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Animes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
