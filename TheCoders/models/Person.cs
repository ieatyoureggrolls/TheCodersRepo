using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public class Person
    {
        public int currentHealth;
        public int maxHealth;
        public int speed;
        public int damage;
        public bool isHero;
        

        public Person(int maxHealth, int speed, int damage, bool isHero)
        {
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
            this.speed = speed;
            this.damage = damage;
            this.isHero = isHero;
        }
    }
}
