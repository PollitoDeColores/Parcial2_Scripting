using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class Character
    {
        public readonly string  name;
        public int hp;
        public Gearing wpn = null;
        public Gearing armor = null;
        public readonly int baseatk;
        public readonly int basedef;
        public enum CharClass{
            Human,
            Beast,
            Hybrid
        }
        public readonly CharClass species;


        public Character()
        {
            name = "Test Subject";
            hp = 1;
            baseatk = 1;
            basedef = 1;
            species = CharClass.Human;
            wpn = null;
            armor = null;

        }
        public Character(string Name)
        {
            name = Name;
            Console.WriteLine("As not base HP was introduced, the base hp will be 1.");
            Console.WriteLine("As not attack was introduced, the base attack will be 0.");
            Console.WriteLine("As not defense was introduced, the base defense will be 0.");
            Console.WriteLine("As not species was introduced, the default species (human) will be applied");
            hp = 1;
            baseatk = 1;
            basedef = 1;
            species = CharClass.Human;
            wpn = null;
            armor = null;
        }
        public Character(string Name, int HP)
        {
            name = Name;

            if (HP > 0)
                hp = HP;
            else
            {
                Console.WriteLine("The character cannot be created with less than 1 HP");
                hp = 1;
            }
            Console.WriteLine("As not attack was introduced, the base attack will be 0.");
            Console.WriteLine("As not defense was introduced, the base defense will be 0.");
            Console.WriteLine("As not species was introduced, the default species (human) will be applied");
            baseatk = 1;
            basedef = 1;
            species = CharClass.Human;
            wpn = null;
            armor = null;
        }
        public Character(string Name, int HP, int ATK)
        {
            name = Name;

            if (HP > 0)
                hp = HP;
            else
            {
                Console.WriteLine("The character cannot be created with less than 1 HP");
                hp = 1;
            }

            if (ATK >= 0)
                baseatk = ATK;
            else
            {
                Console.WriteLine("The character cannot be created with negative base attack");
                baseatk = 1;
            }

            Console.WriteLine("As not defense was introduced, the base defense will be 0.");
            Console.WriteLine("As not species was introduced, the default species (human) will be applied");
            basedef = 1;
            species = CharClass.Human;
            wpn = null;
            armor = null;
        }
        public Character(string Name, int HP, int ATK, int DEF)
        {
            name = Name;

            if (HP > 0)
                hp = HP;
            else
            {
                Console.WriteLine("The character cannot be created with less than 1 HP");
                hp = 1;
            }

            if (ATK >= 0)
                baseatk = ATK;
            else
            {
                Console.WriteLine("The character cannot be created with negative base attack");
                baseatk = 1;
            }

            if (DEF >= 0)
                basedef = DEF;
            else
            {
                Console.WriteLine("The character cannot be created with negative base defense");
                basedef = 1;
            }

            Console.WriteLine("As not species was introduced, the default species (human) will be applied");
            species = CharClass.Human;
            wpn = null;
            armor = null;
        }
        public Character(string Name, int HP, int ATK, int DEF, CharClass Species)
        {
            name = Name;

            if (HP > 0)
                hp = HP;
            else
            {
                Console.WriteLine("The character cannot be created with less than 1 HP");
                hp = 1;
            }

            if (ATK >= 0)
                baseatk = ATK;
            else
            {
                Console.WriteLine("The character cannot be created with negative base attack");
                baseatk = 1;
            }

            if (DEF >= 0)
                basedef = DEF;
            else
            {
                Console.WriteLine("The character cannot be created with negative base defense");
                basedef = 1;
            }

            species = Species;
            wpn = null;
            armor = null;
        }


        public void recieveDamage(Character rival)
        {
            if(this.armor != null)
            {
                if (rival.wpn != null)
                {
                    int damage = rival.wpn.pwr + rival.baseatk;
                    this.armor.durability -= (damage / 2);
                    if (armor.durability < 0)
                    {
                        this.armor.durability = 0;
                        this.unequip(this.armor);
                    }
                        rival.useWeapon();
                }
                else
                {
                    this.armor.durability -= (rival.baseatk / 2);
                    if (rival.baseatk / 2 == 0)
                        this.armor.durability--;
                    if (armor.durability < 0)
                    {
                        this.unequip(this.armor);
                    }
                }

            }
            else
            {
                int damage = rival.baseatk;

                if (rival.wpn != null)
                {
                    damage += rival.wpn.pwr;
                    rival.useWeapon();
                }
                this.hp = this.hp - damage;
                if (this.hp < 0)
                {
                    this.hp = 0;
                    Console.WriteLine("Character died.");
                }

            }
        }
        public void useWeapon()
        {
            this.wpn.durability--;
            if (this.wpn.durability < 1)
                this.unequip(this.wpn);
        }
        public void equip(Gearing gear)
        {
            if(gear.durability > 0)
            {
                if(gear.wearableSpecies == Gearing.CharClass.Any || (int)gear.wearableSpecies == (int)this.species)
                {
                    if (gear.gearType == Gearing.GearClass.Armor)
                        //if (this.armor !=null)
                        //{
                            this.armor = gear;
                        //}
                        /*else
                        {
                            unequip(this.armor);
                            this.armor = gear;
                        }*/
                    else
                    {
                        //if (this.wpn != null)
                        //{
                            this.wpn = gear;
                        //}
                        //else
                        //{
                            //unequip(this.wpn);
                            //this.wpn = gear;
                        //}
                    }
                }
                else
                    Console.WriteLine("This gear cannot be used by the species of the character.");
            }
            else
                Console.WriteLine("This gear is too damaged to be used, better go and sell it like scrap");
        }

        public void unequip(Gearing gear)
        {
            if (gear.gearType == Gearing.GearClass.Armor)
            {
                this.armor = null;
                //destroy used armor
            }
            else
            {
                this.wpn = null;
                //destroy used weapon
            }
        }

    }
}
