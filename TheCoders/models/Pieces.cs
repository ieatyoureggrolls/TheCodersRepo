using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public abstract class Pieces
    {
        public enum PieceType
        {
            blade,
            handle
        }
        public enum Material
        {
            wood,
            stone,
            bronze,
            steel,
            gold,
            adamantine,
            mithril
        }

        PieceType pieceType;
        Material material;
        int attack;
        int speed;
        int durability;
        int enchantTier;
        int rarity;
        int price;
        int enchantThreshold;

        public int getThreshold()
        {
            return enchantThreshold;
        }
        public int getPrice()
        {
            return price;
        }
        public int getRarity()
        {
            return rarity;
        }
        public int getAttack()
        {
            return attack;
        }
        public int getSpeed()
        {
            return speed;
        }
        public int getDurability()
        {
            return durability;
        }
        public Material getMaterial()
        {
            return material;
        }
        public PieceType getPieceType()
        {
            return pieceType;
        }
        public int getEnchantTier()
        {
            return enchantTier;
        }
        public void setThreshold(int threshold)
        {
            enchantThreshold = threshold;
        }
        public void setPrice(int price)
        {
            this.price = price;
        }
        public void setRarity(int rarity)
        {
            this.rarity = rarity;
        }
        public void setAttack(int attack)
        {
            this.attack = attack;
        }
        public void setSpeed(int speed)
        {
            this.speed = speed;
        }
        public void setDurability(int durability)
        {
            this.durability = durability;
        }
        public void setMaterial(Material material)
        {
            this.material = material;
        }
        public void setPieceType(PieceType pieceType)
        {
            this.pieceType = pieceType;
        }
        public void setEnchantTier(int enchantTier)
        {
            this.enchantTier = enchantTier;
        }

        //Adds the stats given by the piece and material to total stats
        public abstract void combineStats();

        //Shows the information of the piece
        public abstract void DisplayPieceInfo();
    }

    public class Blade : Pieces
    {
        public enum BladeType
        {
            Short,
            Long,
            Great
        }
        private BladeType bladeType;

        public void setBladeType(BladeType bladeType)
        {
            this.bladeType = bladeType;
        }
        public BladeType getBladeType()
        {
            return bladeType;
        }
        override public void combineStats()
        {
            switch (getBladeType())
            {
                case BladeType.Short:
                    setAttack(2);
                    setSpeed(3);
                    break;
                case BladeType.Long:
                    setAttack(3);
                    setSpeed(2);
                    break;
                case BladeType.Great:
                    setAttack(5);
                    setSpeed(0);
                    break;
            }
            switch (getMaterial())
            {
                case Material.wood:
                    setRarity(1);
                    setDurability(getDurability() + 10);
                    setEnchantTier(1);
                    setPrice(10);
                    setThreshold(100);
                    break;
                case Material.stone:
                    setRarity(2);
                    setAttack(getAttack() + 1);
                    setDurability(getDurability() + 20);
                    setEnchantTier(1);
                    setPrice(20);
                    setThreshold(200);
                    break;
                case Material.bronze:
                    setRarity(3);
                    setAttack(getAttack() + 2);
                    setDurability(getDurability() + 30);
                    setEnchantTier(2);
                    setPrice(30);
                    setThreshold(300);
                    break;
                case Material.steel:
                    setRarity(4);
                    setAttack(getAttack() + 3);
                    setDurability(getDurability() + 40);
                    setEnchantTier(2);
                    setPrice(40);
                    setThreshold(400);
                    break;
                case Material.gold:
                    setRarity(4);
                    setAttack(getAttack() + 1);
                    setDurability(getDurability() + 10);
                    setSpeed(getSpeed() + 2);
                    setEnchantTier(3);
                    setPrice(40);
                    setThreshold(600);
                    break;
                case Material.adamantine:
                    setRarity(5);
                    setAttack(getAttack() + 5);
                    setDurability(getDurability() + 50);
                    setEnchantTier(3);
                    setPrice(50);
                    setThreshold(600);
                    break;
                case Material.mithril:
                    setRarity(5);
                    setAttack(getAttack() + 2);
                    setDurability(getDurability() + 40);
                    setEnchantTier(4);
                    setPrice(50);
                    setThreshold(800);
                    break;
            }
        }
        override public void DisplayPieceInfo()
        {
            Console.WriteLine($"Blade Stats: Type: {getBladeType()}, Material: {getMaterial()}, Attack: {getAttack()}, Speed: {getSpeed()}, Durability: {getDurability()}, Rarity: {getRarity()}, Enchant Tier: {getEnchantTier()}, Price: {getPrice()}");
        }
        public Blade(BladeType bladeType, Material material)
        {
            setPieceType(PieceType.blade);
            setBladeType(bladeType);
            setMaterial(material);
            combineStats();
        }
    }
    public class Handle : Pieces
    {
        public enum HandleType
        {
            Short,
            Long,
            Medium
        }
        private HandleType handleType;

        public void setHandleType(HandleType handleType)
        {
            this.handleType = handleType;
        }
        public HandleType getHandleType()
        {
            return handleType;
        }
        override public void combineStats()
        {
            switch (getHandleType())
            {
                case HandleType.Short:
                    setSpeed(3);
                    break;
                case HandleType.Medium:
                    setSpeed(2);
                    break;
                case HandleType.Long:
                    setSpeed(1);
                    break;
            }
            switch (getMaterial())
            {
                case Material.wood:
                    setRarity(1);
                    setDurability(getDurability() + 10);
                    setPrice(10);
                    setThreshold(100);
                    break;
                case Material.stone:
                    setRarity(2);
                    setDurability(getDurability() + 20);
                    setPrice(20);
                    setThreshold(200);
                    break;
                case Material.bronze:
                    setRarity(3);
                    setDurability(getDurability() + 30);
                    setPrice(30);
                    setThreshold(300);
                    break;
                case Material.steel:
                    setRarity(4);
                    setDurability(getDurability() + 40);
                    setPrice(40);
                    setThreshold(400);
                    break;
                case Material.gold:
                    setRarity(4);
                    setDurability(getDurability() + 10);
                    setSpeed(getSpeed() + 3);
                    setPrice(40);
                    setThreshold(600);
                    break;
                case Material.adamantine:
                    setRarity(5);
                    setDurability(getDurability() + 50);
                    setPrice(50);
                    setThreshold(600);
                    break;
                case Material.mithril:
                    setRarity(5);
                    setDurability(getDurability() + 40);
                    setPrice(50);
                    setThreshold(800);
                    break;
            }
        }

        override public void DisplayPieceInfo()
        {
            Console.WriteLine($"Handle Stats: Type: {getHandleType()}, Material: {getMaterial()}, Speed: {getSpeed()}, Durability: {getDurability()}, Rarity: {getRarity()}, Price: {getPrice()}");
        }

        public Handle(HandleType handleType, Material material)
        {
            setPieceType(PieceType.handle);
            setHandleType(handleType);
            setMaterial(material);
            combineStats();
        }
    }


}
