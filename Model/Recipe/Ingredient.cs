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

        /// <summary>
        /// Создает новый экземпляр
        /// </summary>
        /// <param name="name">Название ингредиента</param>
        /// <param name="unit">Единица измерения, в которой он измеряется</param>
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

        /// <summary>
        /// Создает новый игредиент
        /// </summary>
        /// <param name="name">Название ингердиента</param>
        /// <param name="unit">Единица измерения, в которой он измеряется</param>
        /// <param name="alternatives">Список игредиентов, которыми его можно заменить</param>
        public ListIngredient(string name, BaseUnit unit, List<Ingredient> alternatives) : base(name, unit)
        {
            // Если в качестве alternatives передан null, то создадим пустой список замен (т.е. замен нет). 
            // Это упростит работу с эти классом, не нужно будет проверять на null
            if (alternatives != null)
            {
                this.alternatives = alternatives;
            }
            else
            {
                this.alternatives = new List<Ingredient>();
            }
        }

        /// <summary>
        /// Получить список замен
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Ingredient> GetAlternatives()
        {
            return alternatives;
        }
    }
}
