using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    /// <summary>
    /// Позволяет получать рецепты из базы данных
    /// </summary>
    internal class RecipesRepository
    {
        private Context ctx;

        public RecipesRepository(Context ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Получить все рецепты
        /// </summary>
        public IReadOnlyList<Model.Recipe.Recipe> GetRecipes()
        {
            var recipes = ctx.Recipes
                .Select(r => new RecipesBuidler().InitBase(r).Get())
                .ToList();

            return recipes;
        }

        /// <summary>
        /// Получить рецепты в категории
        /// </summary>
        public IReadOnlyList<Model.Recipe.Recipe> GetRecipes(int categoryId)
        {
            var recipes = ctx.Recipes
                .Where(r => r.Categories.Any(c => c.Id == categoryId))
                .Select(r => new RecipesBuidler().InitBase(r).InitAmount(r).Get())
                .ToList();
            return recipes;
        }

        /// <summary>
        /// Получить список категорий
        /// </summary>
        public IReadOnlyList<Model.Recipe.Category> GetCategories()
        {
            return ctx.Categories
                .Select(c => new Model.Recipe.Category()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();
        }

        /// <summary>
        /// Получить рецепт по Id
        /// </summary>
        public Model.Recipe.Recipe GetRecipe(int id)
        {
            var recipe = ctx.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .Where(x => x.Id == id)
                .Select(r => new RecipesBuidler().InitBase(r).InitAmount(r).InitText(r).InitIngredients(r).Get())
                .FirstOrDefault();
            return recipe;
        }
    }
}
