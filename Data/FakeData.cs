using Model.Menu;
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
        private Menu menu;
        private BaseUnit gr, ml, pcs;

        public FakeData()
        { 
            recipes = new List<BaseRecipe>();
            menu = new Menu();  

            gr = new Gramm();
            ml = new Milliliter();
            pcs = new Piece();

            var water = new Ingredient("Вода", ml);
            var milk = new Ingredient("Молоко", ml);
            var flover = new Ingredient("Мука", gr);
            var potato = new Ingredient("Картофель", gr);
            var egg = new Ingredient("Яйцо куриное", pcs);
            var onion = new Ingredient("Лук", pcs);
            var chicken = new Ingredient("Филе куриное", gr);
            var tomato = new Ingredient("Помидор", pcs);
            var beans = new Ingredient("Фасоль", gr);

            recipes.Add(new SimpleRecipe(
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
        public Menu GetMenu()
        {
            return menu;
        }
    }
}
