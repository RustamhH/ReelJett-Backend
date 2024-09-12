using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReelJett.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "PersonalMovies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Poster",
                table: "PersonalMovies",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
