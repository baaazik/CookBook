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
        public static IList<ShoppingItem> GetShoppingList(
            IList<SelectedRecipe> menu)
        {
            var ingredients = GetIngredients(menu);
            var list = ConvertIngredientsToShoppingList(ingredients);
            return list;
        }

        // Определям суммарное количество всех ингредиентов
        private static Dictionary<Ingredient, uint> GetIngredients(
            IList<SelectedRecipe> menu)
        {
            var ingredients = new Dictionary<Ingredient, uint>();
            foreach (var recipe in menu)
            {
                foreach (var ingredient in recipe.GetIngredients())
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

            return ingredients;
        }

        private static List<ShoppingItem> ConvertIngredientsToShoppingList(
            Dictionary<Ingredient, uint> ingredients)
        {
            // Формируем список
            var list = new List<ShoppingItem>();
            foreach (var (key, value) in ingredients)
            {
                list.Add(new ShoppingItem()
                {
                    Ingredient = new RecipeItem() { Ingredient = key, Amount = value },
                    IsBought = false
                });
            }

            return list;
        }
    }
}
