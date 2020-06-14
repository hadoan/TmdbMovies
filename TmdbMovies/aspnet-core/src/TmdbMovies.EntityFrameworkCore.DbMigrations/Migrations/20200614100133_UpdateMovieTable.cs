using Microsoft.EntityFrameworkCore.Migrations;

namespace TmdbMovies.Migrations
{
    public partial class UpdateMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoYoutubeTrailer",
                table: "AppMovies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeTrailerId",
                table: "AppMovies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoYoutubeTrailer",
                table: "AppMovies");

            migrationBuilder.DropColumn(
                name: "YoutubeTrailerId",
                table: "AppMovies");
        }
    }
}
