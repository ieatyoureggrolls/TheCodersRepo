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
        enum Material
        {
            wood,
            stone,
            steel,
            bronze
        }
        PieceType pieceType;
        Material material;
        string pieceName;
        int attack;
        int speed;
        int durability;
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
        internal abstract void combineStats();
    }

    internal class blade : Pieces
    {
        PieceType type = PieceType.blade;
        enum BladeType
        {
            shortBlade,
            longBlade,
            curvedBlade
        }
        BladeType bladeType;
        override internal void combineStats()
        {
            switch (bladeType)
            {
                case BladeType.shortBlade:
                    setAttack(2);
                    setSpeed(3);
                    break;
                case BladeType.longBlade:
                    setAttack(4);
                    setSpeed(1);
                    break;
                case BladeType.curvedBlade:
                    setAttack(3);
                    setSpeed(2);
                    break;
            }
            switch (getMaterial())
            {
                case Material.wood:
                    setDurability(getDurability() + 1);
                    break;
                case Material.steel:
                    setAttack(getAttack() + 3);
                    setDurability(getDurability() + 4);
                    break;
                case Material.stone:
                    setAttack(getAttack() + 1);
                    setDurability(getDurability() + 2);
                    break;
                case Material.bronze:
                    setAttack(getAttack() + 2);
                    setDurability(getDurability() + 3);
                    break;
            }
        }
        combineStats();
    }
    internal class handle : Pieces
    {
        PieceType type = PieceType.handle;
        enum HandleType
        {
            SHORT,
            LONG,
            MEDIUM
        }
        HandleType handleType;

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
            switch (handleType)
            {
                case HandleType.SHORT:
                    setAttack(1);
                    setSpeed(2);
                    break;
                case HandleType.MEDIUM:
                    setAttack(2);
                    setSpeed(1);
                    break;
                case HandleType.LONG:
                    setAttack(3);
                    setSpeed(1);
                    break;
            }
            switch (getMaterial())
            {
                case Material.wood:
                    setDurability(getDurability() + 1);
                    break;
                case Material.steel:
                    setDurability(getDurability() + 4);
                    break;
                case Material.stone:
                    setDurability(getDurability() + 2);
                    break;
                case Material.bronze:
                    setDurability(getDurability() + 3);
                    break;
            }
        }
        combineStats();
    }
}
