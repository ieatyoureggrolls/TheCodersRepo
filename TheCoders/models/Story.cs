using CSC160_ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TheCoders.controllers;
using TheCoders.views;

namespace TheCoders.models
{
    public static class Storymode
    {
        static int availableLevels = 1;
        const int minimumLevels = 1;

        public static void main(Person[] theParty)
        {
            

            chooseLevel(theParty, availableLevels);

            
        }

        /*
         * tasks needed to complete:
         * 
         * methods
         * takeToLevel should take a player to a level without requiring inputs (complete but needs testing)
         * winOrLose on a loss the player is asked if they would like to restart the level or go to main menu (complete but needs testing)
         * returnToMainMenu() return to the main menu where the player can select story or endless mode (complete but needs testing)
         * 
         * level1 player spectates the computer making a weapon and sees the auto battler (partially complete)
         * level2 player makes a weapon for the second hero and watches auto battler (partially complete)
         * level3 weapons are low on durability so player learns to repair weapons (partially complete)
         * level4 player learns to replace weapons (partially complete)
         * level5 player upgrades existing wepons with enchantmets? perhaps (partially complete)
         * 
         * weapon creation methods-
         * create weapon
         * upgrade weapon
         * give weapon to hero
         * upgrade weapon from hero
         * replace weapon from hero
         */


        private static void takeToLevel(int levelSelect, Person[] theParty)
        {

            switch (levelSelect)
            {
                case (1):
                    Level1(theParty);
                    break;

                case (2):
                    Level2(theParty);
                    break;

                case (3):
                    Level3(theParty);
                    break;

                case (4):
                    Level4(theParty);
                    break;

                case (5):
                    Level5(theParty);
                    break;
                default:
                    Console.WriteLine("Sorry that wasn't a proper level");

                    break;
            }

        }

        private static void chooseLevel(Person[] theParty, int availableLevels)
        {

            

            int selectedLevel = CIO.PromptForInt("What level would you like to go too?: ",minimumLevels,availableLevels);
                      
                
                switch (selectedLevel)
                {
                    case (1):
                        Level1(theParty);
                        break;

                    case (2):
                        Level2(theParty);
                        break;

                    case (3):
                        Level3(theParty);
                        break;

                    case (4):
                        Level4(theParty);
                        break;

                    case (5):
                        Level5(theParty);
                        break;

                default:
                        Console.WriteLine("Sorry that wasn't a proper level choose something else");
                        chooseLevel(theParty, availableLevels);
                        break;

                }
                             
                       
        }

        private static void Level1(Person[] theParty)
        {

           Enemy[] enemies =  EnemyGenerator.GenerateEnemies(1, 2);

            const int currentLevel = 1;

            Console.WriteLine("\n\nYou are the greatest blacksmith in this village help the heros by making weapons for them\n ");

                   
                      
                    Console.WriteLine($"the team consists of {theParty.Length} heroes you must make a weapon for all of them");
           
                   

            Console.WriteLine("\n\n im gonna make the first weapon so pay attention.\n from the following choice below im going to pick 'placeholder' as our 'placeholder'\n");

            // write code that finds all the options for step one of the weapon building

            //Weapon tutorialWeapon = new Weapon();

            Weapon tutorialWeapon = Weapon.createWeapon();

            theParty[0].EquipWeapon(tutorialWeapon);

             
            ConsoleOutputHelper.PrintCombatantParty(enemies);

            //ConsoleOutputHelper.PrintBattleStanding(theParty, enemies); this method doesnt exist yet
            

            //whoGetsAWeapon(theParty);
            

            Console.WriteLine("\n\n 'placeholder' has 'placeholder' as its stats keep those stats in mind when making weapons ");
            Console.WriteLine("\nnow that the wepon is made i'll equip it to one of the heroes\n");

            


            Console.WriteLine("once the wepons are made and equiped just sit back and watch the show");


            Runner runner = new Runner();
            runner.Battle(enemies.ToList());
            //call the method that does auto battle


            winOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }



            wantNextLevel(currentLevel, theParty);


        }

        private static void Level2(Person[] theParty) 
        {
            const int currentLevel = 2;

            Console.WriteLine("More enemies are coming one hero won't be enought to hold them off its time for you to make a weapon too\n before every battle you get to see what you're up against");

            //call enemy inspect method


            //call the make weapon method

            Console.WriteLine("\n\ngood job, having two heroes makes this much more of a fair fight");

            //call auto battler method

            

            winOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel) {

                availableLevels++;

            }

            wantNextLevel(currentLevel, theParty);

        }

        private static void Level3(Person[] theParty) 
        {
            const int currentLevel = 3;

            Console.WriteLine("\n\n It seems like your weapons are low on durability sometimes its better to repair them than to make new ones");

            //repair weapon method

            Console.WriteLine("\n\ngood now the heroes are able to continue fighting");

            //auto battler method

            winOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            wantNextLevel(currentLevel, theParty);

        }

        private static void Level4(Person[] theParty)
        {
            const int currentLevel = 4;

            Console.WriteLine("\n\n from here on out its all you im sure you can handle whatevers coming");

            //call enemy inspect method


            Console.WriteLine("\n\nit seems that the enemy side has a boss character do your best those guys are tought");

            //create wepon method

            //auto battler method

            winOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            wantNextLevel(currentLevel,theParty);

        }

        private static void Level5(Person[] theParty)
        {
            const int currentLevel = 5;

            Console.WriteLine("\n\n Good job defeating that boss, now that the village is defended its time to go on the offensive");

            //call enemy inspect method

            Console.WriteLine("\n\nwow thats a lot of them good luck you know what to do");

            //create wepon method

            //auto battler method

            winOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            wantNextLevel(currentLevel, theParty);

        }



        private static void winOrLose(Person[] theParty, int currentLevel)
        {
            int fallenHeros = 0;
            for (int i = 0; i < theParty.Length; i++)
            {
                if (theParty[i].CurrentHealth == 0)
                {
                    fallenHeros++;
                }

            }

            if (fallenHeros == theParty.Length)
            {
                Console.WriteLine("All the heros have fallen they cannot continue\n\n Game Over!");


                string input = CIO.PromptForInput("\n\nWould you like to restart the level?\nYes: Y\n No: N ",false);

                if (input == "Y" || input == "YES")
                {
                    takeToLevel(currentLevel, theParty);
                }
                else 
                {
                    returnToMainMenu();

                }


            }

        }

        private static void wantNextLevel(int currentLevel, Person[] theParty)
        {


            
                int input = CIO.PromptForMenuSelection(["Go to next level", "go to level select"], true);
                switch (input)
                {


                    case 1:

                    ConsoleOutputHelper.ClearScreen();
                    takeToLevel(currentLevel + 1, theParty);
                        break;

                    case 2:


                    ConsoleOutputHelper.ClearScreen();
                    chooseLevel(theParty, availableLevels);
                        break;

                    default:

                    ConsoleOutputHelper.ClearScreen();
                    returnToMainMenu();
                        break;
                }
            
            

        }

        private static void whoGetsAWeapon(Person[] theParty) 
        {

            int heroSlot = CIO.PromptForInt($"which of the heroes from slot 0 to {theParty.Length - 1} do you want to recieve the weapon", 0, theParty.Length - 1); 
               


            //Weapon weapon = new Weapon.createWeapon();
            //theParty[heroSlot].EquipWeapon(weapon);

        }

        private static void returnToMainMenu() 
        {
            Runner theRunner = new Runner();
            theRunner.Run();
        }




    }
}
