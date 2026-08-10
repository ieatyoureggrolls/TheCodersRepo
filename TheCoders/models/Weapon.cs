using System;
using System.Collections.Generic;
using System.Text;
using TheCoders.models;

namespace TheCoders
{
    public class Weapon
    {
        //TODO: Create pieces for each piece of a weapon, add properties for weapon pieces and stats,
        //add methods to calculate stats based on weapon pieces, add methods to display weapon information
        
        Pieces blade = new Blade();
        Pieces handle = new Handle();

        int attack = blade.getAttack() + handle.getAttack();
        int speed = blade.getspeed() + handle.getspeed();
        int durability = blade.getDurability() + handle.getDurability();
    }



}
