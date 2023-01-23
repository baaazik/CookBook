using Model.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Интерфейс источника данных
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Получить список рецептов
        /// </summary>
        /// <returns>Список рецептов</returns>
        IReadOnlyList<Recipe> GetRecipes();

        /// <summary>
        /// Получить список рецептов в категории
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IReadOnlyList<Recipe> GetRecipes(int categoryId);

        /// <summary>
        /// Получить список рецептов
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Category> GetCategories();

        /// <summary>
        /// Получить рецепт по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Recipe GetRecipe(int id);

        /// <summary>
        /// Получить список ингредиентов
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Ingredient> GetIngredients();

        /// <summary>
        /// Получить список выбранных рецептов
        /// </summary>
        /// <returns></returns>
        IList<SelectedRecipe> GetMenu();
    }
}
