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
    /// Класс ингредиента
    /// </summary>
    internal class Ingredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название ингредиента
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Тип единицы измерения
        /// </summary>
        public UnitType UnitType { get; set; }
    }
}
