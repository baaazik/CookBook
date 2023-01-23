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
        List<Model.Recipe.Recipe> recipes;
        List<Model.Recipe.Ingredient> ingredients;
        List<Model.Recipe.SelectedRecipe> menu;

        public DataSource()
        {
            ctx = new Context();
            menu = new List<Model.Recipe.SelectedRecipe>();
        }

        /// <summary>
        /// Возращает меню - список выбранных рецептов
        /// </summary>
        /// <returns>Список выбранных рецептов</returns>
        public IList<Model.Recipe.SelectedRecipe> GetMenu()
        {
            return menu;
        }

        /// <summary>
        /// Возвращает список всех рецептов
        /// </summary>
        /// <returns>Список рецептов</returns>
        public IReadOnlyList<Model.Recipe.Recipe> GetRecipes()
        {
            if (this.recipes != null)
                return this.recipes;

            var dtoRecipes = ctx.Recipes.Include(x => x.Ingredients).ToList();
            var recipes = new List<Model.Recipe.Recipe>();

            foreach(var dtoRecipe in dtoRecipes)
            {
                var recipe = CreateRecipe(dtoRecipe);
                recipes.Add(recipe);
            }

            this.recipes = recipes;
            return recipes;
        }

        // Создает рецепт
        private Model.Recipe.Recipe CreateRecipe(Data.Models.Recipe dtoRecipe)
        {
            var unit = CreateUnit(dtoRecipe.UnitType);
            var amount = new Amount() { Unit = unit, Value = dtoRecipe.Amount };

            var ingredients = new List<Model.Recipe.RecipeItem>();
            foreach (var dtoIngredient in dtoRecipe.Ingredients)
            {
                var ingredient = GetIngredient(dtoIngredient.IngredientId);
                var item = new Model.Recipe.RecipeItem() { Amount = dtoIngredient.Amount, Ingredient = ingredient };
                ingredients.Add(item);
            }

            var recipe = new Model.Recipe.Recipe() {
                Id = dtoRecipe.Id, 
                Name = dtoRecipe.Name,
                RecipeText = dtoRecipe.RecipeText,
                Ingredients = ingredients,
                Amount = amount 
            };

            return recipe;
        }

        /// <summary>
        /// Возвращает список ингредиентов
        /// </summary>
        /// <returns>Список ингредиентов</returns>
        public IReadOnlyList<Model.Recipe.Ingredient> GetIngredients()
        {
            if (this.ingredients != null)
                return this.ingredients;

            var dtoIngredients = ctx.Ingredients.ToList();
            var ingredients = new List<Model.Recipe.Ingredient>();

            foreach(var dtoIngredient in dtoIngredients)
            {
                var ingredient = CreateIngredient(dtoIngredient);
                ingredients.Add(ingredient);
            }

            this.ingredients = ingredients;
            return ingredients;
        }

        // Создает ингредиент
        private static Model.Recipe.Ingredient CreateIngredient(Models.Ingredient dtoIngredient)
        {
            var unit = CreateUnit(dtoIngredient.UnitType);
            var ingredient = new Model.Recipe.Ingredient(dtoIngredient.Id, dtoIngredient.Name, unit);
            return ingredient;
        }

        // Создает класс единицы измерения из типа
        private static BaseUnit CreateUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.PIECE:
                    return new Piece();
                case UnitType.MILLILITER:
                    return new Milliliter();
                case UnitType.GRAMM:
                    return new Gramm();
                default: throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Поиск ингредиента по ID
        /// </summary>
        /// <param name="id">ID ингредиента</param>
        /// <returns>Ингредиент или null</returns>
        public Model.Recipe.Ingredient GetIngredient(int id)
        {
            var ingredients = GetIngredients();
            return ingredients.FirstOrDefault(x => x.Id == id);
        }
    }
}
