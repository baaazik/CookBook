using Model.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Составляет список покупок на основе выбранных рецептов
    /// </summary>
    public class ShoppingListBuilder
    {
        /// <summary>
        /// Получить список покупок
        /// </summary>
        /// <param name="menu">Список выбранных рецептов</param>
        /// <returns>Список покупок</returns>
        public static IList<RecipeItem> GetShoppingList(IList<SelectedRecipe> menu)
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
