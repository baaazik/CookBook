using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    /// <summary>
    /// Эоемент списка покупок
    /// </summary>
    public class ShoppingItem : IEntity<int>
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
        public bool IsBought { get; set; }

        /// <summary>
        /// Количество ингредиента
        /// </summary>
        [Required]
        public uint Amount { get; set; }

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
