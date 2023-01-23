using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Связь рецептов и ингредиентов
    /// </summary>
    [PrimaryKey(nameof(RecipeId), nameof(IngredientId))]
    internal class RecipeIngredient
    {
        public int RecipeId { get; set; }
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredient Ingredient { get; set; }

        public uint Amount { get; set; }
    }
}
