using System;
using System.Collections.Generic;
using System.Text;
using TheCoders.models;

namespace TheCoders
{
    public class Weapon
    {
        //TODO: Create pieces for each piece of a weapon, add properties for weapon pieces and stats,
        //add methods to calculate stats based on weapon pieces, add methods to display weapon information
        private int attack;
        private int speed;
        private int durability;

        public Weapon(Pieces blade, Pieces handle)
        {
            attack = blade.getAttack() + handle.getAttack();
            speed = blade.getspeed() + handle.getspeed();
            durability = blade.getDurability() + handle.getDurability();
        }

        public void DisplayWeaponInfo()
        {
            Console.WriteLine($"Weapon Stats: Attack: {attack}, Speed: {speed}, Durability: {durability}");
        }
    }
}
