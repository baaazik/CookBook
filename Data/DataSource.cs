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
        List<Model.Recipe.BaseRecipe> recipes;
        List<Model.Recipe.Ingredient> ingredients;
        List<BaseRecipe> menu;

        public DataSource()
        {
            ctx = new Context();
            menu = new List<BaseRecipe>();
        }

        public IList<BaseRecipe> GetMenu()
        {
            return menu;
        }

        public IReadOnlyList<BaseRecipe> GetRecipes()
        {
            if (this.recipes != null)
                return this.recipes;

            var dtoRecipes = ctx.Recipes.Include(x => x.Ingredients).ToList();
            var recipes = new List<Model.Recipe.BaseRecipe>();

            foreach(var dtoRecipe in dtoRecipes)
            {
                BaseUnit unit;
                switch (dtoRecipe.UnitType)
                {
                    case UnitType.PIECE:
                        unit = new Piece();
                        break;
                    case UnitType.MILLILITER:
                        unit = new Milliliter();
                        break;
                    case UnitType.GRAMM:
                        unit = new Gramm();
                        break;
                    default: throw new NotImplementedException();
                }

                var amount = new Amount() { Unit = unit, Value = dtoRecipe.Amount };

                var ingredients = new List<Model.Recipe.RecipeItem>();
                foreach (var dtoIngredient in dtoRecipe.Ingredients)
                {
                    var ingredient = GetIngredient(dtoIngredient.IngredientId);
                    var item = new Model.Recipe.RecipeItem() { Amount = dtoIngredient.Amount, Ingredient = ingredient };
                    ingredients.Add(item);
                }

                var recipe = new Model.Recipe.SimpleRecipe(dtoRecipe.Id, dtoRecipe.Name, dtoRecipe.RecipeText, ingredients, amount);
                recipes.Add(recipe);
            }

            this.recipes = recipes;
            return recipes;
        }

        public IReadOnlyList<Model.Recipe.Ingredient> GetIngredients()
        {
            if (this.ingredients != null)
                return this.ingredients;

            var dtoIngredients = ctx.Ingredients.ToList();
            var ingredients = new List<Model.Recipe.Ingredient>();

            foreach(var dtoIngredient in dtoIngredients)
            {
                BaseUnit unit;
                switch (dtoIngredient.UnitType)
                {
                    case UnitType.PIECE:
                        unit = new Piece();
                        break;
                    case UnitType.MILLILITER:
                        unit = new Milliliter();
                        break;
                    case UnitType.GRAMM:
                        unit = new Gramm();
                        break;
                    default: throw new NotImplementedException();
                }

                var ingredient = new Model.Recipe.Ingredient(dtoIngredient.Id, dtoIngredient.Name, unit);
                ingredients.Add(ingredient);
            }

            this.ingredients = ingredients;
            return ingredients;
        }

        public Model.Recipe.Ingredient GetIngredient(int id)
        {
            var ingredients = GetIngredients();
            return ingredients.FirstOrDefault(x => x.Id == id);
        }
    }
}
