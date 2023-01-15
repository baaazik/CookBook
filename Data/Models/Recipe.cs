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
    /// Класс рецепта
    /// </summary>
    internal class Recipe
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Текст инструкции
        /// </summary>
        public string RecipeText { get; set; }

        /// <summary>
        /// Тип единицы измерения для кол-ва готового блюда
        /// </summary>
        public UnitType UnitType { get; set; }

        /// <summary>
        /// Объем готового блюда
        /// </summary>
        public uint Amount { get; set; }

        /// <summary>
        /// Список ингредиентов
        /// </summary>
        public virtual ICollection<RecipeIngredient> Ingredients { get; set;} = new List<RecipeIngredient>();

    }
}
