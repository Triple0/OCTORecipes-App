using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTORecipes.Models
{
    public class Allergies
    {
        public int AllergiesId { get; set; }
        public int RecipeId { get; set; }
        public string Symptoms { get; set; }
        public string Antidote { get; set; }
    }
}
