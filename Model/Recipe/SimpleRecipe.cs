using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Recipe
{
    /// <summary>
    /// Рецепт с автоматическим пересчетом количества ингредиентов
    /// </summary>
    public class SimpleRecipe : BaseRecipe
    {
        public SimpleRecipe(int id, string name, string text, List<RecipeItem> ingredients, Amount amount) : base(id, name, text, ingredients, amount)
        {
        }

        public override List<RecipeItem> GetIngredients()
        {
            var ingredients = new List<RecipeItem>();

            // Соотношение между объемом блюда и исходным объемом блюда
            var gain = (double)Amount.Value / (double)DefaultAmount.Value;

            // Масштабируем количество всех ингредиентов
            foreach (var ingredient in Ingredients)
            {
                var scaledValue = ingredient.Ingredient.Unit.ChangeAmount(ingredient.Amount, gain);
                var scaledIngredient = new RecipeItem(ingredient.Ingredient, scaledValue);
                ingredients.Add(scaledIngredient);
            }

            return ingredients;
        }
    }
}
