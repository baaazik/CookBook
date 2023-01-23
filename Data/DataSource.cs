using Data.Models;
using Microsoft.EntityFrameworkCore;
using Model.Recipe;
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
        /// Возращает меню - список выбранных рецептов
        /// </summary>
        /// <returns>Список выбранных рецептов</returns>
        public IList<Model.Recipe.SelectedRecipe> GetMenu()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает список всех рецептов
        /// </summary>
        /// <returns>Список рецептов</returns>
        public IReadOnlyList<Model.Recipe.Recipe> GetRecipes()
        {
            var recipes = ctx.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .Select(r => new Model.Recipe.Recipe()
                {
                    Id = r.Id,
                    Name = r.Name,
                    RecipeText = r.RecipeText,
                    Amount = new Amount() { Unit = UnitConverter.TypeToUnit(r.UnitType), Value = r.Amount},
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
                .ToList();

            return recipes;
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
    }
}
