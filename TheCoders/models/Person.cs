using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public class Person
    {
        public int health;
        public int speed;
        public int damage;
        public bool isHero;

        public Person(int health, int speed, int damage, bool isHero)
        {
            this.health = health;
            this.speed = speed;
            this.damage = damage;
            this.isHero = isHero;
        }
    }
}
