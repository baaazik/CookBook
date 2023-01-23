﻿using System;
using System.Collections.Generic;
using System.Text;
using Model.Recipe;
using NUnit.Framework;

namespace Tests
{
    abstract class BaseTestRecipe
    {
        protected BaseUnit gr, pcs;
        protected Ingredient ing1, ing2, ing3, ing4;
        protected List<RecipeItem> ingredients;

        public BaseTestRecipe()
        {
            //Создаем объекты ингредиентов, которые будут использоваться в рецепте
            gr = new Gramm();
            pcs = new Piece();
            ing1 = new Ingredient(1, "Картофель", gr);
            ing2 = new Ingredient(2, "Мука", gr);
            ing3 = new Ingredient(3, "Яйцо куриное", pcs);
            ing4 = new Ingredient(4, "Лук", pcs);

            ingredients = new List<RecipeItem>()
            {
                new RecipeItem(ing1, 800),
                new RecipeItem(ing2, 50),
                new RecipeItem(ing3, 1),
                new RecipeItem(ing4, 1)
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
            var amount = new Amount(pcs, 6);
            var recipe = new Recipe() { Id = 1, Name = "Драники", RecipeText = "Какой-то текст", Amount = amount, Ingredients = ingredients };
            
            // Проверяем все свойства
            Assert.AreEqual("Драники", recipe.Name);
            Assert.AreEqual("Какой-то текст", recipe.RecipeText);
            Assert.AreEqual(ingredients, recipe.Ingredients);
            Assert.AreEqual(amount, recipe.Amount);
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
            var amount = new Amount(pcs, 6);
            var recipe = new Recipe() { Id = 1, Name = "Драники", RecipeText = "Какой-то текст", Amount = amount, Ingredients = ingredients };
            var selectedRecipe = new SelectedRecipe(1, recipe);
               
            CollectionAssert.AreEquivalent(ingredients, selectedRecipe.GetIngredients());
        }

        // Тест на функцию GetIngredients
        // Проверяет рассчет кол-ва всех ингредиентов, когда объем готового блюда увеличился
        [Test]
        public void TestGetIngredientsIncrease()
        {
            // Создаем рецепт
            var amount = new Amount(pcs, 6);
            var recipe = new Recipe() { Id = 1, Name = "Драники", RecipeText = "Какой-то текст", Amount = amount, Ingredients = ingredients };
            var selectedRecipe = new SelectedRecipe(1, recipe);

            // Изменим объем блюда
            selectedRecipe.SetAmount(12);

            // Ожидаемый новый объем всех ингредиентов
            var newIngredients = new List<RecipeItem>()
            {
                new RecipeItem(ing1, 1600),
                new RecipeItem(ing2, 100),
                new RecipeItem(ing3, 2),
                new RecipeItem(ing4, 2)
            };

            CollectionAssert.AreEquivalent(newIngredients, selectedRecipe.GetIngredients());
        }

        // Тест на функцию GetIngredients
        // Проверяет рассчет кол-ва всех ингредиентов, когда объем готового блюда уменьшился
        [Test]
        public void TestGetIngredientsDecrease()
        {
            // Создаем рецепт
            var amount = new Amount(pcs, 6);
            var recipe = new Recipe() { Id = 1, Name = "Драники", RecipeText = "Какой-то текст", Amount = amount, Ingredients = ingredients };
            var selectedRecipe = new SelectedRecipe(1, recipe);

            // Изменим объем блюда
            selectedRecipe.SetAmount(3);

            // Ожидаемый новый объем всех ингредиентов
            var newIngredients = new List<RecipeItem>()
            {
                new RecipeItem(ing1, 400),
                new RecipeItem(ing2, 25),
                new RecipeItem(ing3, 1),
                new RecipeItem(ing4, 1)
            };

            CollectionAssert.AreEquivalent(newIngredients, selectedRecipe.GetIngredients());
        }
    }
}
