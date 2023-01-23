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
            var ingredient = new Ingredient() { Id = 1, Name = "Молоко", Unit = unit };

            Assert.AreEqual("Молоко", ingredient.Name);
            Assert.AreEqual(unit, ingredient.Unit);
        }
    }
}
