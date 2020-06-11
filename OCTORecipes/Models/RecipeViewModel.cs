using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCTORecipes.ViewModels
{
    public class RecipeViewModel
    {
        [DisplayName("Recipe Picture")]
       // [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        //[Required(ErrorMessage = "Please choose recipe image")]
        public IFormFile RecipeImage { get; set; }
        [Key]
        [DisplayName("Recipe ID")]
        public int RecipeId { get; set; }
        [DisplayName("Recipe's Author")]
        public string Author { get; set; }
        [DisplayName("Name of Recipe")]
        [StringLength(60, MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of Recipe is Required and no numbers allowed")]
        public string RecipeName { get; set; }
        [Required]
        [DisplayName("Type of Dish (Canadian, Nigerian, etc.)")]
        public string DishType { get; set; }
        [Required]
        [DisplayName("Description of Recipe")]
        [StringLength(1000, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string RecipeDescription { get; set; }
        [Required]
        [DisplayName("List of Ingredients")]
        public string Ingredients { get; set; }
        [Required]
        [DisplayName("Pre Cooking Instructions")]
        [StringLength(2000, MinimumLength = 50)]
        [DataType(DataType.MultilineText)]
        public string PreCookingPreparationMode { get; set; }
        [Required]
        [DisplayName("Cooking Instructions")]
        [StringLength(2000, MinimumLength = 50)]
        [DataType(DataType.MultilineText)]
        public string CookingPreparationMode { get; set; }
        [Required]
        [DisplayName("Post Cooking Instructions/Serving")]
        [StringLength(2000, MinimumLength = 50)]
        [DataType(DataType.MultilineText)]
        public string PostCookingPreparationMode { get; set; }
        [DisplayName("Any Allergy Warning")]
        [DataType(DataType.Text)]
        public string FoodAllergies { get; set; }
        
    }
}
