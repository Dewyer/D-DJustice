using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DCore.Entities;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DiceTest()
        {
            var dice = Dice.RollDice("1d20");
            Assert.IsTrue(dice != 0);
        }
    }
}
