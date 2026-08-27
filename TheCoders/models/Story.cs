using TheCoders.controllers;
using TheCoders.views;
using TheCoders.models.Generators;
using COH = TheCoders.views.ConsoleOutputHelper;

namespace TheCoders.models
{
    public static class Storymode
    {
        static int availableLevels = 1;
        const int minimumLevels = 1;
        private static Person[] theParty = { new Person("hero:Bob", 100, 5, 1, true), new Person("hero:Billy", 100, 5, 1, true), new Person("hero:Joe", 100, 5, 1, true) };
        private static List<Weapon> weaponStorage = new List<Weapon>();

        public static void main()
        {

            //playerChoice();
            Console.Clear();
            ChooseLevel(availableLevels);


        }

        /*
         * tasks needed to complete:
         * 
         * methods
         
         * level1 player spectates the computer making a weapon and sees the auto battler (complete)
         * level2 player makes a weapon for the second hero and watches auto battler (complete) 
         * level3 weapons are low on durability so player learns to repair weapons (partially complete) display weapon durability and then ask player to repair
         * level4 player learns to replace weapons (partially complete)
         * level5 player upgrades existing wepons with enchantmets? perhaps (partially complete)
         * 
         *make a method that display weapon durability when the enemy status is being shown (light work)
         *
         *find a way to delay dialogoue in story mode (idk)
         *
         *let the player choose which action tehy would like to perform instead of forcing it (make the method, in progress)
         *
         */


        private static void TakeToLevel(int levelSelect)
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

        private static void ChooseLevel(int availableLevels)
        {



            int selectedLevel = CIO.PromptForInt("What level would you like to go too?: ", minimumLevels, availableLevels);


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
                    ChooseLevel(availableLevels);
                    break;

            }


        }

        private static void Level1()
        {

            ConsoleOutputHelper.ClearScreen();

            Enemy[] enemies = EnemyGenerator.GenerateEnemies(1, 1);

            const int currentLevel = 1;

            //ConsoleOutputHelper.PrintCombatantParty(enemies);

            //Console.WriteLine("\n\nYou are the greatest blacksmith in this village help the heros by making weapons for them\n ");
            //Console.WriteLine($"the team consists of {theParty.Length} heroes you must make a weapon for all of them");
            //Console.WriteLine("\n\nTake a look the enemies are quickly approaching\n");
            string intro = $"You are the greatest blacksmith in this village help the heros by making weapons for them the team consists of {theParty.Length} heroes. You must make a weapon for all of them. Take a look, the enemies are quickly approaching!";
            COH.PrintStory(intro, 7);
            COH.PrintCombatantParty(enemies);




            Weapon tutorialWeapon = Weapon.giveWeapon(Blade.BladeType.Long, Pieces.Material.wood, Handle.HandleType.Long, Pieces.Material.wood);
            tutorialWeapon.renameWeapon("wood you like something better?");

            //Weapon tutorialWeapon = Weapon.giveWeapon(Blade.BladeType.Long, Pieces.Material.adamantine, Handle.HandleType.Long, Pieces.Material.adamantine);

            //Console.WriteLine("\n I don't have time to explain things to you right now take this sword\n");
            COH.PrintStory("I don't have time to explain things to you right now take this sword!", 7);
            tutorialWeapon.displayWeaponInfo();
            //COH.
            //Console.WriteLine("\nNow pick which hero will get this weapon, once you do the battle will begin\n");
            COH.PrintStory("Now pick which hero will get this weapon, once you do the battle will begin", 5);

            WhoGetsAWeapon(theParty, tutorialWeapon);

            ConsoleOutputHelper.ClearScreen();

            LevelLoop.Battle(enemies.ToList(), theParty);

            WinOrLose(theParty, currentLevel);
            IncreaseAvailableLevel(currentLevel);
            WantNextLevel(currentLevel);


        }



        private static void Level2()
        {
            HealPlayer();

            ConsoleOutputHelper.ClearScreen();
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(1,2);
            const int currentLevel = 2;

            ConsoleOutputHelper.PrintCombatantParty(enemies);

            Console.WriteLine("\n\nMore enemies are coming, one hero won't be enought to hold them off its time for you to make a weapon too\n");
            Console.WriteLine("\n these guys are tought try making something better than a wooden sword");

          

            Weapon newWeapon = Weapon.createWeapon(2); 
            Console.WriteLine("\n");
            newWeapon.displayWeaponInfo();
            Console.WriteLine("\n thats a great weapon for our new hero");
            WhoGetsAWeapon(theParty, newWeapon);

            Console.WriteLine("\n\n2 vs 2 is much more of a fair fight\n\n");

            LevelLoop.Battle(enemies.ToList(), theParty);



            WinOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            WantNextLevel(currentLevel);

        }

        private static void Level3()
        {

            HealPlayer();

            ConsoleOutputHelper.ClearScreen();
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(1, 2);
            const int currentLevel = 3;
            ConsoleOutputHelper.PrintCombatantParty(enemies);

            //theParty[0].heldWeapon.breakWeapon();
            theParty[0].heldWeapon.displayWeaponInfo();

            

            Console.WriteLine($"\n\n you can't win with a broken weapon try repairing {theParty[0].Name}'s weapon");

            RepairWeapon();

            Console.WriteLine("\n\ngood now the heroes are able to continue fighting");

            LevelLoop.Battle(enemies.ToList(), theParty);

            WinOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            WantNextLevel(currentLevel);

        }

