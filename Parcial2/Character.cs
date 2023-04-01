using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class Character
    {
        internal string name;
        internal int hp;
        internal Weapon wpn;
        internal Armor armor;
        internal int baseatk;
        internal int basedef;
        internal enum CharClass{
            Human,
            Beast,
            Hybrid
        }
        CharClass species;


        public Character()
        {
            name = "Test Subject";
            hp = 1;
            baseatk = 1;
            basedef = 0;
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
            baseatk = 0;
            basedef = 0;
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
            baseatk = 0;
            basedef = 0;
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
                baseatk = 0;
            }

            Console.WriteLine("As not defense was introduced, the base defense will be 0.");
            Console.WriteLine("As not species was introduced, the default species (human) will be applied");
            basedef = 0;
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
                baseatk = 0;
            }

            if (DEF >= 0)
                basedef = DEF;
            else
            {
                Console.WriteLine("The character cannot be created with negative base defense");
                basedef = 0;
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
                baseatk = 0;
            }

            if (DEF >= 0)
                basedef = DEF;
            else
            {
                Console.WriteLine("The character cannot be created with negative base defense");
                basedef = 0;
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
                    this.armor.durability -= (damage / 2) + 1;
                    if (armor.durability < 0)
                    {
                        this.unequip(this.armor);
                    }
                        rival.useWeapon();
                }
                else
                {
                    this.armor.durability -= (rival.baseatk / 2) + 1;
                    if (armor.durability < 0)
                    {
                        this.unequip(this.armor);
                    }
                }

            }
            else
            {
                int damage;

                if (rival.wpn != null)
                {
                    damage = rival.baseatk + rival.wpn.pwr;
                    rival.useWeapon();
                }
                else
                {
                    damage = rival.baseatk;
                }
                this.hp -= damage;
                if (this.hp > 0)
                {
                    this.hp = 0;
                    Console.WriteLine("Character died.");
                }

            }
        }
        public void useWeapon()
        {
            this.wpn.durability--;
            if (this.wpn.durability == 0)
                this.unequip(this.wpn);
        }
        public void equip(Armor gear)
        {
            if(gear.durability > 0)
            {
                if(gear.wearableSpecies == Armor.CharClass.Any || gear.wearableSpecies.Equals(this.species))
                {
                    this.armor = gear;
                }
                else
                    Console.WriteLine("This armor cannot be used by the species of the character.");
            }
            else
                Console.WriteLine("This armor is too damaged to be used, better go and sell it like scrap");
        }

        public void equip(Weapon gear)
        {
            {
                if (gear.durability > 0)
                {
                    if (gear.wearableSpecies == Weapon.CharClass.Any || gear.wearableSpecies.Equals(this.species))
                    {
                        this.wpn = gear;
                    }
                    else
                        Console.WriteLine("This weapon cannot be used by the species of the character.");
                }
                else
                    Console.WriteLine("This weapon is too damaged to be used, better go and sell it like scrap");
            }
        }
        public void unequip(Armor gear)
        {
            this.armor = null;
        }
        public void unequip(Weapon gear)
        {
            this.wpn = null;
        }

    }
}
