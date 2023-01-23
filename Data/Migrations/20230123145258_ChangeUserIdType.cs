using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_SelectedRecipes_SelectedRecipeId",
                table: "ShoppingItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingItems_SelectedRecipeId",
                table: "ShoppingItems");

            migrationBuilder.DropColumn(
                name: "SelectedRecipeId",
                table: "ShoppingItems");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SelectedRecipes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_UserId",
                table: "ShoppingItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedRecipes_UserId",
                table: "SelectedRecipes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedRecipes_Users_UserId",
                table: "SelectedRecipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_Users_UserId",
                table: "ShoppingItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedRecipes_Users_UserId",
                table: "SelectedRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingItems_Users_UserId",
                table: "ShoppingItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingItems_UserId",
                table: "ShoppingItems");

            migrationBuilder.DropIndex(
                name: "IX_SelectedRecipes_UserId",
                table: "SelectedRecipes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SelectedRecipes");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedRecipeId",
                table: "ShoppingItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_SelectedRecipeId",
                table: "ShoppingItems",
                column: "SelectedRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingItems_SelectedRecipes_SelectedRecipeId",
                table: "ShoppingItems",
                column: "SelectedRecipeId",
                principalTable: "SelectedRecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
