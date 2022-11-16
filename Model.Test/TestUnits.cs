using System;
using System.Collections.Generic;
using System.Text;
using Model.Recipe;
using NUnit.Framework;

namespace Tests
{
    public class TestGramm
    {
        [Test]
        public void TestName()
        {
            var unit = new Gramm();
            Assert.AreEqual("г.", unit.Name);
        }

        [Test]
        public void TestNegativeGain()
        {
            var unit = new Gramm();
            Assert.Throws<ArgumentException>(() => unit.ChangeAmount(10, -1));
        }

        [Test]
        public void TestReduceNoRound()
        {
            var unit = new Gramm();
            Assert.AreEqual(5, unit.ChangeAmount(10, 0.5));
        }

        [Test]
        public void TestReduceRound()
        {
            var unit = new Gramm();
            Assert.AreEqual(2, unit.ChangeAmount(5, 0.5));
        }

        [Test]
        public void TestIncreaseRound()
        {
            var unit = new Gramm();
            Assert.AreEqual(20, unit.ChangeAmount(10, 2));
        }
    }

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
        public void TestIncreaseRound()
        {
            var unit = new Milliliter();
            Assert.AreEqual(20, unit.ChangeAmount(10, 2));
        }
    }

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
        public void TestIncreaseRound()
        {
            var unit = new Piece();
            Assert.AreEqual(20, unit.ChangeAmount(10, 2));
        }
    }
}
