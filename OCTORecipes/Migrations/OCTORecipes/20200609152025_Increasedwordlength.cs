using Microsoft.EntityFrameworkCore.Migrations;

namespace OCTORecipes.Migrations.OCTORecipes
{
    public partial class Increasedwordlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Antidote",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "RecipeDescription",
                table: "Recipe",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PreCookingPreparationMode",
                table: "Recipe",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PostCookingPreparationMode",
                table: "Recipe",
                maxLength: 20000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CookingPreparationMode",
                table: "Recipe",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RecipeDescription",
                table: "Recipe",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "PreCookingPreparationMode",
                table: "Recipe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "PostCookingPreparationMode",
                table: "Recipe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20000);

            migrationBuilder.AlterColumn<string>(
                name: "CookingPreparationMode",
                table: "Recipe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

            migrationBuilder.AddColumn<string>(
                name: "Antidote",
                table: "Recipe",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "Recipe",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);
        }
    }
}
