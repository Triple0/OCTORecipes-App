using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCTORecipes.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required and no numbers allowed")]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required and no numbers allowed")]
        [StringLength(20)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }    
    }

}
