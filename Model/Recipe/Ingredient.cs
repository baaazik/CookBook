using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Recipe
{
    /// <summary>
    /// Класс ингредиента
    /// </summary>
    public class Ingredient
    {
        public string Name { get; }
        public BaseUnit Unit { get;}

        public Ingredient(string name, BaseUnit unit)
        {
            Name = name;
            Unit = unit;
        }
    }

    /// <summary>
    /// Ингредиент со списком замен
    /// </summary>
    public class ListIngredient : Ingredient
    {
        private List<Ingredient> alternatives;

        public ListIngredient(string name, BaseUnit unit) : base(name, unit)
        {
            // TODO: надо как-то заполнять этот список, когда создаем из БД
            alternatives = new List<Ingredient>();
        }

        /// <summary>
        /// Получить список замен
        /// </summary>
        /// <returns></returns>
        public List<Ingredient> GetAlternatives()
        {
            return alternatives;
        }
    }
}
