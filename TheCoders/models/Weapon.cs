using CSC160_ConsoleMenu;
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
        List<Enchantments> enchantmentList = new List<Enchantments>();
        private int attack;
        private int speed;
        private int durability;
        private int maxDurability;
        private int rarity;
        private int maxThreshold;
        private int enchantPoints;
        private bool isBroken = false;
        private int? damageIndex = null;

        public int getAttack() { return attack; }
        public int getSpeed() { return speed; }
        public int getDurability() { return durability; }
        public int getMaxDurability() { return maxDurability; }
        public int getRarity() { return rarity; }
        public int getMaxThreshold() { return maxThreshold; }
        public int getEnchantPoints() { return enchantPoints; }
        public bool getBroken() { return isBroken; }
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

            String bladetypeStr = "";
            Handle.HandleType handletype;
            String handletypeStr = "";
            Pieces.Material handleMaterial;
            String handleMaterialStr = "";
            Pieces.Material bladeMaterial;
            String bladeMaterialStr = "";
            bool confirm;
            do
            {
                int bladetypeint = CIO.PromptForInt("Select a shape for the blade:\n1. Short (Attack-, Speed+)\n2. Long (No Bonuses)\n3. Great (Attack+, Speed-)\n", 1, 3);
                int bladeMaterialInt = CIO.PromptForInt("Select a material for the blade:\n1. Wood (Durability: 10)\n2. Stone (Durability: 20)\n3. Bronze (Durability: 30)\n" +
                    "4. Steel (Durability: 40)\n5. Gold (Durability: 10, Speed+)\n6. Adamantine (Durability: 50)\n7. Mithril (Durability: 40)\n", 1, 7);
                int handleTypeInt = CIO.PromptForInt("Select a length for the handle:\n1. Short (Speed+)\n2. Medium (No Bonuses)\n3. Long (Speed-)\n", 1, 3);
                int handleMaterialInt = CIO.PromptForInt("Select a material for the handle:\n1. Wood (Durability: 10)\n2. Stone (Durability: 20)\n3. Bronze (Durability: 30)\n" +
                    "4. Steel (Durability: 40)\n5. Gold (Durability: 10, Speed+)\n6. Adamantine (Durability: 50)\n7. Mithril (Durability: 40)\n", 1, 7);
                switch (bladetypeint)
                {
                    case 1:
                        bladetypeStr = "short";
                        break;
                    case 2:
                        bladetypeStr = "long";
                        break;
                    case 3:
                        bladetypeStr = "great";
                        break;
                }
                switch (bladeMaterialInt)
                {
                    case 1:
                        bladeMaterialStr = "wooden";
                        break;
                    case 2:
                        bladeMaterialStr = "stone";
                        break;
                    case 3:
                        bladeMaterialStr = "bronze";
                        break;
                    case 4:
                        bladeMaterialStr = "steel";
                        break;
                    case 5:
                        bladeMaterialStr = "gold";
                        break;
                    case 6:
                        bladeMaterialStr = "adamantine";
                        break;
                    case 7:
                        bladeMaterialStr = "mithril";
                        break;
                }
                switch (handleTypeInt)
                {
                    case 1:
                        handletypeStr = "short";
                        break;
                    case 2:
                        handletypeStr = "medium";
                        break;
                    case 3:
                        handletypeStr = "long";
                        break;
                }
                switch (handleMaterialInt)
                {
                    case 1:
                        handleMaterialStr = "wooden";
                        break;
                    case 2:
                        handleMaterialStr = "stone";
                        break;
                    case 3:
                        handleMaterialStr = "bronze";
                        break;
                    case 4:
                        handleMaterialStr = "steel";
                        break;
                    case 5:
                        handleMaterialStr = "gold";
                        break;
                    case 6:
                        handleMaterialStr = "adamantine";
                        break;
                    case 7:
                        handleMaterialStr = "mithril";
                        break;
                }
                confirm = CIO.PromptForBool($"You chose the {bladeMaterialStr} {bladetypeStr}sword blade and the {handleMaterialStr} {handletypeStr} handle. Is this what you want?\n1. Yes\n2. No", "1", "2");
            } while (!confirm);
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
                case "wooden":
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
                case "wooden":
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

        public static Weapon giveWeapon(Blade.BladeType bType, Blade.Material bMaterial, Handle.HandleType hType, Handle.Material hMaterial)
        {
            return new Weapon(new Blade(bType,bMaterial), new Handle(hType,hMaterial));
        }

        //adds the enchantment onto the weapon. If the weapon has elemental damage and you add an enchantment that changes the damage type,
        //it will ask if you want to replace the enchantment with the new one.

        public void addEnchantment()
        {
            
            bool conf = false;
            Enchantments type = new Enchantments(Enchantments.EnchantmentType.none);
            do
            {
                Console.WriteLine("Select an enchantment:");
                int enchantSelect = CIO.PromptForMenuSelection(Enchantments.allEnchants(), true);
                switch (enchantSelect)
                {
                    case 0:
                        return;
                    case 1:
                        type.setEnchantmentType(Enchantments.EnchantmentType.fire);
                        break;
                    case 2:
                        type.setEnchantmentType(Enchantments.EnchantmentType.water);
                        break;
                    case 3:
                        type.setEnchantmentType(Enchantments.EnchantmentType.earth);
                        break;
                    case 4:
                        type.setEnchantmentType(Enchantments.EnchantmentType.lifesteal);
                        break;
                    case 5:
                        type.setEnchantmentType(Enchantments.EnchantmentType.poisonous);
                        break;
                    case 6:
                        type.setEnchantmentType(Enchantments.EnchantmentType.splash);
                        break;
                    case 7:
                        type.setEnchantmentType(Enchantments.EnchantmentType.weaken);
                        break;
                    case 8:
                        type.setEnchantmentType(Enchantments.EnchantmentType.shatter);
                        break;
                    default:
                        return;
                }
                type.setDetails();
                type.listDetails();
                conf = CIO.PromptForBool("Are you sure?\n1. yes\n2. no", "1", "2");

                if (enchantmentList.Contains(type))
                {
                    Console.WriteLine("You already have this enchantment!");
                    conf = false;
                }
                if (damageIndex != null)
                {
                    conf = CIO.PromptForBool("You already have an elemental enchantment. Adding the selected enchantment will remove the previous elemental enchantment. Are you sure you want to do this?\n1. Yes\n2. No", "1", "2");
                }
            } while (!conf);
            enchantmentList.Add(type);
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
                Console.WriteLine($"Weapon Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, Durability: BROKEN, Rarity: {rarity}, Enchantment Points: {enchantPoints}/{maxThreshold}");
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
