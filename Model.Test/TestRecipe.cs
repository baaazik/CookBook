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

        [Test]
        public void TestContstructor()
        {
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);
            
            Assert.AreEqual("Драники", recipe.Name);
            Assert.AreEqual("Какой-то текст", recipe.RecipeText);
            Assert.AreEqual(ingredients, recipe.Ingredients);
            Assert.AreEqual(amount, recipe.DefaultAmount);
            Assert.AreEqual(amount, recipe.Amount);
        }

        [Test]
        public void TestSetAmount()
        {
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            // Изменим объем блюда
            recipe.SetAmount(10);
            Assert.AreEqual(amount, recipe.DefaultAmount);
            Assert.AreEqual(new Amount(pcs, 10), recipe.Amount);
        }

        [Test]
        public void TestResetAmount()
        {
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
    
        // Тест получения кол-ва ингредиентов, когда объем готового блюда не менялся
        [Test]
        public void TestGetIngredientsNoChange()
        {
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            CollectionAssert.AreEquivalent(ingredients, recipe.GetIngredients());
        }

        // Тест получения кол-ва ингредиентов, когда объем готового блюда увеличился
        [Test]
        public void TestGetIngredientsIncrease()
        {
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            recipe.SetAmount(12);
            var newIngredients = new List<RecipeItem>()
            {
                new RecipeItem(ing1, 1600),
                new RecipeItem(ing2, 100),
                new RecipeItem(ing3, 2),
                new RecipeItem(ing4, 2)
            };

            CollectionAssert.AreEquivalent(newIngredients, recipe.GetIngredients());
        }

        // Тест получения кол-ва ингредиентов, когда объем готового уменьшился
        [Test]
        public void TestGetIngredientsDecrease()
        {
            var amount = new Amount(pcs, 6);
            var recipe = new SimpleRecipe("Драники", "Какой-то текст", ingredients, amount);

            recipe.SetAmount(3);
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
