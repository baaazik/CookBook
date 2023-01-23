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
    /// Пользователь
    /// </summary>
    internal class User
    {
        [Key]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Список выбранных рецептов этого пользователя
        /// </summary>
        public virtual ICollection<SelectedRecipe> Recipes { get; set; } = new List<SelectedRecipe>();

        /// <summary>
        /// Список покупок пользователя
        /// </summary>
        public virtual ICollection<ShoppingItem> ShoppingItems { get; set; } = new HashSet<ShoppingItem>();
    }
}
