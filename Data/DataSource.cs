using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataSource : IDataSource
    {
        private Context ctx;
        private RecipesRepository recipesRepository;
        private IngredientsRepository ingredientsRepository;
        private MenuRepository menuRepository;

        public DataSource()
        {
            ctx = new Context();
            recipesRepository = new RecipesRepository(ctx);
            ingredientsRepository = new IngredientsRepository(ctx);
            menuRepository = new MenuRepository(ctx);
        }

        /// <summary>
        /// Возвращает список всех рецептов
        /// </summary>
        /// <returns>Список рецептов</returns>
        public IReadOnlyList<Model.Recipe.Recipe> GetRecipes()
        {
            return recipesRepository.GetRecipes();
        }

        /// <summary>
        /// Получить рецепты в категории
        /// </summary>
        public IReadOnlyList<Model.Recipe.Recipe> GetRecipes(int categoryId)
        {
            return recipesRepository.GetRecipes(categoryId);
        }

        /// <summary>
        /// Получить список категорий
        /// </summary>
        public IReadOnlyList<Model.Recipe.Category> GetCategories()
        {
            return recipesRepository.GetCategories();
        }

        /// <summary>
        /// Получить рецепт по Id
        /// </summary>
        public Model.Recipe.Recipe GetRecipe(int id)
		{
            return recipesRepository.GetRecipe(id);
		}

        /// <summary>
        /// Возвращает список ингредиентов
        /// </summary>
        /// <returns>Список ингредиентов</returns>
        public IReadOnlyList<Model.Recipe.Ingredient> GetIngredients()
        {
            return ingredientsRepository.GetIngredients();
        }

        /// <summary>
        /// Возращает меню - список выбранных рецептов
        /// </summary>
        /// <returns>Список выбранных рецептов</returns>
        public IList<Model.Recipe.SelectedRecipe> GetMenu(string userId)
        {
            return menuRepository.GetMenu(userId);
        }

        /// <summary>
        /// Выбирает рецепт
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="recipeId">Id рецепта для выбора</param>
        /// <param name="amount">Измененный объем блюда</param>
        public void SelectRecipe(string userId, int recipeId, uint amount)
        {
            menuRepository.SelectRecipe(userId, recipeId, amount);
        }

        /// <summary>
        /// Удаляет выбранный рецепт
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="recipeId">Id рецепта для удаления</param>
        public void DeleteRecipe(string userId, int recipeId)
        {
            menuRepository.DeleteRecipe(userId, recipeId);
        }
    }
}
