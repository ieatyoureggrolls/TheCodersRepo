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
        List<Enchantments> enchantmentList;
        private int attack;
        private int speed;
        private int durability;
        private int maxDurability;
        private int rarity;
        private int maxThreshold;
        private int enchantPoints;
        private bool isBroken = false;

        private int? damageIndex = null;

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

        //asks for shape of the blade and length of the handle, as well as materials for both. Then returns a weapon with those parameters.
        public static Weapon createWeapon()
        {
            Blade.BladeType bladetype;
            String bladetypeStr;
            Handle.HandleType handletype;
            String handletypeStr;
            Pieces.Material handleMaterial;
            String handleMaterialStr;
            Pieces.Material bladeMaterial;
            String bladeMaterialStr;

            Console.WriteLine("Select a shape for the blade:\nShort\nLong\nGreat");
            do
            {
                bladetypeStr = Console.ReadLine();

            } while (bladetypeStr.Trim().ToLower()!="short"&& bladetypeStr.Trim().ToLower() != "long"&& bladetypeStr.Trim().ToLower() != "great");
            Console.WriteLine("Select a material for the blade:\nwood\nstone\nbronze\nsteel\ngold\nadamantine\nmithril");
            do
            {
                bladeMaterialStr = Console.ReadLine();

            } while (bladeMaterialStr.Trim().ToLower()!="wood"&& bladeMaterialStr.Trim().ToLower() != "stone"&&bladeMaterialStr.Trim().ToLower()!="bronze"&&
            bladeMaterialStr.Trim().ToLower()!="steel"&&bladeMaterialStr.Trim().ToLower() != "gold"&& bladeMaterialStr.Trim().ToLower() != "adamantine"&& 
            bladeMaterialStr.Trim().ToLower() != "mythril");
            Console.WriteLine("Select a length for the handle:\nShort\nMedium\nLong");
            do
            {
                handletypeStr = Console.ReadLine();

            } while (handletypeStr.Trim().ToLower() != "short" && handletypeStr.Trim().ToLower() != "long" && handletypeStr.Trim().ToLower() != "medium");
            Console.WriteLine("Select a material for the blade:\nwood\nstone\nbronze\nsteel\ngold\nadamantine\nmithril");
            do
            {
                handleMaterialStr = Console.ReadLine();

            } while (handleMaterialStr.Trim().ToLower() != "wood" && handleMaterialStr.Trim().ToLower() != "stone" && handleMaterialStr.Trim().ToLower() != "bronze" &&
            handleMaterialStr.Trim().ToLower() != "steel" && handleMaterialStr.Trim().ToLower() != "gold" && handleMaterialStr.Trim().ToLower() != "adamantine" &&
            handleMaterialStr.Trim().ToLower() != "mythril");

            switch (bladetypeStr.Trim().ToLower())
            {
                case "short":
                    bladetype = Blade.BladeType.Short;
                    break;
                case "long":
                    bladetype = Blade.BladeType.Long;
                    break;
                case "great":
                    bladetype = Blade.BladeType.Great;
                    break;
                default:
                    bladetype = Blade.BladeType.Short;
                    break;
            }
            switch (bladeMaterialStr.Trim().ToLower())
            {
                case "wood":
                    bladeMaterial = Pieces.Material.wood;
                    break;
                case "stone":
                    bladeMaterial = Pieces.Material.stone;
                    break;
                case "bronze":
                    bladeMaterial = Pieces.Material.bronze;
                    break;
                case "steel":
                    bladeMaterial = Pieces.Material.steel;
                    break;
                case "gold":
                    bladeMaterial = Pieces.Material.gold;
                    break;
                case "adamantine":
                    bladeMaterial = Pieces.Material.adamantine;
                    break;
                case "mythril":
                    bladeMaterial = Pieces.Material.mithril;
                    break;
                default:
                    bladeMaterial = Pieces.Material.wood;
                    break;
            }
            switch (handleMaterialStr.Trim().ToLower())
            {
                case "wood":
                    handleMaterial = Pieces.Material.wood;
                    break;
                case "stone":
                    handleMaterial = Pieces.Material.stone;
                    break;
                case "bronze":
                    handleMaterial = Pieces.Material.bronze;
                    break;
                case "steel":
                    handleMaterial = Pieces.Material.steel;
                    break;
                case "gold":
                    handleMaterial = Pieces.Material.gold;
                    break;
                case "adamantine":
                    handleMaterial = Pieces.Material.adamantine;
                    break;
                case "mythril":
                    handleMaterial = Pieces.Material.mithril;
                    break;
                default:
                    handleMaterial = Pieces.Material.wood;
                    break;
            }
            switch (handletypeStr.Trim().ToLower())
            {
                case "short":
                    handletype = Handle.HandleType.Short;
                    break;
                case "long":
                    handletype = Handle.HandleType.Long;
                    break;
                case "medium":
                    handletype = Handle.HandleType.Medium;
                    break;
                default:
                    handletype = Handle.HandleType.Short;
                    break;
            }

            Blade blade = new Blade(bladetype,bladeMaterial);
            Handle handle = new Handle(handletype,handleMaterial);


            
            return new Weapon(blade,handle);
        }

        //adds the enchantment onto the weapon. If the weapon has elemental damage and you add an enchantment that changes the damage type,
        //it will ask if you want to replace the enchantment with the new one.
        public void addEnchantment(Enchantments enchantment)
        {
            String? input = "";
            bool confirm = false;
            if (enchantmentList.Contains(enchantment))
            {
                Console.WriteLine("You already have this enchantment!");
                return;
            }
            if (damageIndex != null && (enchantment.getEnchantmentType().Equals(Enchantments.EnchantmentType.fire) || enchantment.getEnchantmentType().Equals(Enchantments.EnchantmentType.water)
                || enchantment.getEnchantmentType().Equals(Enchantments.EnchantmentType.earth)))
            {
                Console.WriteLine("You already have elemental damage on this weapon. Adding a new damage type onto the weapon will override the current one. Are you sure?");
                do
                {
                    input = Console.ReadLine();
                    if (input.ToLower().Equals("yes") || input.ToLower().Equals("no"))
                    {
                        confirm = true;
                    }

                } while (!confirm);
                if (input.ToLower().Equals("no"))
                {
                    return;
                }
                else
                {
                    if (enchantment.getEnchantmentType().Equals(Enchantments.EnchantmentType.fire) || enchantment.getEnchantmentType().Equals(Enchantments.EnchantmentType.water)
                || enchantment.getEnchantmentType().Equals(Enchantments.EnchantmentType.earth))
                    {
                        setEnchantment(enchantment, damageIndex.Value);
                    }
                    return;
                }
            }
            enchantmentList.Add(enchantment);
            enchantmentList[enchantmentList.Count - 1].setDetails();
            
        }

        //sets the damage type to an enchantment that changes the type
        private void updateDamageType()
        {
            if (damageIndex != null)
            {
                switch (enchantmentList[damageIndex.Value].getEnchantmentType())
                {
                    case Enchantments.EnchantmentType.fire:
                        damageType = Weapon.DamageType.fire;
                        break;
                    case Enchantments.EnchantmentType.water:
                        damageType = Weapon.DamageType.water;
                        break;
                    case Enchantments.EnchantmentType.earth:
                        damageType = Weapon.DamageType.earth;
                        break;
                    default:
                        damageType = Weapon.DamageType.normal;
                        break;
                }
            }
        }

        //replaces the enchantment at a given index with the given enchantment
        public void setEnchantment(Enchantments enchantment, int index)
        {
            enchantPoints += enchantmentList[index].getEnchCost();
            enchantPoints -= enchantment.getEnchCost();
            enchantmentList[index] = enchantment;
            enchantmentList[index].setDetails();
            updateDamageType();
        }
        
        //displays the stats of a weapon
        public void displayWeaponInfo()
        {
            if (isBroken)
            {
                Console.WriteLine($"Weapon Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, Durability: broken, Rarity: {rarity}, Enchantment Points: {enchantPoints}/{maxThreshold}");
            }
            else
            {
                Console.WriteLine($"Weapon Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, Durability: {durability}/{maxDurability}, Rarity: {rarity}, Enchantment Points: {enchantPoints}/{maxThreshold}");
            }
            
        }

        //displays the list of enchantments on a weapon
        public void displayEnchantments()
        {
            Console.WriteLine($"Weapon Enchantments: {enchantmentList.ToList}");
        }

        //sets the weapon durability back to max. Sets isBroken to false
        public void repairWeapon()
        {
            durability = maxDurability;
            isBroken = false;
        }

        //lowers the weapon durability by one. If the weapon durability is less than or equal to zero, sets isBroken to true.
        public void damageWeapon()
        {
            durability--;
            if (durability <= 0)
            {
                Console.WriteLine("The weapon broke in half!");
                isBroken = true;
            }
        }

    }
}
