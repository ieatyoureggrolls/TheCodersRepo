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
        private int rarity;

        public Weapon(Blade blade, Handle handle)
        {
            attack = blade.getAttack() + handle.getAttack();
            speed = blade.getSpeed() + handle.getSpeed();
            durability = blade.getDurability() + handle.getDurability();
            if(blade.getRarity() > handle.getRarity())
            {
                rarity = blade.getRarity();
            }
            else
            {
                rarity = handle.getRarity();
            }
        }

        public void DisplayWeaponInfo()
        {
            Console.WriteLine($"Weapon Stats: Attack: {attack}, Speed: {speed}, Durability: {durability}, Rarity: {rarity}");
        }
    }
}
