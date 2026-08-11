using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.models
{
    public static class Storymode
    {

        public static void main(Person[] theParty)
        {
            Level1(theParty);
        }

        public static void Level1(Person[] theParty) 
        {
            Console.WriteLine("\n\nYou are the greatest blacksmith in this village help the heros by making weapons for them\n ");
            
            for (int i = 0; i <= theParty.Length; i++) 
            {


                if (i  == theParty.Length) 
                {
                    Console.WriteLine($"the team consists of {i} heroes you must make a weapon for all of them");
                }    

            }



        }



        

    }
}
