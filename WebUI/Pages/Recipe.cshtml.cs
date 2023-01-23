using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Recipe;

namespace WebUI.Pages
{
	public class RecipeModel : PageModel
	{
		private readonly IDataSource _data;
		public Recipe Recipe { get; set; }

		public RecipeModel(IDataSource data)
		{
			_data = data;
		}


		public void OnGet(int id)
        {
			Recipe = _data.GetRecipe(id);
        }
    }
}
