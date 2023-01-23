using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Recipe;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataSource _data;
        public IReadOnlyList<Recipe> Recipes { get; set; }

        public IndexModel(IDataSource data)
        {
            _data = data;
        }

        public void OnGet(int? categoryId = null)
        {
            if (categoryId == null)
                Recipes = _data.GetRecipes();
            else
                Recipes = _data.GetRecipes((int)categoryId);
        }
    }
}