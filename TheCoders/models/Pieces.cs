using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    internal abstract class Pieces
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

        internal int setAttack(int attack)
        {
            this.attack = attack;
        }
        internal void setSpeed(int speed)
        {
            this.speed = speed;
        }
        internal void setDurability(int durability)
        {
            this.durability = durability;
        }
        internal void setMaterial(Material material)
        {
            this.material = material;
        }
        internal void setPieceName(string pieceName)
        {
            this.pieceName = pieceName;
        }
        internal void setPieceType(PieceType pieceType)
        {
            this.pieceType = pieceType;
        }
        internal void setEnchantTier(int enchantTier)
        {
            this.enchantTier = enchantTier;
        }
        internal abstract void combineStats();
    }

    internal class blade : Pieces
    {
        PieceType type = PieceType.blade;
        public enum BladeType
        {
            Short,
            Long,
            Great
        }
        private BladeType bladeType;

        internal void setBladeType(BladeType bladeType)
        {
            this.bladeType = bladeType;
        }
        public BladeType getBladeType()
        {
            return bladeType;
        }
        override internal void combineStats()
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
                    setDurability(getDurability() + 1);
                    setEnchantTier(1);
                    break;
                case Material.stone:
                    setAttack(getAttack() + 1);
                    setDurability(getDurability() + 2);
                    setEnchantTier(1);
                    break;
                case Material.bronze:
                    setAttack(getAttack() + 2);
                    setDurability(getDurability() + 3);
                    setEnchantTier(2);
                    break;
                case Material.steel:
                    setAttack(getAttack() + 3);
                    setDurability(getDurability() + 4);
                    setEnchantTier(2);
                    break;
                case Material.gold:
                    setAttack(getAttack() + 1);
                    setDurability(getDurability() + 1);
                    setSpeed(getspeed() + 2);
                    setEnchantTier(3);
                    break;
                case Material.adamantine:
                    setAttack(getAttack() + 5);
                    setDurability(getDurability() + 5);
                    setEnchantTier(3);
                    break;
                case Material.mithril:
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
    internal class handle : Pieces
    {
        PieceType type = PieceType.handle;
        public enum HandleType
        {
            Short,
            Long,
            Medium
        }
        private HandleType handleType;

        internal void setHandleType(HandleType handleType)
        {
            this.handleType = handleType;
        }
        public HandleType getHandleType()
        {
            return handleType;
        }
        override internal void combineStats()
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
                    setDurability(getDurability() + 1);
                    break;
                case Material.stone:
                    setDurability(getDurability() + 2);
                    break;
                case Material.bronze:
                    setDurability(getDurability() + 3);
                    break;
                case Material.steel:
                    setDurability(getDurability() + 4);
                    break;
                case Material.gold:
                    setDurability(getDurability() + 1);
                    setSpeed(getspeed() + 2);
                    break;
                case Material.adamantine:
                    setDurability(getDurability() + 5);
                    break;
                case Material.mithril:
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
