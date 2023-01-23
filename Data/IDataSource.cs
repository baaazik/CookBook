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
