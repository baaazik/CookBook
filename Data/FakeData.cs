using Model.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Фейковая реализация интерфейса хранилища для тестирования и отладки
    /// </summary>
    public class FakeData : IDataSource
    {
        private List<BaseRecipe> recipes;
        private List<BaseRecipe> menu;
        private BaseUnit gr, ml, pcs;

        public FakeData()
        { 
            recipes = new List<BaseRecipe>();
            menu = new List<BaseRecipe>();  

            gr = new Gramm();
            ml = new Milliliter();
            pcs = new Piece();

            var water = new Ingredient(1, "Вода", ml);
            var milk = new Ingredient(2, "Молоко", ml);
            var flover = new Ingredient(3, "Мука", gr);
            var potato = new Ingredient(4, "Картофель", gr);
            var egg = new Ingredient(5, "Яйцо куриное", pcs);
            var onion = new Ingredient(6, "Лук", pcs);
            var chicken = new Ingredient(7, "Филе куриное", gr);
            var tomato = new Ingredient(8, "Помидор", pcs);
            var beans = new Ingredient(9, "Фасоль", gr);

            recipes.Add(new SimpleRecipe(
                1,
                "Драники",
                "Рецепт",
                new List<RecipeItem>
                {
                    new RecipeItem(potato, 800),
                    new RecipeItem(flover, 50),
                    new RecipeItem(egg, 1),
                    new RecipeItem(onion, 1),
                },
                new Amount(pcs, 6)
            ));

            recipes.Add(new SimpleRecipe(
                2,
                "Корм",
                "Рецепт",
                new List<RecipeItem>
                {
                    new RecipeItem(chicken, 800),
                    new RecipeItem(tomato, 4),
                    new RecipeItem(onion, 1),
                    new RecipeItem(beans, 300),
                },
                new Amount(pcs, 8)
            ));
        }

        public IReadOnlyList<BaseRecipe> GetRecipes()
        {
            return recipes;
        }
        public IList<BaseRecipe> GetMenu()
        {
            return menu;
        }
    }
}
