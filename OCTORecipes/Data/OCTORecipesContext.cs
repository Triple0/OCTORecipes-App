using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OCTORecipes.Models;

namespace OCTORecipes.Data
{
    public class OCTORecipesContext : DbContext
    {
        public OCTORecipesContext (DbContextOptions<OCTORecipesContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipe { get; set; }
    }
}