        private static void Level4()
        {

            HealPlayer();

            ConsoleOutputHelper.ClearScreen();
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(2, 2);
            Enemy boss = EnemyGenerator.GenerateOneEnemy(1, true);

            Enemy[] army = new Enemy[enemies.Length + 1];
            Array.Copy(enemies, army, enemies.Length);
            army[enemies.Length] = boss;

            const int currentLevel = 4;
            ConsoleOutputHelper.PrintCombatantParty(army);

            Console.WriteLine("\n\n from here on out its all you, im sure you can handle whatevers coming");
            Console.WriteLine("\n\nit seems that the enemy side has a boss character do your best those guys are tought");

            playerChoice();

            LevelLoop.Battle(army.ToList(), theParty);

            WinOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            WantNextLevel(currentLevel);

        }

        private static void Level5()
        {

            HealPlayer();

            ConsoleOutputHelper.ClearScreen();
            const int currentLevel = 5;

            Console.WriteLine("\n\n Good job defeating that boss, now that the village is defended its time to go on the offensive");

            //call enemy inspect method

            Console.WriteLine("\n\nwow thats a lot of them good luck you know what to do");

            //create wepon method

            //auto battler method

            WinOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            WantNextLevel(currentLevel);

        }



        private static void WinOrLose(Person[] theParty, int currentLevel)
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
                    TakeToLevel(currentLevel);
                }
                else
                {
                    ReturnToMainMenu();

                }


            }
            else
            {
                Console.WriteLine("\n==============\n!!!VICTORY!!!\n==============\n");
            }

        }

        private static void WantNextLevel(int currentLevel)
        {



            int input = CIO.PromptForMenuSelection(["Go to next level", "go to level select"], true);
            switch (input)
            {


                case 1:

                    ConsoleOutputHelper.ClearScreen();
                    TakeToLevel(currentLevel + 1);
                    break;

                case 2:


                    ConsoleOutputHelper.ClearScreen();
                    ChooseLevel(availableLevels);
                    break;

                default:

                    ConsoleOutputHelper.ClearScreen();
                    ReturnToMainMenu();
                    break;
            }



        }

        private static void HealPlayer() 
        {
            for(int i =0; i < (theParty.Length); i++) 
            {

                theParty[i].CurrentHealth = theParty[i].MaxHealth;

            }

        }

        private static void WhoGetsAWeapon(Person[] theParty, Weapon weapon)
        {


            ConsoleOutputHelper.PrintHeroNames(theParty);

            int heroSlot = CIO.PromptForInt($"which of the heroes from slot 1 to {theParty.Length} do you want to recieve the weapon", 1, theParty.Length);

            theParty[heroSlot - 1].EquipWeapon(weapon);

        }

        


        public static void playerChoice() 
        {

                           
            bool isCrafting = true;
            do
            {
                Console.WriteLine("What would you like to do?");
                string[] possibleMenus = { "Skip", "Craft Weapon", "Repair Weapon", "Replace Weapon", "Upgrade Weapon(work in progress)", "Enchant Weapon(work in progress)", "displayWeaponStats(work in progress)", "Craftpedia(work in progress)" };
                int selection = CIO.PromptForMenuSelection(possibleMenus, false);
                switch (selection)
                {
                    case 1:
                        isCrafting = false;
                        break;
                    case 2:
                        MakeWeapon();
                        
                        break;
                    case 3:
                        RepairWeapon(); 
                        break;
                    case 4:
                        ReplaceWeapon(); //not tested
                        break;
                    case 5:
                     //   UpgradeWeapon(); //not complete but apparently in the weapon class
                        break;
                    case 6:
                        //  EnchantWeapon(); //not complete but apparently in the weapon class
                        break;
                    case 7:
                        //  displayweaponstats
                        break;
                    case 8:
                        // search the craftpedia
                        break;
                }
            } while (isCrafting);
        }

        private static void ReplaceWeapon() 
        {

            Console.WriteLine("\n\nWhich weapon would you like to equip");
            List<string> weaponNames = new List<string>();
            foreach (Weapon weapon in weaponStorage) 
            {
                weaponNames.Add(weapon.getName());
            }

           int selection = (CIO.PromptForMenuSelection(weaponNames,true)-1);
           Weapon chosenWeapon = weaponStorage.ElementAt(selection);
           int heroSlot = ChooseHero();


            if (heroSlot >= 0 && heroSlot < (theParty.Length-1))
            {
                weaponStorage.Add(theParty[heroSlot].heldWeapon);
                theParty[heroSlot].EquipWeapon(chosenWeapon);
                weaponStorage.RemoveAt(selection);
            }
            else
            {
                Console.WriteLine("Invalid hero selection.");
            }

            



            Console.WriteLine("\n\n");
        }

        private static void RepairWeapon()
        {
            int heroSlot = ChooseHero();

            if (theParty[heroSlot].heldWeapon != null)
            {

                theParty[heroSlot].heldWeapon.repairWeapon();
            }
            else
            {
                Console.WriteLine($"the hero {theParty[heroSlot].Name} does not have a weapon that need repairing");
            }

            Console.WriteLine("\n\n");
        }

        private static void MakeWeapon() 
        {
            int heroSlot = ChooseHero();
            Weapon newWeapon = Weapon.createWeapon();

            if (theParty[heroSlot].heldWeapon != null)
            {
                weaponStorage.Add(theParty[heroSlot].heldWeapon);
             
            }

            theParty[heroSlot].EquipWeapon(newWeapon);
            Console.WriteLine("\n\n");
            

        }
        private static int ChooseHero() //not complete
        {

            int heroSlot = CIO.PromptForInt($"which heroes from slot 1 to {theParty.Length} do you want to choose", 1, theParty.Length);
            ConsoleOutputHelper.PrintHeroNames(theParty);
            return heroSlot-1;

        }


        private static void IncreaseAvailableLevel(int currentLevel)
        {
            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }
        }

        private static void ReturnToMainMenu()
        {
            Runner theRunner = new Runner();
            theRunner.Run();
        }

      

    }
}
