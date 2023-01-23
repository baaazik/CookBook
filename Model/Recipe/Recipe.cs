using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Recipe
{
    /// <summary>
    /// Класс рецепта
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название рецепта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Текст рецепта
        /// </summary>
        public string RecipeText { get; set; }

        /// <summary>
        /// Список ингредиентов и их количество
        /// </summary>
        public List<RecipeItem> Ingredients { get; set; } = new List<RecipeItem>();

        /// <summary>
        /// Объем готового блюда
        /// </summary>
        public Amount Amount { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Amount})";
        }
    }

    /// <summary>
    /// Один ингредиент в рецепте
    /// </summary>
    public struct RecipeItem
    {
        public Ingredient Ingredient { get; set; }
        public uint Amount { get; set; }

        public override string ToString()
        {
            return $"{Ingredient.Name} ({Amount} {Ingredient.Unit})";
        }
    }

    /// <summary>
    /// Количество с учетом единицы измерения
    /// </summary>
    public struct Amount
    {
        public Amount(BaseUnit unit, uint value)
        {
            Unit = unit;
            Value = value;
        }

        public BaseUnit Unit { get; set; }
        public uint Value { get; set; }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }

}
