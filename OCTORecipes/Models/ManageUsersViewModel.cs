using OCTORecipes.Models;
using System.Collections.Generic;

namespace OCTORecipes.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Everyone { get; set; }
    }
}