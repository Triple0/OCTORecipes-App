using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTORecipes.Models
{
    public class CookingInstruction
    {
        public int CookingInstructionId { get; set; }
        public int RecipeId { get; set; }
        public string PreCookingPreparationMode { get; set; }
        public string CookingPreparationMode { get; set; }
        public string PostCookingPreparationMode { get; set; }
    }
}
