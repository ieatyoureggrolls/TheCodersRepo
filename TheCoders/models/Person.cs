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
        public int Damage { get; private set; }
        public bool IsHero { get; private set; }


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
        /// <returns>The amount of damage to be delt</returns>
        public int DealDamage()
        {
            return Damage;
        }
    }
}
