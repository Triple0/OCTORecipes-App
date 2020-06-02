using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTORecipes.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string FoodCategory { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public string DishType { get; set; }
        public string CookingInstructions { get; set; }
        public string RecipeDescription { get; set; }
        public string FoodAllergies { get; set; }
        public string ImageId { get; set; }

    }
}
