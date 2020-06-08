using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCTORecipes.Data;
using OCTORecipes.Models;
using OCTORecipes.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace OCTORecipes
{
    [Authorize]
    public class RecipesController : Controller
    {
        private readonly OCTORecipesContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
             

        public RecipesController(OCTORecipesContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipe.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeViewModel model)//[Bind("RecipePicture,RecipeId,RecipeName,DishType,RecipeDescription,Ingredients,PreCookingPreparationMode,CookingPreparationMode,PostCookingPreparationMode,FoodAllergies,Symptoms,Antidote,Author")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Recipe recipe = new Recipe
                {
                    RecipePicture = uniqueFileName,
                    RecipeId = model.RecipeId,
                    RecipeName = model.RecipeName,
                    DishType = model.DishType,
                    RecipeDescription = model.RecipeDescription,
                    Ingredients = model.Ingredients,
                    PreCookingPreparationMode = model.PreCookingPreparationMode,
                    CookingPreparationMode = model.CookingPreparationMode,
                    PostCookingPreparationMode = model.PostCookingPreparationMode,
                    FoodAllergies = model.FoodAllergies,
                    Symptoms = model.Symptoms,
                    Antidote = model.Antidote,
                    Author = User.Identity.Name,
                };
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(RecipeViewModel model)
        {
            string uniqueFileName = null;

            if (model.RecipeImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images", "recipe_images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.RecipeImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.RecipeImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }


        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeImage,RecipeId,RecipeName,DishType,RecipeDescription,Ingredients,PreCookingPreparationMode,CookingPreparationMode,PostCookingPreparationMode,FoodAllergies,Symptoms,Antidote,Author")] RecipeViewModel model)
        {

            var recipe = await _context.Recipe.FindAsync(id);
            string Image = recipe.RecipePicture.ToString();
            string uniqueFileName = UploadedFile(model);

            if (id != model.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Extracting the substring used for comparison to determine deletion for existing image
                    int startIndexOldImage = Image.IndexOf("_");
                    int endIndexOldImage = Image.Length - startIndexOldImage;
                    string imageNameOld = Image.Substring(startIndexOldImage,
                        endIndexOldImage);

                    //Extracting the substring used for comparison to determine deletion for new image
                    int startIndexNewImage = uniqueFileName.IndexOf("_");
                    int endIndexNewImage = uniqueFileName.Length - startIndexNewImage;
                    string imageNameNew = uniqueFileName.Substring(startIndexNewImage,
                        endIndexNewImage);

                    // Delete existing image when editing or loading a new image
                    var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", Image);                    
                    if (System.IO.File.Exists(imagePath) && imageNameNew != imageNameOld)
                        System.IO.File.Delete(imagePath);

                   
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(model.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);

            //Deleting image from wwwroot/image
            //refernce: http://www.codaffection.com/asp-net-core-article/asp-net-core-mvc-image-upload-and-retrieve/
            var RecipeImage = recipe.RecipePicture;
            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", RecipeImage);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.RecipeId == id);
        }
    }
}
