using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public class Enemy : Person
    {
        public Element Element { get; set; }
        public bool IsBoss { get; set; } = false;

        public readonly int gold;

        public Enemy(string name, int maxHealth, int speed, int damage) : base(name, maxHealth, speed, damage, false) { }
        public Enemy(string name, bool isBoss, int maxHealth, int speed, int damage) : base(name, maxHealth, speed, damage, false) { IsBoss = isBoss; }
        public Enemy(string name, int maxHealth, int speed, int damage, Element element, int gold, bool isBoss = false) : base(name, maxHealth, speed, damage, false) 
        {
            Element = element;
            this.gold = gold;
            IsBoss = isBoss;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Element: {Element}";
        }
    }
}
