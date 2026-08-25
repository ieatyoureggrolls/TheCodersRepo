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
        int level = 1;
        double doubleVal = 0;
        double upgradeMod = 0;
        String upgradeDescription = "No upgrade";
        int exp = 0;
        int lvlThreshold = 100;

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
        public int getLevel()
        {
            return level;
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

        public void addExp(int points)
        {
            exp += points;
            while (exp >= lvlThreshold)
            {
                exp -= lvlThreshold;
                levelUp();
            };
        }

        public void levelUp()
        {
            level++;
            doubleVal += upgradeMod;
            lvlThreshold = lvlThreshold * 2;
        }

        //Sets the description, tier, and cost to the appropriate values depending on the enchantment 
        public void setDetails()
        {
            switch (enchantmentType)
            {
                case EnchantmentType.fire:
                    doubleVal = 1.5;
                    upgradeMod = 0.5;
                    enchantTier = 1;
                    description = "Changes the weapon's damage type to fire. Fire damage deals " + doubleVal + "x damage to earth creatures, but deals 0.5x damage to water creatures.";
                    upgradeDescription = "Increases damage done to earth creatures by 0.5x";
                    enchCost = 100;
                    break;
                case EnchantmentType.water:
                    doubleVal = 1.5;
                    upgradeMod = 0.5;
                    enchantTier = 1;
                    description = "Changes the weapon's damage type to water. Water damage deals " + doubleVal + "x damage to fire creatures, but deals 0.5x damage to earth creatures.";
                    upgradeDescription = "Increases damage done to fire creatures by 0.5x";
                    enchCost = 100;
                    break;
                case EnchantmentType.earth:
                    doubleVal = 1.5;
                    upgradeMod = 0.5;
                    enchantTier = 1;
                    description = "Changes the weapon's damage type to earth. Earth damage deals " + doubleVal + "x damage to water creatures, but deals 0.5x damage to fire creatures.";
                    upgradeDescription = "Increases damage done to water creatures by 0.5x";
                    enchCost = 100;
                    break;
                case EnchantmentType.lifesteal:
                    doubleVal = 0.5;
                    upgradeMod = 0.1;
                    enchantTier = 2;
                    description = "Heals the user for " + doubleVal + " of the damage dealt.";
                    upgradeDescription = "Damage healed increases by 0.1x";
                    enchCost = 200;
                    break;
                case EnchantmentType.poisonous:
                    doubleVal = 5;
                    upgradeMod = 1;
                    enchantTier = 2;
                    description = "Has a 1/10 chance to poison the target. Poison damages the target for" + (int) doubleVal + " hp at the end of each turn for 3 turns.";
                    upgradeDescription = "Poison damage increases by 1";
                    enchCost = 200;
                    break;
                case EnchantmentType.splash:
                    doubleVal = 0.5;
                    upgradeMod = 0.1;
                    enchantTier = 2;
                    description = "Allows the weapon to deal " + doubleVal + "x of its damage to adjacent targets in a single attack.";
                    upgradeDescription = "Splash damage increases by 0.1x";
                    enchCost = 200;
                    break;
                case EnchantmentType.weaken:
                    enchantTier = 3;
                    description = "Has a 1/10 chance to reduce the target's attack power by " + doubleVal + "x for 3 turns.";
                    upgradeDescription = "Cannot be upgraded";
                    enchCost = 300;
                    break;
                case EnchantmentType.shatter:
                    doubleVal = 1.5;
                    upgradeMod = 0.1;
                    enchantTier = 3;
                    description = "Has a 1/10 chance to increase damage dealt by " + doubleVal + "x to the target for 3 turns.";
                    upgradeDescription = "Increases damage dealt by an additional 0.1";
                    enchCost = 300;
                    break;
            }
        }

        public void listDetails()
        {
            Console.WriteLine($"{enchantmentType.ToString().ToUpper()} (Lvl {level})\nDescription: {description}\nEnchanting Cost: {enchCost}\nTier: {enchantTier}\nExp: {exp}\\{lvlThreshold}");

        }
    }
}
