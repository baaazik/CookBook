using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Recipe;

namespace Data.Models
{
    /// <summary>
    /// Эоемент списка покупок
    /// </summary>
    internal class ShoppingItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id ингредиента
        /// </summary>
        public int IngredientId { get; set; }

        /// <summary>
        /// Ингредиент куплен
        /// </summary>
        [Required]
        bool IsBought { get; set; }

        /// <summary>
        /// Количество ингредиента
        /// </summary>
        [Required]
        uint Amount { get; set; }

        /// <summary>
        /// Ингредиент
        /// </summary>
        [Required]
        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredient Ingredient { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        [Required]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }


    }
}
