using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using WebUI.Areas.Identity.Data;
using Model.Recipe;

namespace WebUI.Pages
{
    public class SelectedRecipesModel : PageModel
    {
        private readonly IDataSource _data;
        private readonly UserManager<WebUser> _userManager;

        public IList<SelectedRecipe> Recipes { get; set; }
        
        public SelectedRecipesModel(IDataSource data, UserManager<WebUser> userManager)
        {
            _data = data;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Redirect("~/Identity/Account/Login");
            }

            Recipes = _data.GetMenu(userId);

            return Page();
        }

        public IActionResult OnPost(int recipeId)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Redirect("~/Identity/Account/Login");
            }

            _data.DeleteRecipe(userId, recipeId);
            return Redirect("~/SelectedRecipes");
        }
    }
}
