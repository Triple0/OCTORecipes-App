using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OCTORecipes.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public string IngredientName { get; set; }

        // source: https://mattferderer.com/entity-framework-no-type-was-specified-for-the-decimal-column
        //used to resolve Microsoft.EntityFrameworkCore.Model.Validation[30000] error
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
