using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public class Person
    {
        public string Name { get; private set; }
        public int CurrentHealth
        {
            get;
            set
            {
                if (value >= MaxHealth)
                    field = MaxHealth;
                else if (value <= 0)
                    field = 0;
                else
                    field = value;
            }
        }
        public int MaxHealth { get; private set; }
        public int Speed { get; private set; }
        public float critChance { get; private set; } = .025f;
        public int Damage { 
            get
            {
                if (!IsHero)
                    return field;
                if (heldWeapon == null || heldWeapon.getBroken())
                    return 1;
                else
                    return heldWeapon.getAttack();
            }
            set; }
        public float critMult { get; private set; } = 1.5f;
        public bool IsHero { get; private set; }

        public Weapon heldWeapon { get; private set; }


        public Person(string name, int maxHealth, int speed, int damage, bool isHero)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Speed = speed;
            Damage = damage;
            IsHero = isHero;
        }

        /// <summary>
        /// Makes the person take damage
        /// </summary>
        /// <param name="damage">The amount of base damage</param>
        /// <returns>How much damage was actually dealt</returns>
        public int TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            return damage;
        }

        /// <summary>
        /// Gets the damage the person will do based off of their weapon
        /// </summary>
        /// <returns>an int[] where - index0: The amount of damage to be delt | index1: used to determine if attack was a crit, 1 crit, -1 not crit</returns>
       
        public int[] DealDamage()
        {
            int damage = Damage;

            bool isCrit = new Random().NextDouble() <= critChance;

            damage = (int)Math.Round(damage * (isCrit ? critMult : 1));

            if (heldWeapon != null)
                heldWeapon.damageWeapon();

            return new int[]{damage, (isCrit ? 1 : -1)};
        }


        /// <summary>
        /// Makes the person start using a new weapon
        /// </summary>
        /// <param name="weapon">A new weapon to be used</param>
        public void EquipWeapon(Weapon weapon)
        {
            heldWeapon = weapon;
        }

        public string PersonWithWeaponToString()
        {
            
            return $"{Name}\n\t{heldWeapon.ToString()}";
        }

        public override string ToString()
        {
            int durability;
            int maxDurability;
            if (heldWeapon == null || heldWeapon.getBroken())
            {
                durability = 0;
                maxDurability = 0;
            }
            else
            {
                durability = heldWeapon.getDurability();
                maxDurability = heldWeapon.getMaxDurability();
            }
            return $"{Name} - Health: {CurrentHealth} | Speed: {Speed}\nWeapon Damage: {Damage}";
        }
    }
}
