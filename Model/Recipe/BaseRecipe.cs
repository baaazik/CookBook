using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Recipe
{
    /// <summary>
    /// Базовый класс рецепта
    /// </summary>
    public abstract class BaseRecipe
    {
        public BaseRecipe(string name, string text, List<RecipeItem> ingredients, Amount amount)
        {
            Name = name;
            RecipeText = text;
            Ingredients = ingredients;
            DefaultAmount = amount;
            ResetAmount();
        }

        /// <summary>
        /// Название рецепта
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Текст рецепта
        /// </summary>
        public string RecipeText { get; }

        /// <summary>
        /// Список ингредиентов и их количество
        /// </summary>
        public List<RecipeItem> Ingredients { get; }

        /// <summary>
        /// Объем готового блюда по-умолчанию (согласно исходному рецепту)
        /// </summary>
        public Amount DefaultAmount { get; }

        /// <summary>
        /// Объем готового блюда
        /// </summary>
        public Amount Amount
        {
            get { return _amount; }
        }
        private Amount _amount;

        /// <summary>
        /// Изменить количество готового блюда и пересчитать требуемое количество ингредиентов
        /// </summary>
        /// <param name="amount">Новое количество готового блюда в тех же единицах измерения</param>
        public void SetAmount(uint amount)
        {
            _amount.Value = amount;
        }

        /// <summary>
        /// Возвращает количество блюда к значению по умолчанию
        /// </summary>
        public void ResetAmount()
        {
            _amount = DefaultAmount;
        }

        public override string ToString()
        {
            return $"{Name} ({Amount})";
        }

        /// <summary>
        /// Возвращает список игредиентов блюда с учетом количества готового блюда
        /// </summary>
        /// <returns></returns>
        public abstract List<RecipeItem> GetIngredients();
    }

    /// <summary>
    /// Один ингредиент в рецепте
    /// </summary>
    public struct RecipeItem
    {
        public RecipeItem(Ingredient ingredient, uint amount)
        {
            Ingredient = ingredient;
            Amount = amount;
        }

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
