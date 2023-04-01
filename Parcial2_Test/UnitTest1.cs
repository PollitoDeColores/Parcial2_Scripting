using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Parcial2;

namespace Parcial2_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StatsArentNegative()
        {
            //Instantiate
            Character testSubject = new Character("Test", -1, -1, -1);
            //Assert
            int actualHP = testSubject.hp;
            int actualatk = testSubject.baseatk;
            int actualdef = testSubject.basedef;
            Assert.IsTrue(actualHP > 0, "HP confirmed");
            Assert.IsTrue(actualatk > 0, "ATK Confirmed");
            Assert.IsTrue(actualdef > 0, "DEF confirmed");
        }
        [TestMethod]
        public void GearingStatsArent0()
        {
            //Instantiate
            Gearing testArmor = new Gearing("Test", 0, 0, Gearing.CharClass.Beast, Gearing.GearClass.Weapon);
            //Assert
            int actualDurability = testArmor.durability;
            int actualPower = testArmor.pwr;
            Assert.IsTrue(testArmor.durability > 0);
            Assert.IsTrue(testArmor.pwr > 0);
        }
        [TestMethod]
        public void WearingGearBySpecies()
        {
            //Instantiate
            Gearing testArmor = new Gearing("TestG1", 10, 8, Gearing.CharClass.Beast, Gearing.GearClass.Weapon);
            Gearing testArmor2 = new Gearing("TestG1", 10, 8, Gearing.CharClass.Any, Gearing.GearClass.Weapon);
            Character testSubject = new Character("TestC", 15, 21, 6, Character.CharClass.Beast);
            Character testSubject2 = new Character("TestC2", 15, 21, 6, Character.CharClass.Human);
            Character testSubject3 = new Character("TestC", 15, 21, 6, Character.CharClass.Hybrid);
            //Act
            testSubject.equip(testArmor);
            testSubject2.equip(testArmor);
            testSubject3.equip(testArmor2);
            //Assert
            Assert.IsTrue(testSubject.wpn != null);
            Assert.IsTrue(testSubject2.wpn == null);
            Assert.IsTrue(testSubject3.wpn != null);
        }

        [TestMethod]
        public void OverrideGearing()
        {
            //Instantiate
            Gearing testArmor = new Gearing("TestG1", 10, 8, Gearing.GearClass.Armor);
            Gearing testArmor2 = new Gearing("TestG1", 16, 25, Gearing.GearClass.Armor);
            Character testSubject3 = new Character("TestC", 18, 11, 61, Character.CharClass.Hybrid);
            //Act
            testSubject3.equip(testArmor);
            testSubject3.equip(testArmor2);
            //Assert
            Assert.IsTrue(testSubject3.armor == testArmor2);
        }

        [TestMethod]
        public void DamageTestWeaponVNoArmor()
        {
            //Intantiate
            Character testSubject = new Character("TestC", 10, 5, 6, Character.CharClass.Beast);
            Character testSubject2 = new Character("TestC2", 10, 5, 6, Character.CharClass.Human);
            Gearing testweapon = new Gearing("TestG1", 3, 8, Gearing.CharClass.Beast, Gearing.GearClass.Weapon);
            //Act
            testSubject.equip(testweapon);
            testSubject2.recieveDamage(testSubject);
            //Assert
            int expectedHP = 2;
            Assert.AreEqual(expectedHP, testSubject2.hp);
        }

        [TestMethod]
        public void DurabilityDecreasesAndDamage()
        {
            //Intantiate
            Character testSubject = new Character("TestC", 10, 5, 6, Character.CharClass.Beast);
            Character testSubject2 = new Character("TestC2", 10, 5, 6, Character.CharClass.Human);
            Gearing testweapon = new Gearing("TestG1", 3, 8, Gearing.CharClass.Beast, Gearing.GearClass.Weapon);
            Gearing testArmor2 = new Gearing("TestG1", 16, 10, Gearing.GearClass.Armor);
            //Act
            testSubject.equip(testweapon);
            testSubject2.equip(testArmor2);
            testSubject2.recieveDamage(testSubject);
            //Assert
            int expectedDurabilitySword = 7;
            int expectedDurabilityArmor = 6;
            int expectedHP = 10;
            Assert.AreEqual(expectedDurabilitySword, testSubject.wpn.durability);
            Assert.AreEqual(expectedDurabilityArmor, testSubject2.armor.durability);
            Assert.AreEqual(expectedHP, testSubject2.hp);      
        }

        [TestMethod]
        public void BareHandVArmorDamage()
        {
            //Intantiate
            Character testSubject = new Character("TestC", 10, 1, 6, Character.CharClass.Beast);
            Character testSubject2 = new Character("TestC2", 10, 5, 6, Character.CharClass.Human);
            Gearing testArmor2 = new Gearing("TestG1", 16, 10, Gearing.GearClass.Armor);

            //Act
            testSubject2.equip(testArmor2);
            testSubject2.recieveDamage(testSubject);

            //Assert
            int expectedDurability = 9;
            Assert.AreEqual(expectedDurability, testSubject2.armor.durability);
        }

        [TestMethod]
        public void BareVBareDamage()
        {
            //Instantiate
            Character testSubject = new Character("TestC", 10, 5, 6, Character.CharClass.Hybrid);
            Character testSubject2 = new Character("TestC2", 10, 5, 6, Character.CharClass.Human);

            //Act
            testSubject.recieveDamage(testSubject2);

            //Assert
            int expectedHP = 5;
            Assert.AreEqual(expectedHP, testSubject.hp);
        }

        [TestMethod]
        public void UnequipByDurability()
        {
            //Instantiate
            Character testSubject = new Character("TestC", 10, 5, 6, Character.CharClass.Hybrid);
            Character testSubject2 = new Character("TestC2", 10, 5, 6, Character.CharClass.Human);
            Gearing testweapon = new Gearing("TestG1", 3, 1, Gearing.GearClass.Weapon);
            Gearing testArmor2 = new Gearing("TestG1", 16, 1, Gearing.GearClass.Armor);

            //Act
            testSubject.equip(testweapon);
            testSubject2.equip(testArmor2);
            testSubject2.recieveDamage(testSubject);

            //Assert
            Assert.IsTrue(testSubject.wpn == null);
            Assert.IsTrue(testSubject2.armor == null);
        }

        [TestMethod]
        public void DyingIsAbsdolutelySafe()
        {
            //Instantiate
            Character testSubject = new Character("TestC", 10, 8, 6, Character.CharClass.Hybrid);
            Character testSubject2 = new Character("TestC2", 2, 5, 6, Character.CharClass.Human);

            //Act
            testSubject2.recieveDamage(testSubject);

            //Assert
            int expectedHP = 0;
            Assert.AreEqual(expectedHP, testSubject2.hp);
        }

        [TestMethod]
        public void DestroyingGearIsAbsolutelySafe()
        {
            //Instantiate
            Character testSubject = new Character("TestC", 10, 8, 6, Character.CharClass.Hybrid);
            Character testSubject2 = new Character("TestC2", 2, 5, 6, Character.CharClass.Human);
            Gearing testArmor2 = new Gearing("TestG1", 16, 1, Gearing.GearClass.Armor);
            Gearing testweapon = new Gearing("TestG1", 3, 1, Gearing.GearClass.Weapon);

            //Act
            testSubject.equip(testweapon);
            testSubject2.equip(testArmor2);
            testSubject2.recieveDamage(testSubject);

            //Assert
            int expectedHP = 0;
            Assert.AreEqual(expectedHP, testArmor2.durability);
            Assert.AreEqual(expectedHP, testweapon.durability);
        }
    }
}
