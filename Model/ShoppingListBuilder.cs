using Model.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ShoppingListBuilder
    {
        public static IList<RecipeItem> GetShoppingList(IList<BaseRecipe> menu)
        {
            var ingredients = new Dictionary<Ingredient, uint>();

            // Определям суммарное количество всех ингредиентов
            foreach(var recipe in menu)
            {
                foreach(var ingredient in recipe.GetIngredients())
                {
                    if (ingredients.ContainsKey(ingredient.Ingredient))
                    {
                        ingredients[ingredient.Ingredient] += ingredient.Amount;
                    }
                    else
                    {
                        ingredients[ingredient.Ingredient] = ingredient.Amount;
                    }
                }
            }

            // Формируем список
            var list = new List<RecipeItem>();

            foreach(var (key, value) in ingredients)
            {
                list.Add(new RecipeItem(key, value));
            }

            return list;
        }
    }
}
