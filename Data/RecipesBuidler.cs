using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal interface IBuilder<T>
    {
        T Get();
    }

    internal class RecipesBuidler : IBuilder<Recipe>
    {
        private Recipe recipe;

        public RecipesBuidler()
        {
            recipe = new Recipe();
        }

        public RecipesBuidler InitBase(Recipe dto)
        {
            recipe.Id = dto.Id;
            recipe.Name = dto.Name;
            return this;
        }

        public RecipesBuidler InitAmount(Recipe dto)
        {
            recipe.Amount = dto.Amount;
            recipe.Unit = dto.Unit;
            return this;
        }

        public RecipesBuidler InitText(Recipe dto)
        {
            recipe.RecipeText = dto.RecipeText;
            return this;
        }

        public RecipesBuidler InitIngredients(Recipe dto)
        {
            recipe.Ingredients = dto.Ingredients.Select(i => new RecipeIngredient()
                {
                    Ingredient = new Ingredient()
                    {
                        Id = i.Ingredient.Id,
                        Name = i.Ingredient.Name,
                        Unit = i.Ingredient.Unit,
                    },
                    Amount = i.Amount
                }).ToList();

            return this;
        }

        public Recipe Get()
        {
            return recipe;
        }
    }
}
