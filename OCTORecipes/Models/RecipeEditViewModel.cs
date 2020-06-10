using OCTORecipes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTORecipes.Models
{
    public class RecipeEditViewModel : Recipe
    {
        public string ExistingPhotoPath { get; set; }
    }
}
