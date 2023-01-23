using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Recipe;

namespace WebUI.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly IDataSource _data;
        public IReadOnlyList<Category> Categories { get; set; }

        public CategoriesModel(IDataSource data)
        {
            _data = data;
        }

        public void OnGet()
        {
            Categories = _data.GetCategories();
        }
    }
}
