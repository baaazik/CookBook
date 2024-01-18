using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    /// <summary>
    /// Класс рецепта
    /// </summary>
    public class Recipe
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
        public BaseUnit Unit { get; set; }

        /// <summary>
        /// Объем готового блюда
        /// </summary>
        public uint Amount { get; set; }

        /// <summary>
        /// Список ингредиентов
        /// </summary>
        public virtual ICollection<RecipeIngredient> Ingredients { get; set;} = new List<RecipeIngredient>();
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public override string ToString()
        {
            return $"{Name} ({Amount} {Unit})";
        }

    }
}
