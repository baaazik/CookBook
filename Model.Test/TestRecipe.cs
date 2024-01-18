using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Model.Model;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    class RecipeIngredientsComparer : IEqualityComparer<RecipeIngredient>
    {
        public bool Equals(RecipeIngredient x, RecipeIngredient y)
        {
            return x.Ingredient == y.Ingredient &&
                   x.Amount == y.Amount;
        }

        public int GetHashCode([DisallowNull] RecipeIngredient obj)
        {
            return obj.GetHashCode();
        }
    }

    abstract class BaseTestRecipe
    {
        protected BaseUnit gr, pcs;
        protected Ingredient ing1, ing2, ing3, ing4;
        protected List<RecipeIngredient> ingredients;

        public BaseTestRecipe()
        {
            //Создаем объекты ингредиентов, которые будут использоваться в рецепте
            gr = new Gramm();
            pcs = new Piece();
            ing1 = new Ingredient() { Id = 1, Name = "Картофель", Unit = gr };
            ing2 = new Ingredient() { Id = 2, Name = "Мука", Unit = gr };
            ing3 = new Ingredient() { Id = 3, Name = "Яйцо куриное", Unit = pcs };
            ing4 = new Ingredient() { Id = 4, Name = "Лук", Unit = pcs };

            ingredients = new List<RecipeIngredient>()
            {
                new RecipeIngredient(){ Ingredient = ing1, Amount = 800 },
                new RecipeIngredient() { Ingredient = ing2, Amount = 50 },
                new RecipeIngredient() { Ingredient = ing3, Amount = 1 },
                new RecipeIngredient() { Ingredient = ing4, Amount = 1 }
            };
        }
    }

    // Тесты класса SimpleRecipe
    class TestRecipe : BaseTestRecipe
    {
        // Тест на конструктор классса
        // Проверяет, что все свойства класса (название, описание итп) выставляются в конструкторе
        // и затем их можно корректно получить с помощью свойств
        [Test]
        public void TestContstructor()
        {
            // Создаем рецепт
            var recipe = new Recipe() {
                Id = 1,
                Name = "Драники",
                RecipeText = "Какой-то текст",
                Amount = 6,
                Unit = pcs,
                Ingredients = ingredients };

            // Проверяем все свойства
            Assert.AreEqual("Драники", recipe.Name);
            Assert.AreEqual("Какой-то текст", recipe.RecipeText);
            Assert.AreEqual(ingredients, recipe.Ingredients);
            Assert.AreEqual(6, recipe.Amount);
            Assert.AreEqual(pcs, recipe.Unit);
        }
    }

    class TestSelectedRecipe : BaseTestRecipe
    {

        // Тест на функцию GetIngredients
        // Проверяет, что когда объем готового блюда не менялся, кол-во ингредиентов осатлось
        // таким же, как было в рецепте
        [Test]
        public void TestGetIngredientsNoChange()
        {
            // Создаем рецепт
            var recipe = new Recipe()
            {
                Id = 1,
                Name = "Драники",
                RecipeText = "Какой-то текст",
                Amount = 6,
                Unit = pcs,
                Ingredients = ingredients
            };

            var selectedRecipe = new SelectedRecipe(recipe);

            Assert.That(selectedRecipe.GetIngredients(),
                new CollectionEquivalentConstraint(ingredients)
                .Using(new RecipeIngredientsComparer()));
        }

        // Тест на функцию GetIngredients
        // Проверяет рассчет кол-ва всех ингредиентов, когда объем готового блюда увеличился
        [Test]
        public void TestGetIngredientsIncrease()
        {
            // Создаем рецепт
            var recipe = new Recipe()
            {
                Id = 1,
                Name = "Драники",
                RecipeText = "Какой-то текст",
                Amount = 6,
                Unit = pcs,
                Ingredients = ingredients
            };

            var selectedRecipe = new SelectedRecipe(recipe);

            // Изменим объем блюда
            selectedRecipe.Amount = 12;

            // Ожидаемый новый объем всех ингредиентов
            var newIngredients = new List<RecipeIngredient>()
            {
                new RecipeIngredient() { Ingredient = ing1, Amount = 1600 },
                new RecipeIngredient() { Ingredient = ing2, Amount = 100 },
                new RecipeIngredient() { Ingredient = ing3, Amount = 2 },
                new RecipeIngredient() { Ingredient = ing4, Amount = 2 }
            };

Assert.That(selectedRecipe.GetIngredients(),
                new CollectionEquivalentConstraint(newIngredients)
                .Using(new RecipeIngredientsComparer()));
        }

        // Тест на функцию GetIngredients
        // Проверяет рассчет кол-ва всех ингредиентов, когда объем готового блюда уменьшился
        [Test]
        public void TestGetIngredientsDecrease()
        {
            // Создаем рецепт
            var recipe = new Recipe()
            {
                Id = 1,
                Name = "Драники",
                RecipeText = "Какой-то текст",
                Amount = 6,
                Unit = pcs,
                Ingredients = ingredients
            };

            var selectedRecipe = new SelectedRecipe(recipe);

            // Изменим объем блюда
            selectedRecipe.Amount = 3;

            // Ожидаемый новый объем всех ингредиентов
            var newIngredients = new List<RecipeIngredient>()
            {
                new RecipeIngredient() { Ingredient = ing1, Amount = 400 },
                new RecipeIngredient() { Ingredient = ing2, Amount = 25 },
                new RecipeIngredient() { Ingredient = ing3, Amount = 1 },
                new RecipeIngredient() { Ingredient = ing4, Amount = 1 }
            };

            Assert.That(selectedRecipe.GetIngredients(),
                new CollectionEquivalentConstraint(newIngredients)
                .Using(new RecipeIngredientsComparer()));
        }
    }
}
