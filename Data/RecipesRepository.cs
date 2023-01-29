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
                .Select(r => new Model.Recipe.Recipe()
                {
                    Id = r.Id,
                    Name = r.Name,
                })
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
                .Select(r => new Model.Recipe.Recipe()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Amount = new Model.Recipe.Amount() { Unit = UnitConverter.TypeToUnit(r.UnitType), Value = r.Amount },
                })
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
                .Select(r => new Model.Recipe.Recipe()
                {
                    Id = r.Id,
                    Name = r.Name,
                    RecipeText = r.RecipeText,
                    Amount = new Model.Recipe.Amount() { Unit = UnitConverter.TypeToUnit(r.UnitType), Value = r.Amount },
                    Ingredients = r.Ingredients.Select(i => new Model.Recipe.RecipeItem()
                    {
                        Ingredient = new Model.Recipe.Ingredient()
                        {
                            Id = i.Ingredient.Id,
                            Name = i.Ingredient.Name,
                            Unit = UnitConverter.TypeToUnit(i.Ingredient.UnitType)
                        },
                        Amount = i.Amount
                    })
                    .ToList()
                })
                .FirstOrDefault(x => x.Id == id);
            return recipe;
        }
    }
}
