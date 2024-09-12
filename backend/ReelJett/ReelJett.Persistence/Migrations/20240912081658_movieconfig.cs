using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReelJett.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class movieconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_Movies_MovieId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViews_Movies_MovieId",
                table: "UserViews");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_Movies_MovieId",
                table: "UserLikes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserViews_Movies_MovieId",
                table: "UserViews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_Movies_MovieId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViews_Movies_MovieId",
                table: "UserViews");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_Movies_MovieId",
                table: "UserLikes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViews_Movies_MovieId",
                table: "UserViews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
