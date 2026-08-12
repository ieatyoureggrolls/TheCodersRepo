using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public class Enemy : Person
    {
        public Element Element { get; set; }
        public bool IsBoss { get; set; } = false;

        public Enemy(string name, int maxHealth, int speed, int damage) : base(name, maxHealth, speed, damage, false) { }

        public Enemy(string name, int maxHealth, int speed, int damage, Element element) : base(name, maxHealth, speed, damage, false) 
        {
            Element = element;
        }
    }
}
