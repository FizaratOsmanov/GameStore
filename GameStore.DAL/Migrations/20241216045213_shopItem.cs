using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class shopItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopItemId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItems_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ShopItemId",
                table: "Reviews",
                column: "ShopItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_GameId",
                table: "ShopItems",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ShopItems_ShopItemId",
                table: "Reviews",
                column: "ShopItemId",
                principalTable: "ShopItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ShopItems_ShopItemId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "ShopItems");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ShopItemId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ShopItemId",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
