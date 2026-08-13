using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TheCoders.models;

namespace TheCoders
{
    public class Weapon
    {
        enum DamageType
        {
            normal,
            fire,
            water,
            earth,
        }

        private DamageType damageType;
        Enchantments[] enchantmentList;
        private int attack;
        private int speed;
        private int durability;
        private int maxDurability;
        private int rarity;
        private int maxThreshold;
        private int enchantPoints;
        private bool isBroken = false;

        public Weapon(Blade blade, Handle handle)
        {
            attack = blade.getAttack() + handle.getAttack();
            speed = blade.getSpeed() + handle.getSpeed();
            durability = blade.getDurability() + handle.getDurability();
            maxDurability = blade.getDurability()+handle.getDurability();

            if (blade.getThreshold() > handle.getThreshold())
            {
                maxThreshold = blade.getThreshold();
            }
            else
            {
                maxThreshold = handle.getThreshold();
            }
            enchantPoints = maxThreshold;

            if(blade.getRarity() > handle.getRarity())
            {
                rarity = blade.getRarity();
            }
            else
            {
                rarity = handle.getRarity();
            }
        }

        public void addEnchantment(Enchantments enchantment)
        {
            if(enchantPoints>0) {
                enchantmentList.Append(enchantment);
                enchantPoints -= enchantment.getEnchCost();
                if (enchantPoints == 0)
                {
                    Console.WriteLine("You have no more enchantment points left!");
                }
            }
            else
            {
                Console.WriteLine("You don't have enough enchantment points on this weapon!");
            }
            
        }

        public void setEnchantment(Enchantments enchantment, int index)
        {
            enchantmentList[index] = enchantment;
            if (index == 0)
            {
                switch (enchantment.getEnchantmentType())
                {
                    case Enchantments.EnchantmentType.fire:
                        damageType = DamageType.fire;
                        break;
                    case Enchantments.EnchantmentType.water:
                        damageType = DamageType.water;
                        break;
                    case Enchantments.EnchantmentType.earth:
                        damageType = DamageType.earth;
                        break;
                    default:
                        damageType = DamageType.normal;
                        break;
                }
            }
        }
        
        public void displayWeaponInfo()
        {
            if (isBroken)
            {
                Console.WriteLine($"Weapon Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, Durability: broken, Rarity: {rarity}");
            }
            else
            {
                Console.WriteLine($"Weapon Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, Durability: {durability}/{maxDurability}, Rarity: {rarity}");
            }
            
        }

        public void damageWeapon()
        {
            durability--;
            if (durability <= 0)
            {
                Console.WriteLine("The weapon broke in half!");
                isBroken = true;
            }
        }
        public void enchantWeapon(Enchantments enchant)
        {
            if (enchantPoints <= 0)
            {
                Console.WriteLine("You're out of enchantment points!");
            }
            else
            {
                enchantment = enchant;

            }
            
        }
    }
}
