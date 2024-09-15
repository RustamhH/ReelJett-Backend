using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReelJett.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class configurationsadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieItem_HistoryLists_HistoryListId",
                table: "MovieItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieItem_WatchLists_WatchListId",
                table: "MovieItem");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieItem_HistoryLists_HistoryListId",
                table: "MovieItem",
                column: "HistoryListId",
                principalTable: "HistoryLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieItem_WatchLists_WatchListId",
                table: "MovieItem",
                column: "WatchListId",
                principalTable: "WatchLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieItem_HistoryLists_HistoryListId",
                table: "MovieItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieItem_WatchLists_WatchListId",
                table: "MovieItem");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieItem_HistoryLists_HistoryListId",
                table: "MovieItem",
                column: "HistoryListId",
                principalTable: "HistoryLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieItem_WatchLists_WatchListId",
                table: "MovieItem",
                column: "WatchListId",
                principalTable: "WatchLists",
                principalColumn: "Id");
        }
    }
}
