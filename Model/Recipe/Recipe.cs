using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Recipe
{
    public abstract class Recipe
    {
        public string Name { get; set; }
        public string RecipeText { get; set; }
        public List<RecipeItem> Ingredients { get; set; }
        public Amount Amount { get; set; }

        public abstract void SetAmount(Amount amount);
        public List<RecipeItem> GetIngredients()
        {
            throw new NotImplementedException();
        }
    }

    public class RecipeItem
    {
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
    }

    public class Amount
    {
        public BaseUnit Unit { get; set; }
        public int Value { get; set; }
    }

}
