using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Parcial2;

namespace Parcial2_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StatsArentNegatuve()
        {
            int expected = 0;
            //Instantiate
            Character testSubject = new Character("Test", -1, -1, -1);
            //Assert
            int actualHP = testSubject.hp
        }
    }
}
