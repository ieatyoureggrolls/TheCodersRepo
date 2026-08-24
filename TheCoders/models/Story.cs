using CSC160_ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TheCoders.controllers;
using TheCoders.views;
using TheCoders.models.Generators;


namespace TheCoders.models
{
    public static class Storymode
    {
        static int availableLevels = 1;
        const int minimumLevels = 1;
        private static Person[] theParty = { new Person("hero:Bob", 100, 5, 25, true), new Person("hero:Billy", 100, 5, 1, true), new Person("hero:Joe", 100, 5, 1, true) };

        public static void main()
        {
            

            chooseLevel(availableLevels);

            
        }

        /*
         * tasks needed to complete:
         * 
         * methods
         
         * level1 player spectates the computer making a weapon and sees the auto battler (complete)
         * level2 player makes a weapon for the second hero and watches auto battler (partially complete)
         * level3 weapons are low on durability so player learns to repair weapons (partially complete)
         * level4 player learns to replace weapons (partially complete)
         * level5 player upgrades existing wepons with enchantmets? perhaps (partially complete)
         * 
         *
         */


        private static void takeToLevel(int levelSelect)
        {

            switch (levelSelect)
            {
                case (1):
                    Level1();
                    break;

                case (2):
                    Level2();
                    break;

                case (3):
                    Level3();
                    break;

                case (4):
                    Level4();
                    break;

                case (5):
                    Level5();
                    break;
                default:
                    Console.WriteLine("Sorry that wasn't a proper level");

                    break;
            }

        }

        private static void chooseLevel(int availableLevels)
        {

            

            int selectedLevel = CIO.PromptForInt("What level would you like to go too?: ",minimumLevels,availableLevels);
                      
                
                switch (selectedLevel)
                {
                    case (1):
                        Level1();
                        break;

                    case (2):
                        Level2();
                        break;

                    case (3):
                        Level3();
                        break;

                    case (4):
                        Level4();
                        break;

                    case (5):
                        Level5();
                        break;

                default:
                        Console.WriteLine("Sorry that wasn't a proper level choose something else");
                        chooseLevel(availableLevels);
                        break;

                }
                             
                       
        }

        private static void Level1()
        {

            ConsoleOutputHelper.ClearScreen();

            Enemy[] enemies =  EnemyGenerator.GenerateEnemies(1, 1);

           const int currentLevel = 1;

           Console.WriteLine("\n\nYou are the greatest blacksmith in this village help the heros by making weapons for them\n ");
           Console.WriteLine($"the team consists of {theParty.Length} heroes you must make a weapon for all of them");
           Console.WriteLine("\n\nTake a look the enemies are quickly approaching\n");

            ConsoleOutputHelper.PrintCombatantParty(enemies);

            Weapon tutorialWeapon = Weapon.giveWeapon(Blade.BladeType.Long,Pieces.Material.wood,Handle.HandleType.Long,Pieces.Material.wood);

            Console.WriteLine("\n I don't have time to explain things to you right now take this sword\n");
            tutorialWeapon.displayWeaponInfo();
            Console.WriteLine("\nNow pick which hero will get this weapon, once you do the battle will begin\n");
                        
            whoGetsAWeapon(theParty, tutorialWeapon);

            ConsoleOutputHelper.ClearScreen();

            LevelLoop.Battle(enemies.ToList(), theParty);

            winOrLose(theParty, currentLevel);
            increaseAvailableLevel(currentLevel);          
            wantNextLevel(currentLevel);


        }

        private static void Level2() 
        {
            ConsoleOutputHelper.ClearScreen();
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(2,2);
            const int currentLevel = 2;

            Console.WriteLine("More enemies are coming, one hero won't be enought to hold them off its time for you to make a weapon too\n");

            ConsoleOutputHelper.PrintCombatantParty(enemies);

            Console.WriteLine("\n these guys are tought try making something better than a wooden sword");

            Weapon newWeapon = Weapon.createWeapon(); // find a way to limit the materials available to the player
            Console.WriteLine("\n");
            newWeapon.displayWeaponInfo();
            Console.WriteLine("\n thats a great weapon for our new hero");
            whoGetsAWeapon(theParty,newWeapon);

            Console.WriteLine("\n\n2 vs 2 is much more of a fair fight\n\n");

            LevelLoop.Battle(enemies.ToList(), theParty);



            winOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel) {

                availableLevels++;

            }

            wantNextLevel(currentLevel);

        }

        private static void Level3() 
        {
            ConsoleOutputHelper.ClearScreen();
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

            wantNextLevel(currentLevel);

        }

        private static void Level4()
        {
            ConsoleOutputHelper.ClearScreen();
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

            wantNextLevel(currentLevel);

        }

        private static void Level5()
        {
            ConsoleOutputHelper.ClearScreen();
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

            wantNextLevel(currentLevel);

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


                string input = CIO.PromptForInput("\n\nWould you like to restart the level?\nYes: Y\n No: N ", false);

                if (input == "Y" || input == "YES")
                {
                    takeToLevel(currentLevel);
                }
                else
                {
                    returnToMainMenu();

                }


            }
            else {
                Console.WriteLine("\n==============\n!!!VICTORY!!!\n==============\n");
            }

        }

        private static void wantNextLevel(int currentLevel)
        {


            
                int input = CIO.PromptForMenuSelection(["Go to next level", "go to level select"], true);
                switch (input)
                {


                    case 1:

                    ConsoleOutputHelper.ClearScreen();
                    takeToLevel(currentLevel + 1);
                        break;

                    case 2:


                    ConsoleOutputHelper.ClearScreen();
                    chooseLevel(availableLevels);
                        break;

                    default:

                    ConsoleOutputHelper.ClearScreen();
                    returnToMainMenu();
                        break;
                }
            
            

        }

        private static void limitedCrafting() 
        {
        
        }

        private static void whoGetsAWeapon(Person[] theParty, Weapon weapon) 
        {

            

            ConsoleOutputHelper.PrintHeroNames(theParty);

            int heroSlot = CIO.PromptForInt($"which of the heroes from slot 1 to {theParty.Length} do you want to recieve the weapon", 1, theParty.Length); 
               
            theParty[heroSlot - 1].EquipWeapon(weapon); 

        }

        


        private static void battlerLoop(Enemy[] enemies, Person[] theParty, Weapon weapon) 
        {

            ConsoleOutputHelper.ClearScreen();
            Weapon newWeapon = Weapon.createWeapon();
            ConsoleOutputHelper.ClearScreen();
            
            Console.WriteLine("\n\n");
            whoGetsAWeapon(theParty, weapon);
            ConsoleOutputHelper.ClearScreen();
            LevelLoop.Battle(enemies.ToList(), theParty);

        }

        private static void increaseAvailableLevel(int currentLevel) 
        {
            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }
        }

        private static void returnToMainMenu() 
        {
            Runner theRunner = new Runner();
            theRunner.Run();
        }




    }
}
