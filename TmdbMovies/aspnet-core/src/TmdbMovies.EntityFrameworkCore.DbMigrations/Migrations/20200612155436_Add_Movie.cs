using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TmdbMovies.Migrations
{
    public partial class Add_Movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMovies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Popularity = table.Column<double>(nullable: false),
                    VoteCount = table.Column<long>(nullable: false),
                    Video = table.Column<bool>(nullable: false),
                    PosterPath = table.Column<string>(nullable: true),
                    MovieId = table.Column<long>(nullable: false),
                    Adult = table.Column<bool>(nullable: false),
                    BackdropPath = table.Column<string>(nullable: true),
                    OriginalLanguage = table.Column<string>(nullable: true),
                    OriginalTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    VoteAverage = table.Column<double>(nullable: false),
                    Overview = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMovies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMovies");
        }
    }
}
