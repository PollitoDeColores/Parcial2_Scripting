﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class Gearing
    {
        public readonly string name;
        public readonly int pwr;
        public int durability;
        public enum CharClass
        {
            Human,
            Beast,
            Hybrid,
            Any
        }
        public readonly CharClass wearableSpecies;
        public enum GearClass
        {
            Weapon,
            Armor             
        }
        public readonly GearClass gearType;


        public Gearing(GearClass type)
        {
            gearType = type;
            name = "Test Gear";
            pwr = 1;
            durability = 1;
            wearableSpecies = CharClass.Any;
        }
        public Gearing(string Name, GearClass type)
        {
            gearType = type;
            name = Name;
            Console.WriteLine("As no power was specified, the power will be 1");
            Console.WriteLine("As no durability was specified, the durability will be 1");
            Console.WriteLine("As no wearable species were specified, any species could use this gear");
            pwr = 1;
            durability = 1;
            wearableSpecies = CharClass.Any;
        }
        public Gearing(string Name, int Power, GearClass type)
        {
            gearType = type;
            name = Name;
            if (Power > 0)
                pwr = Power;
            else
            {
                Console.WriteLine("The gearing cannot be created with less than 1 power, the power will be 1");
                pwr = 1;
            }

            Console.WriteLine("As no durability were specified, the durability will be 1");
            Console.WriteLine("As no wearable species were specified, any species could use this gear");
            durability = 1;
            wearableSpecies = CharClass.Any;
        }
        public Gearing(string Name, int Power, int Durability, GearClass type)
        {
            gearType = type;
            name = Name;
            if (Power > 0)
                pwr = Power;
            else
            {
                Console.WriteLine("The gearing cannot be created with less than 1 power, the power will be 1");
                pwr = 1;
            }
            if (Durability > 0)
                durability = Durability;
            else
            {
                Console.WriteLine("The gearing cannot be created with less than 1 durability, the durability will be 1");
                durability = 1;
            }

            Console.WriteLine("As no wearable species were specified, any species could use this gear");
            wearableSpecies = CharClass.Any;
        }
        public Gearing(string Name, int Power, int Durability, CharClass Species, GearClass type)
        {
            gearType = type;
            name = Name;
            if (Power > 0)
                pwr = Power;
            else
            {
                Console.WriteLine("The gearing cannot be created with less than 1 power, the power will be 1");
                pwr = 1;
            }
            if (Durability > 0)
                durability = Durability;
            else
            {
                Console.WriteLine("The gearing cannot be created with less than 1 durability, the durability will be 1");
                durability = 1;
            }

            wearableSpecies = Species;
        }
    }
}
