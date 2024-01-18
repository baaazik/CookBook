using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    /// <summary>
    /// Связь рецептов и ингредиентов
    /// </summary>
    [PrimaryKey(nameof(RecipeId), nameof(IngredientId))]
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredient Ingredient { get; set; }

        public uint Amount { get; set; }

        public override string ToString()
        {
            return $"{Ingredient.Name} ({Amount} {Ingredient.Unit})";
        }
    }
}
