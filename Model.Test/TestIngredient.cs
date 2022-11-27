using System;
using System.Collections.Generic;
using System.Text;
using Model.Recipe;
using NUnit.Framework;

namespace Tests
{
    // Тесты класса Ingredient
    class TestIngredient
    {
        [Test]
        public void TestConstructor()
        {
            var unit = new Milliliter();
            var ingredient = new Ingredient("Молоко", unit);

            Assert.AreEqual("Молоко", ingredient.Name);
            Assert.AreEqual(unit, ingredient.Unit);
        }
    }

    // Тесты класса ListIngredient
    class TestListIngredient
    {
        Milliliter ml;
        Ingredient ing1;
        Ingredient ing2;

        public TestListIngredient()
        {
            ml = new Milliliter();
            ing1 = new Ingredient("Соевое молоко", ml);
            ing2 = new Ingredient("Кокосовое молоко", ml);
        }


        [Test]
        public void TestName()
        {
            var alternatives = new List<Ingredient>() { ing1, ing2 };
            var ingredient = new ListIngredient("Молоко", ml, alternatives);

            Assert.AreEqual("Молоко", ingredient.Name);
        }

        [Test]
        public void TestUnit()
        {
            var alternatives = new List<Ingredient>() { ing1, ing2 };
            var ingredient = new ListIngredient("Молоко", ml, alternatives);

            Assert.AreEqual(ml, ingredient.Unit);
        }

        [Test]
        public void TestGetAlternatives()
        {
            var alternatives = new List<Ingredient>() { ing1, ing2 };
            var ingredient = new ListIngredient("Молоко", ml, alternatives);

            CollectionAssert.AreEquivalent(alternatives, ingredient.GetAlternatives());
        }

        [Test]
        public void TestGetAlternativesNull()
        {
            var ingredient = new ListIngredient("Молоко", ml, null);

            var emptyList = new List<Ingredient>();
            CollectionAssert.AreEquivalent(emptyList, ingredient.GetAlternatives());
        }
    }
}
