using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Recipe
{
    /// <summary>
    /// Выбранный рецепт
    /// </summary>
    public class SelectedRecipe
    {
        public SelectedRecipe(int id, Recipe recipe)
        {
            Id = id;
            Recipe = recipe;
            _amount = recipe.Amount.Value;
        }
        
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на рецепт
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        /// Установить объем готового блюда
        /// </summary>
        /// <param name="amount"></param>
        public void SetAmount(uint amount)
        {
            this._amount = amount;
        }

        /// <summary>
        /// Объем готового выбранного блюда
        /// </summary>
        public Amount Amount
        {
            get => new Amount(Recipe.Amount.Unit, _amount);
        }
        private uint _amount;

        public List<RecipeItem> GetIngredients()
        {
            var ingredients = new List<RecipeItem>();

            // Соотношение между объемом блюда и исходным объемом блюда
            var gain = (double)_amount / (double)Recipe.Amount.Value;

            // Масштабируем количество всех ингредиентов
            foreach (var ingredient in Recipe.Ingredients)
            {
                var scaledValue = ingredient.Ingredient.Unit.ChangeAmount(ingredient.Amount, gain);
                var scaledIngredient = new RecipeItem() { Ingredient = ingredient.Ingredient, Amount = scaledValue };
                ingredients.Add(scaledIngredient);
            }

            return ingredients;
        }
    }
}
