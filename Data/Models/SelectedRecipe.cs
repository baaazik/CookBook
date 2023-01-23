using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Рецепт, выбранный для приготовления
    /// </summary>
    internal class SelectedRecipe
    {
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
    }
}
