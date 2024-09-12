using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReelJett.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "ProffesionalMovies",
                newName: "TRDublaj");

            migrationBuilder.AddColumn<string>(
                name: "MultipleUrl",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TRAltyazi",
                table: "ProffesionalMovies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MultipleUrl",
                table: "ProffesionalMovies");

            migrationBuilder.DropColumn(
                name: "TRAltyazi",
                table: "ProffesionalMovies");

            migrationBuilder.RenameColumn(
                name: "TRDublaj",
                table: "ProffesionalMovies",
                newName: "VideoUrl");
        }
    }
}
