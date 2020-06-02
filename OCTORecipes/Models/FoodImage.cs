using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTORecipes.Models
{
    public class FoodImage
    {
        public int FoodImageId { get; set; }
        public int RecipeId { get; set; }
        public string ImageName { get; set; }
    }
}
