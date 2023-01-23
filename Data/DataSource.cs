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

        public DataSource()
        {
            ctx = new Context();
        }

        /// <summary>
        /// Возвращает список всех рецептов
        /// </summary>
        /// <returns>Список рецептов</returns>
        public IReadOnlyList<Model.Recipe.Recipe> GetRecipes()
        {
            var recipes = ctx.Recipes
                .Select(r => new Model.Recipe.Recipe()
                {
                    Id = r.Id,
                    Name= r.Name,
                })
                .ToList();

            return recipes;
        }

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
        /// Возвращает список ингредиентов
        /// </summary>
        /// <returns>Список ингредиентов</returns>
        public IReadOnlyList<Model.Recipe.Ingredient> GetIngredients()
        {

            var ingredients = ctx.Ingredients
                .Select(i => new Model.Recipe.Ingredient()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Unit = UnitConverter.TypeToUnit(i.UnitType)
                })
                .ToList();

            return ingredients;
        }

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

        /// <summary>
        /// Возращает меню - список выбранных рецептов
        /// </summary>
        /// <returns>Список выбранных рецептов</returns>
        public IList<Model.Recipe.SelectedRecipe> GetMenu(string userId)
        {
            var recipes = ctx.SelectedRecipes
                .Where(r => r.UserId == userId)
                .Select(r => new Model.Recipe.SelectedRecipe()
                {
                    Id = r.Id,
                    Recipe = new Model.Recipe.Recipe()
                    {
                        Id = r.Recipe.Id,
                        Name = r.Recipe.Name,
                        Amount = new Model.Recipe.Amount() { Unit = UnitConverter.TypeToUnit(r.Recipe.UnitType), Value = r.Recipe.Amount },
                    },
                    Amount = new Model.Recipe.Amount() { Unit = UnitConverter.TypeToUnit(r.Recipe.UnitType), Value = r.Amount },
                })
                .ToList();
            return recipes;
        }

        public void SelectRecipe(string userId, int recipeId, uint amount)
        {
            var newSelectedRecipe = new SelectedRecipe()
            {
                UserId = userId,
                RecipeId = recipeId,
                Amount = amount
            };

            ctx.SelectedRecipes.Add(newSelectedRecipe);
            ctx.SaveChanges();
        }

        public void DeleteRecipe(string userId, int recipeId)
        {
            var selectedRecipe = ctx.SelectedRecipes
                .First(r => r.UserId == userId && r.RecipeId == recipeId);

            ctx.SelectedRecipes.Attach(selectedRecipe);
            ctx.SelectedRecipes.Remove(selectedRecipe);
            ctx.SaveChanges();
        }
    }
}
