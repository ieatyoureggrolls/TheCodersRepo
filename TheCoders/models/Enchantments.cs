using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public class Enchantments
    {
        public enum EnchantmentType
        {
            fire,
            water,
            earth,
            lifesteal,
            poisonous,
            splash,
            weaken,
            shatter,
            none
        }

        EnchantmentType enchantmentType = EnchantmentType.none;
        int enchantTier = 0;
        String description = "No Enchantment has been applied yet.";
        int enchCost = 0;

        public Enchantments(EnchantmentType type)
        {
            setEnchantmentType(type);
            setDetails();
        }

        public EnchantmentType getEnchantmentType()
        {
            return enchantmentType;
        }
        public int getEnchCost()
        {
            return enchCost;
        }

        public static IEnumerable<String> allEnchants()
        {
            return ["Fire", "Water", "Earth", "Lifesteal", "Poisonous", "Splash", "Weaken", "Shatter"];
        }
        public void setEnchantmentType(EnchantmentType enchantmentType)
        {
            this.enchantmentType = enchantmentType;
            setDetails();
        }

        //Sets the description, tier, and cost to the appropriate values depending on the enchantment 
        public void setDetails()
        {
            switch (enchantmentType)
            {
                case EnchantmentType.fire:
                    enchantTier = 1;
                    description = "Changes the weapon's damage type to fire. Fire damage deals 1.5x damage to earth creatures, but deals 0.5x damage to water creatures.";
                    enchCost = 100;
                    break;
                case EnchantmentType.water:
                    enchantTier = 1;
                    description = "Changes the weapon's damage type to water. Water damage deals 1.5x damage to fire creatures, but deals 0.5x damage to earth creatures.";
                    enchCost = 100;
                    break;
                case EnchantmentType.earth:
                    enchantTier = 1;
                    description = "Changes the weapon's damage type to earth. Earth damage deals 1.5x damage to water creatures, but deals 0.5x damage to fire creatures.";
                    enchCost = 100;
                    break;
                case EnchantmentType.lifesteal:
                    enchantTier = 2;
                    description = "Heals the user for half of the damage dealt.";
                    enchCost = 200;
                    break;
                case EnchantmentType.poisonous:
                    enchantTier = 2;
                    description = "Has a 1/10 chance to poison the target. Poison damages the target for 5 hp at the end of each turn for 3 turns.";
                    enchCost = 200;
                    break;
                case EnchantmentType.splash:
                    enchantTier = 2;
                    description = "Allows the weapon to deal half of its damage to adjacent targets in a single attack.";
                    enchCost = 200;
                    break;
                case EnchantmentType.weaken:
                    enchantTier = 3;
                    description = "Has a 1/10 chance to reduce the target's attack power by half for 3 turns.";
                    enchCost = 300;
                    break;
                case EnchantmentType.shatter:
                    enchantTier = 3;
                    description = "Has a 1/10 chance to increase damage dealt by 1.5x to the target for 3 turns.";
                    enchCost = 300;
                    break;
            }
        }

        public void listDetails()
        {
            Console.WriteLine($"{enchantmentType.ToString().ToUpper()}\nDescription: {description}\nEnchanting Cost: {enchCost}\nTier: {enchantTier}");

        }
    }
}
