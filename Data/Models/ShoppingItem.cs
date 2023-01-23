﻿using System;
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

        public int IngredientId { get; set; }
        [Required]
        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredient Ingredient { get; set; }

        public int SelectedRecipeId { get; set; }
        [Required]
        [ForeignKey(nameof(SelectedRecipeId))]
        public virtual SelectedRecipe SelectedRecipe { get; set; }

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
    }
}