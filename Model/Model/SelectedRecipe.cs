using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Model.Model
{
    /// <summary>
    /// Рецепт, выбранный для приготовления
    /// </summary>
    public class SelectedRecipe : IEntity<int>
    {
        public SelectedRecipe() { }
        public SelectedRecipe(Recipe recipe)
        {
            Recipe = recipe;
            RecipeId = recipe.Id;
            Amount = recipe.Amount;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id рецепта
        /// </summary>
        public virtual int RecipeId { get; set; }

        /// <summary>
        /// Рецепт
        /// </summary>
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

        /// <summary>
        /// Измененный объем рецепта
        /// </summary>
        public uint Amount { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public List<RecipeIngredient> GetIngredients()
        {
            var ingredients = new List<RecipeIngredient>();

            // Соотношение между объемом блюда и исходным объемом блюда
            var gain = (double)Amount / (double)Recipe.Amount;

            // Масштабируем количество всех ингредиентов
            foreach (var ingredient in Recipe.Ingredients)
            {
                var scaledValue = ingredient.Ingredient.Unit.ChangeAmount(ingredient.Amount, gain);
                var scaledIngredient = new RecipeIngredient() { Ingredient = ingredient.Ingredient, Amount = scaledValue };
                ingredients.Add(scaledIngredient);
            }

            return ingredients;
        }
    }
}
