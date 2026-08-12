using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public abstract class Pieces
    {
        enum PieceType
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
        string pieceName;
        int attack;
        int speed;
        int durability;
        int enchantTier;
        int rarity;

        public int getRarity()
        {
            return rarity;
        }

        public int getAttack()
        {
            return attack;
        }
        public int getspeed()
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
        public string getPieceName()
        {
            return pieceName;
        }
        public int getEnchantTier()
        {
            return enchantTier;
        }

        public void setRarity(int rarity)
        {
            this.rarity = rarity;
        }

        public int setAttack(int attack)
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
        public void setPieceName(string pieceName)
        {
            this.pieceName = pieceName;
        }
        public void setPieceType(PieceType pieceType)
        {
            this.pieceType = pieceType;
        }
        public void setEnchantTier(int enchantTier)
        {
            this.enchantTier = enchantTier;
        }
        public abstract void combineStats();
    }

    public class blade : Pieces
    {
        PieceType type = PieceType.blade;
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
                    break;
            }
            switch (getMaterial())
            {
                case Material.wood:
                    setRarity(1);
                    setDurability(getDurability() + 1);
                    setEnchantTier(1);
                    break;
                case Material.stone:
                    setRarity(2);
                    setAttack(getAttack() + 1);
                    setDurability(getDurability() + 2);
                    setEnchantTier(1);
                    break;
                case Material.bronze:
                    setRarity(3);
                    setAttack(getAttack() + 2);
                    setDurability(getDurability() + 3);
                    setEnchantTier(2);
                    break;
                case Material.steel:
                    setRarity(4);
                    setAttack(getAttack() + 3);
                    setDurability(getDurability() + 4);
                    setEnchantTier(2);
                    break;
                case Material.gold:
                    setRarity(4);
                    setAttack(getAttack() + 1);
                    setDurability(getDurability() + 1);
                    setSpeed(getspeed() + 2);
                    setEnchantTier(3);
                    break;
                case Material.adamantine:
                    setRarity(5);
                    setAttack(getAttack() + 5);
                    setDurability(getDurability() + 5);
                    setEnchantTier(3);
                    break;
                case Material.mithril:
                    setRarity(5);
                    setAttack(getAttack() + 2);
                    setDurability(getDurability() + 4);
                    setEnchantTier(4);
                    break;
            }
        }
        public blade(BladeType bladeType, Material material)
        {
            setPieceType(bladeType);
            setMaterial(material);
            combineStats();
        }
    }
    public class handle : Pieces
    {
        PieceType type = PieceType.handle;
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
                case HandleType.SHORT:
                    setSpeed(3);
                    break;
                case HandleType.MEDIUM:
                    setSpeed(2);
                    break;
                case HandleType.LONG:
                    setSpeed(1);
                    break;
            }
            switch (getMaterial())
            {
                case Material.wood:
                    setRarity(1);
                    setDurability(getDurability() + 1);
                    break;
                case Material.stone:
                    setRarity(2);
                    setDurability(getDurability() + 2);
                    break;
                case Material.bronze:
                    setRarity(3);
                    setDurability(getDurability() + 3);
                    break;
                case Material.steel:
                    setRarity(4);
                    setDurability(getDurability() + 4);
                    break;
                case Material.gold:
                    setRarity(4);
                    setDurability(getDurability() + 1);
                    setSpeed(getspeed() + 2);
                    break;
                case Material.adamantine:
                    setRarity(5);
                    setDurability(getDurability() + 5);
                    break;
                case Material.mithril:
                    setRarity(5);
                    setDurability(getDurability() + 4);
                    break;
            }
        }

        public handle(HandleType handleType, Material material)
        {
            setHandleType(handleType);
            setMaterial(material);
            combineStats();
        }
    }


}
