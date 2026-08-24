
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TheCoders.models;
using TheCoders.views;

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

        private String name = null;
        private int attack;
        private int speed;
        private int durability;
        private int maxDurability;
        private int rarity;
        private int maxThreshold;
        private int enchantPoints;
        private bool isBroken = false;
        private bool halfDurablility = false;
        private int? damageIndex = null;
        private int value = 0;
        private int level = 1;
        private int repairCost = 0;
        private int upgradeCost = 0;

        public String getName() { return name; }
        public int getRepair() {  return repairCost; }
        public int getValue() { return value; }
        public int getLevel() { return level; }
        public int getAttack() { return attack; }
        public int getSpeed() { return speed; }
        public int getDurability() { return durability; }
        public int getMaxDurability() { return maxDurability; }
        public int getRarity() { return rarity; }
        public int getMaxThreshold() { return maxThreshold; }
        public int getEnchantPoints() { return enchantPoints; }
        public bool getBroken() { return isBroken; }
        public bool isHalf() {  return halfDurablility; }
        public int getUpgradeCost() { return upgradeCost; }

       
        public Weapon(Blade blade, Handle handle)
        {
            attack = blade.getAttack() + handle.getAttack();
            speed = blade.getSpeed() + handle.getSpeed();
            durability = blade.getDurability() + handle.getDurability();
            maxDurability = blade.getDurability()+handle.getDurability();
            value = blade.getPrice() + handle.getPrice();
            upgradeCost = (blade.getPrice()+handle.getPrice())/2;

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
        //asks for shape of the blade and length of the handle, as well as materials for both. Then returns a weapon with those parameters. The amount of materials shown is dependant on materialCount
        public static Weapon createWeapon(int materialCount)
        {
            String BMaterialStr = "Select a material for the blade:";
            String HMaterialStr = "Select a material for the handle:";
            Weapon sword;
            Blade blade;
            Handle handle;
            Blade.BladeType bladetype;
            String bladetypeStr = "";
            Handle.HandleType handletype;
            String handletypeStr = "";
            Pieces.Material handleMaterial;
            String handleMaterialStr = "";
            Pieces.Material bladeMaterial;
            String bladeMaterialStr = "";
            bool confirm;
            switch (materialCount)
            {
                case 1:
                    BMaterialStr += "\n1. Wood\n";
                    HMaterialStr += "\n1. Wood\n";
                    break; 
                case 2:
                    BMaterialStr += "\n1. Wood\n2. Stone\n";
                    HMaterialStr += "\n1. Wood\n2. Stone\n";
                    break;
                case 3:
                    BMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n";
                    HMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n";
                    break; 
                case 4:
                    BMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n4. Steel\n";
                    HMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n4. Steel\n";
                    break; 
                case 5:
                    BMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n4. Steel\n5. Gold\n";
                    HMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n4. Steel\n5. Gold\n";
                    break; 
                case 6:
                    BMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n4. Steel\n5. Gold\n6. Adamantine\n";
                    HMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n4. Steel\n5. Gold\n6. Adamantine\n";
                    break; 
                case 7:
                    BMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n4. Steel\n5. Gold\n6. Adamantine\n7. Mithril\n";
                    HMaterialStr += "\n1. Wood\n2. Stone\n3. Bronze\n4. Steel\n5. Gold\n6. Adamantine\n7. Mithril\n";
                    break; 
                default: 
                    break;
            }
            do
            {
                int bladetypeint = CIO.PromptForInt("Select a shape for the blade:\n1. Short\n2. Long\n3. Great\n", 1, 3);
                int bladeMaterialInt = CIO.PromptForInt(BMaterialStr, 1, materialCount);
                int handleTypeInt = CIO.PromptForInt("Select a length for the handle:\n1. Short\n2. Medium\n3. Long\n", 1, 3);
                int handleMaterialInt = CIO.PromptForInt(HMaterialStr, 1, materialCount);
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
                    case "mithril":
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
                    case "mithril":
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
                blade = new Blade(bladetype, bladeMaterial);
                handle = new Handle(handletype, handleMaterial);
                sword = new Weapon(blade, handle);
                Console.WriteLine($"You chose the {bladeMaterialStr} {bladetypeStr}sword blade and the {handleMaterialStr} {handletypeStr} handle. Is this what you want?");
                sword.displayWeaponInfo();
                confirm = CIO.PromptForBool("1.Yes\n2.No", "1", "2");
            } while (!confirm);
            sword.name = CIO.PromptForInput("What will you name this weapon?", false);
            return sword;
        }

        //asks for shape of the blade and length of the handle, as well as materials for both. Then returns a weapon with those parameters.
        public static Weapon createWeapon()
        {
            Weapon sword;
            Blade blade;
            Handle handle;
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
                int bladetypeint = CIO.PromptForInt("Select a shape for the blade:\n1. Short\n2. Long\n3. Great\n", 1, 3);
                int bladeMaterialInt = CIO.PromptForInt("Select a material for the blade:\n1. Wood\n2. Stone\n3. Bronze\n" +
                    "4. Steel\n5. Gold\n6. Adamantine\n7. Mithril\n", 1, 7);
                int handleTypeInt = CIO.PromptForInt("Select a length for the handle:\n1. Short\n2. Medium\n3. Long\n", 1, 3);
                int handleMaterialInt = CIO.PromptForInt("Select a material for the handle:\n1. Wood\n2. Stone\n3. Bronze\n" +
                    "4. Steel\n5. Gold\n6. Adamantine\n7. Mithril\n", 1, 7);
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
                    case "mithril":
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
                    case "mithril":
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
                blade = new Blade(bladetype, bladeMaterial);
                handle = new Handle(handletype, handleMaterial);
                sword = new Weapon(blade, handle);
                Console.WriteLine($"You chose the {bladeMaterialStr} {bladetypeStr}sword blade and the {handleMaterialStr} {handletypeStr} handle. Is this what you want?");
                sword.displayWeaponInfo();
                confirm = CIO.PromptForBool("1.Yes\n2.No", "1", "2");
            } while (!confirm);
            sword.name = CIO.PromptForInput("What will you name this weapon?", false);




            
            return sword;
        }

        //gives out a weapon for free (for tutorials and scripted weapon obtaining)
        public static Weapon giveWeapon(Blade.BladeType bType, Blade.Material bMaterial, Handle.HandleType hType, Handle.Material hMaterial)
        {
            return new Weapon(new Blade(bType,bMaterial), new Handle(hType,hMaterial));
        }

        //adds the enchantment onto the weapon. If the weapon has elemental damage and you add an enchantment that changes the damage type,
        //it will ask if you want to replace the enchantment with the new one.
        public void addEnchantment()
        {
            bool elemental = false;
            bool conf = false;
            bool replace = false;
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
                        elemental = true;
                        break;
                    case 2:
                        type.setEnchantmentType(Enchantments.EnchantmentType.water);
                        elemental = true;
                        break;
                    case 3:
                        type.setEnchantmentType(Enchantments.EnchantmentType.earth);
                        elemental = true;
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
                if (type.getEnchCost() <= getEnchantPoints())
                {
                    type.listDetails();
                    Console.WriteLine($"Enchanting Points left: {enchantPoints}");
                    conf = CIO.PromptForBool("Are you sure?\n1. yes\n2. no", "1", "2");


                    if (enchantmentList.Contains(type))
                    {
                        Console.WriteLine("You already have this enchantment!");
                        conf = false;
                        type.setEnchantmentType(Enchantments.EnchantmentType.none);
                    }
                    if (damageIndex != null && elemental)
                    {
                        conf = CIO.PromptForBool("You already have an elemental enchantment. Adding the selected enchantment will remove the previous elemental enchantment. Are you sure you want to do this?\n1. Yes\n2. No", "1", "2");
                        if (conf)
                        {
                            replace = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You don't have enough enchantment points!");
                }
            } while (!conf);
            if (replace)
            {
                setEnchantment(type, damageIndex!.Value);
            }
            else
            {

                enchantmentList.Add(type);
                enchantPoints -= type.getEnchCost();
                if (type.getEnchantmentType() == Enchantments.EnchantmentType.fire|| type.getEnchantmentType() == Enchantments.EnchantmentType.water|| type.getEnchantmentType() == Enchantments.EnchantmentType.earth)
                {
                    damageIndex = enchantmentList.Count() - 1;
                }
            }
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
        
        //displays the stats of a weapon. If a weapon is below half durability, the durability will have a warning
        public void displayWeaponInfo()
        {
            if (name != null)
            {
                if (isBroken)
                {
                    Console.WriteLine($"{name}'s Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, Durability: BROKEN, Rarity: {rarity}, Enchantment Points: {enchantPoints}/{maxThreshold}, Value: {value}");
                }
                else if (halfDurablility)
                {
                    Console.WriteLine($"{name}'s Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, !Durability: {durability}/{maxDurability}!, Rarity: {rarity}, Enchantment Points: {enchantPoints}/{maxThreshold}, Value: {value}");
                }
                else
                {
                    Console.WriteLine($"{name}'s Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, Durability: {durability}/{maxDurability}, Rarity: {rarity}, Enchantment Points: {enchantPoints}/{maxThreshold}, Value: {value}");
                }
            }
            else
            {
                Console.WriteLine($"Weapon Stats: Damage Type: {damageType}, Attack: {attack}, Speed: {speed}, Durability: {maxDurability}, Rarity: {rarity}, Enchantment Points: {enchantPoints}/{maxThreshold}, Value: {value}");
            }
        }

        //displays the list of enchantments on a weapon
        public void displayEnchantments()
        {
            if (enchantmentList.Count < 1)
            {
                Console.WriteLine($"{name} doesn't have any enchantments");
            }
            else
            {
            Console.WriteLine($"Weapon Enchantments: ");
            foreach (Enchantments e in enchantmentList)
            {
                Console.Write($"[{e.getEnchantmentType().ToString().ToUpper()}] ");
            }
            Console.WriteLine();
            }

        }

        //sets the weapon durability back to max. Sets isBroken to false
        public void repairWeapon()
        {
            durability = maxDurability;
            isBroken = false;
            halfDurablility = false;
        }

        //lowers the weapon durability by one. If the weapon durability is less than or equal to zero, calls breakWeapon()
        public void damageWeapon()
        {
            durability--;
            repairCost = (maxDurability - durability) / 2;
            if (durability < maxDurability/2 && durability>0)
            {
                halfDurablility = true;
            }
            else if (durability <= 0)
            {
                breakWeapon();
            }
        }

        //sets isBroken to true as well as lowers stats.
        public void breakWeapon()
        {
            Console.WriteLine("The weapon broke in half!");
            isBroken = true;
            halfDurablility = false;
            attack = 0;
            value = value / 2;
        }

        //increases the stats of a weapon
        public void upgradeWeapon()
        {
            level++;
            value += 5;
            attack += 5;
            speed += 5;
            upgradeCost += 5;
        }

        //sets the weapon name to newName
        public void renameWeapon(String newName) {
        name = newName;
        }

    }
}
