using System;
using System.Collections.Generic;
using System.Text;
using Model.Model;
using NUnit.Framework;

namespace Tests
{
    // Тесты классов единиц измерений

    // Тест класса  Gramm
    public class TestGramm
    {
        // Проверка имени единицы измерения
        [Test]
        public void TestName()
        {
            var unit = new Gramm();
            Assert.AreEqual("г.", unit.Name);
        }

        // Тест, что нельзя в ChangeAmount передать отрицательный gain
        [Test]
        public void TestNegativeGain()
        {
            var unit = new Gramm();
            Assert.Throws<ArgumentException>(() => unit.ChangeAmount(10, -1));
        }

        // Тест уменьшения кол-ва без округления
        [Test]
        public void TestReduceNoRound()
        {
            var unit = new Gramm();
            Assert.AreEqual(5, unit.ChangeAmount(10, 0.5));
        }

        // Тест уменьшения кол-ва с округлением
        [Test]
        public void TestReduceRound()
        {
            var unit = new Gramm();
            Assert.AreEqual(2, unit.ChangeAmount(5, 0.5));
        }

        // Тест увеличения кол-ва
        [Test]
        public void TestIncrease()
        {
            var unit = new Gramm();
            Assert.AreEqual(20, unit.ChangeAmount(10, 2));
        }
    }

    // Тесты класса Milliliter
    public class TestMilliliter
    {
        [Test]
        public void TestName()
        {
            var unit = new Milliliter();
            Assert.AreEqual("мл.", unit.Name);
        }

        [Test]
        public void TestNegativeGain()
        {
            var unit = new Milliliter();
            Assert.Throws<ArgumentException>(() => unit.ChangeAmount(10, -1));
        }

        [Test]
        public void TestReduceNoRound()
        {
            var unit = new Milliliter();
            Assert.AreEqual(5, unit.ChangeAmount(10, 0.5));
        }

        [Test]
        public void TestReduceRound()
        {
            var unit = new Milliliter();
            Assert.AreEqual(2, unit.ChangeAmount(5, 0.5));
        }

        [Test]
        public void TestIncrease()
        {
            var unit = new Milliliter();
            Assert.AreEqual(20, unit.ChangeAmount(10, 2));
        }
    }

    // Тесты класса Piece
    public class TestPiece
    {
        [Test]
        public void TestName()
        {
            var unit = new Piece();
            Assert.AreEqual("шт.", unit.Name);
        }

        [Test]
        public void TestNegativeGain()
        {
            var unit = new Piece();
            Assert.Throws<ArgumentException>(() => unit.ChangeAmount(10, -1));
        }

        [Test]
        public void TestReduceNoRound()
        {
            var unit = new Piece();
            Assert.AreEqual(5, unit.ChangeAmount(10, 0.5));
        }

        [Test]
        public void TestReduceRound()
        {
            var unit = new Piece();
            Assert.AreEqual(3, unit.ChangeAmount(5, 0.5));
        }

        [Test]
        public void TestIncrease()
        {
            var unit = new Piece();
            Assert.AreEqual(20, unit.ChangeAmount(10, 2));
        }
    }
}
