using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReelJett.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ProffesionalMovies_ProffesionalMovieId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ProffesionalMovieId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ProffesionalMovieId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Actors",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Awards",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "BoxOffice",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "DVD",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Metascore",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Plot",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Poster",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Production",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Rated",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Released",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Runtime",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Writer",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "imdbID",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "imdbRating",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "imdbVotes",
                table: "ProffesionalMovies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProffesionalMovieId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Awards",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BoxOffice",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DVD",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Metascore",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Production",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rated",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Released",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Runtime",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Writer",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imdbID",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imdbRating",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imdbVotes",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProffesionalMovieId",
                table: "Ratings",
                column: "ProffesionalMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ProffesionalMovies_ProffesionalMovieId",
                table: "Ratings",
                column: "ProffesionalMovieId",
                principalTable: "ProffesionalMovies",
                principalColumn: "Id");
        }
    }
}
