using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReelJett.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryLists_Movies_MovieId",
                table: "HistoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchLists_Movies_MovieId",
                table: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_WatchLists_MovieId",
                table: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_HistoryLists_MovieId",
                table: "HistoryLists");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "WatchLists");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "HistoryLists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "WatchLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "HistoryLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchLists_MovieId",
                table: "WatchLists",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryLists_MovieId",
                table: "HistoryLists",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryLists_Movies_MovieId",
                table: "HistoryLists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchLists_Movies_MovieId",
                table: "WatchLists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
