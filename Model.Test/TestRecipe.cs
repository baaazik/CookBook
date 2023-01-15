using System;
using System.Collections.Generic;
using System.Text;
using Model.Recipe;
using NUnit.Framework;

namespace Tests
{
    // Тесты класса SimpleRecipe
    class TestSimpleRecipe
    {
        BaseUnit gr, pcs;
        Ingredient ing1, ing2, ing3, ing4;
        List<RecipeItem> ingredients;

        public TestSimpleRecipe()
        {
            //Создаем объекты ингредиентов, которые будут использоваться в рецепте
            gr = new Gramm();
            pcs = new Piece();
            ing1 = new Ingredient("Картофель", gr);
            ing2 = new Ingredient("Мука", gr);
            ing3 = new Ingredient("Яйцо куриное", pcs);
            ing4 = new Ingredient("Лук", pcs);

            ingredients = new List<RecipeItem>()
            {
                new RecipeItem(ing1, 800),
                new RecipeItem(ing2, 50),
                new RecipeItem(ing3, 1),
                new RecipeItem(ing4, 1)
            };
        }

        // Тест на конструктор классса
        // Проверяет, что все свойства класса (название, описание итп) выставляются в конструкторе
        // и затем их можно корректно получить с помощью свойств
        [Test]
        public void TestContstructor()
        {
            // Создаем рецепт
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);
            
            // Проверяем все свойства
            Assert.AreEqual("Драники", recipe.Name);
            Assert.AreEqual("Какой-то текст", recipe.RecipeText);
            Assert.AreEqual(ingredients, recipe.Ingredients);
            Assert.AreEqual(amount, recipe.DefaultAmount);
            Assert.AreEqual(amount, recipe.Amount);
        }

        // Тест на функцию SetAmount().
        // Проверяет, что если изменить объем готового блюда, то свойство Amount возвращает
        // корректное новое значение.
        [Test]
        public void TestSetAmount()
        {
            // Создаем рецепт
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            // Изменим объем блюда
            recipe.SetAmount(10);
            Assert.AreEqual(amount, recipe.DefaultAmount);
            Assert.AreEqual(new Amount(pcs, 10), recipe.Amount);
        }

        // Тест ан функцию ResetAmount().
        // Проверяет, что если мы изменили объем готового блюда с помощью функции SetAmount, 
        // с помощью функции ResetAmount объем сбрасывается на значение по-умолчанию
        [Test]
        public void TestResetAmount()
        {
            // Создаем рецепт
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            // Изменим объем блюда
            recipe.SetAmount(10);
            Assert.AreEqual(amount, recipe.DefaultAmount);
            Assert.AreEqual(new Amount(pcs, 10), recipe.Amount);

            // Сбросим кол-во блюда на значение по-умолчанию
            recipe.ResetAmount();
            Assert.AreEqual(amount, recipe.DefaultAmount);
            Assert.AreEqual(amount, recipe.Amount);
        }
    
        // Тест на функцию GetIngredients
        // Проверяет, что когда объем готового блюда не менялся, кол-во ингредиентов осатлось
        // таким же, как было в рецепте
        [Test]
        public void TestGetIngredientsNoChange()
        {
            // Создаем рецепт
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            CollectionAssert.AreEquivalent(ingredients, recipe.GetIngredients());
        }

        // Тест на функцию GetIngredients
        // Проверяет рассчет кол-ва всех ингредиентов, когда объем готового блюда увеличился
        [Test]
        public void TestGetIngredientsIncrease()
        {
            // Создаем рецепт
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            // Изменим объем блюда
            recipe.SetAmount(12);

            // Ожидаемый новый объем всех ингредиентов
            var newIngredients = new List<RecipeItem>()
            {
                new RecipeItem(ing1, 1600),
                new RecipeItem(ing2, 100),
                new RecipeItem(ing3, 2),
                new RecipeItem(ing4, 2)
            };

            CollectionAssert.AreEquivalent(newIngredients, recipe.GetIngredients());
        }

        // Тест на функцию GetIngredients
        // Проверяет рассчет кол-ва всех ингредиентов, когда объем готового блюда уменьшился
        [Test]
        public void TestGetIngredientsDecrease()
        {
            // Создаем рецепт
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            // Изменим объем блюда
            recipe.SetAmount(3);

            // Ожидаемый новый объем всех ингредиентов
            var newIngredients = new List<RecipeItem>()
            {
                new RecipeItem(ing1, 400),
                new RecipeItem(ing2, 25),
                new RecipeItem(ing3, 1),
                new RecipeItem(ing4, 1)
            };

            CollectionAssert.AreEquivalent(newIngredients, recipe.GetIngredients());
        }
    }
}
