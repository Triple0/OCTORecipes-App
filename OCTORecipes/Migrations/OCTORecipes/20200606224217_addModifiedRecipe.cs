using Microsoft.EntityFrameworkCore.Migrations;

namespace OCTORecipes.Migrations.OCTORecipes
{
    public partial class addModifiedRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropColumn(
                name: "CookingInstructions",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "FoodCategory",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "RecipeName",
                table: "Recipe",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipeDescription",
                table: "Recipe",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DishType",
                table: "Recipe",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Antidote",
                table: "Recipe",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CookingPreparationMode",
                table: "Recipe",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Recipe",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCookingPreparationMode",
                table: "Recipe",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreCookingPreparationMode",
                table: "Recipe",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipePicture",
                table: "Recipe",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "Recipe",
                maxLength: 60,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Antidote",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "CookingPreparationMode",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "PostCookingPreparationMode",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "PreCookingPreparationMode",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipePicture",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "RecipeName",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "RecipeDescription",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DishType",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CookingInstructions",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodCategory",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");
        }
    }
}
