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
        public int Id { get; set; }
        public string Name { get; set;  }
        public BaseUnit Unit { get; set; }
    }
}
