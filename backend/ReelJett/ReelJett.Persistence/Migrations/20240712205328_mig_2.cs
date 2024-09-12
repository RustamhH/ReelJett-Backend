using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReelJett.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchLists_Movies_MovieId",
                table: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_WatchLists_UserId",
                table: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_HistoryLists_UserId",
                table: "HistoryLists");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "WatchLists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "MovieItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WatchListId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HistoryListId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieItem_HistoryLists_HistoryListId",
                        column: x => x.HistoryListId,
                        principalTable: "HistoryLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieItem_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieItem_WatchLists_WatchListId",
                        column: x => x.WatchListId,
                        principalTable: "WatchLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WatchLists_UserId",
                table: "WatchLists",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryLists_UserId",
                table: "HistoryLists",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieItem_HistoryListId",
                table: "MovieItem",
                column: "HistoryListId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieItem_MovieId",
                table: "MovieItem",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieItem_WatchListId",
                table: "MovieItem",
                column: "WatchListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchLists_Movies_MovieId",
                table: "WatchLists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchLists_Movies_MovieId",
                table: "WatchLists");

            migrationBuilder.DropTable(
                name: "MovieItem");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_WatchLists_UserId",
                table: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_HistoryLists_UserId",
                table: "HistoryLists");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "WatchLists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchLists_UserId",
                table: "WatchLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryLists_UserId",
                table: "HistoryLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchLists_Movies_MovieId",
                table: "WatchLists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
