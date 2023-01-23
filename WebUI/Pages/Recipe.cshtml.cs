using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Recipe;
using WebUI.Areas.Identity.Data;

namespace WebUI.Pages
{
	public class RecipeModel : PageModel
	{
		private readonly IDataSource _data;
        private readonly UserManager<WebUser> _userManager;
        public Recipe Recipe { get; set; }

		public RecipeModel(IDataSource data, UserManager<WebUser> userManager)
		{
			_data = data;
            _userManager = userManager;
        }


		public void OnGet(int id)
        {
			Recipe = _data.GetRecipe(id);
        }

		public IActionResult OnPost(int recipeId, uint amount)
		{
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Redirect("~/Identity/Account/Login");
            }

            _data.SelectRecipe(userId, recipeId, amount);
            return Redirect("~/SelectedRecipes");
        }
    }
}
