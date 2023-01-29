using Data.Models;
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

    internal class RecipesBuidler : IBuilder<Model.Recipe.Recipe>
    {
        private Model.Recipe.Recipe recipe;

        public RecipesBuidler()
        {
            recipe = new Model.Recipe.Recipe();
        }

        public RecipesBuidler InitBase(Recipe dto)
        {
            recipe.Id = dto.Id;
            recipe.Name = dto.Name;
            return this;
        }

        public RecipesBuidler InitAmount(Recipe dto)
        {
            recipe.Amount = new Model.Recipe.Amount() { Unit = UnitConverter.TypeToUnit(dto.UnitType), Value = dto.Amount };
            return this;
        }

        public RecipesBuidler InitText(Recipe dto)
        {
            recipe.RecipeText = dto.RecipeText;
            return this;
        }

        public RecipesBuidler InitIngredients(Recipe dto)
        {
            recipe.Ingredients = dto.Ingredients.Select(i => new Model.Recipe.RecipeItem()
                {
                    Ingredient = new Model.Recipe.Ingredient()
                    {
                        Id = i.Ingredient.Id,
                        Name = i.Ingredient.Name,
                        Unit = UnitConverter.TypeToUnit(i.Ingredient.UnitType)
                    },
                    Amount = i.Amount
                }).ToList();

            return this;
        }

        public Model.Recipe.Recipe Get()
        {
            return recipe;
        }
    }
}
