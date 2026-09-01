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
         * bugs and missing feature
         * player choice cannot exit once an option is selected
         * when its asking which hero to pick it looks ugly and shows too much uneccessary information
         * for some reason it stopped me at level 5 and didn't let me go to level 6
         * the gold that the user has is not displayed
         * weapons have no cost so its meta to make weapons then heal heroes
         * 
         * 
         * */




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

                case (6):
                    Level6();
                    break;

                case (7):
                    Level7();
                    break;

                default:
                    Console.WriteLine("Sorry that wasn't a proper level choose something else");
                    ChooseLevel(availableLevels);
                    break;

            }


        }

        private static void Level1()
        {

            COH.ClearScreen();

            Enemy[] enemies = EnemyGenerator.GenerateEnemies(1, 1);

            const int currentLevel = 1;


            string intro = $"You are the greatest blacksmith in this village help the heros by making weapons for them the team consists of {theParty.Length} heroes. You must make a weapon for all of them. Take a look, the enemies are quickly approaching!";
            COH.PrintStory(intro, 25);
            COH.PrintCombatantParty(enemies);




            Weapon tutorialWeapon = Weapon.giveWeapon(Blade.BladeType.Long, Pieces.Material.wood, Handle.HandleType.Long, Pieces.Material.wood);
            tutorialWeapon.renameWeapon("wood you like something better?");


            COH.PrintStory("I don't have time to explain things to you right now take this sword!", 7);
            tutorialWeapon.displayWeaponInfo();

            COH.PrintStory("Now pick which hero will get this weapon, once you do the battle will begin", 5);

            WhoGetsAWeapon(theParty, tutorialWeapon);

            COH.ClearScreen();

            LevelLoop.Battle(enemies.ToList(), theParty);

            WinOrLose(theParty, currentLevel);
            IncreaseAvailableLevel(currentLevel);
            WantNextLevel(currentLevel);


        }



        private static void Level2()
        {


            COH.ClearScreen();
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(1, 2);
            const int currentLevel = 2;

            COH.PrintStory("More enemies are coming, one hero won't be enought to hold them off its time for you to make a weapon too, these guys are tought try making something better than a wooden sword ", 20);


            COH.PrintCombatantParty(enemies);




            Weapon newWeapon = Weapon.createWeapon(2);
            Console.WriteLine("\n");
            newWeapon.displayWeaponInfo();
            COH.PrintStory("thats a great weapon for our new hero,\n 2 vs 2 is much more of a fair fight", 7);
            WhoGetsAWeapon(theParty, newWeapon);



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



            COH.ClearScreen();
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(1, 2);
            const int currentLevel = 3;
            COH.PrintCombatantParty(enemies);

            theParty[0].heldWeapon.displayWeaponInfo();


            COH.PrintStory($"you can't win with a broken weapon try repairing {theParty[0].Name}'s weapon", 7);
            RepairWeapon();
            COH.PrintStory("good now the heroes are able to continue fighting", 7);

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



            COH.ClearScreen();
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(2, 2);
            Enemy boss = EnemyGenerator.GenerateOneEnemy(1, true);

            Enemy[] army = new Enemy[enemies.Length + 1];
            Array.Copy(enemies, army, enemies.Length);
            army[enemies.Length] = boss;

            const int currentLevel = 4;
            COH.PrintCombatantParty(army);

            COH.PrintStory("it seems that the enemy side has a boss character do your best those guys are tought", 20);

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




            COH.ClearScreen();
            const int currentLevel = 5;
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(1, 5);

            COH.PrintStory("Good job defeating that boss, now that the village is defended its time to go on the offensive", 7);

            COH.PrintCombatantParty(enemies);

            COH.PrintStory("\n\nwow thats a lot of them good luck you know what to do", 7);

            playerChoice();

            LevelLoop.Battle(enemies.ToList(), theParty);

            WinOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            WantNextLevel(currentLevel);

        }

        private static void Level6()
        {




            COH.ClearScreen();
            const int currentLevel = 6;
            Enemy[] enemies = EnemyGenerator.GenerateEnemies(3, 3);

            COH.PrintStory("I think this is the last of the evil king's defences, after this he'll be left defenceless ", 7);

            COH.PrintCombatantParty(enemies);

            playerChoice();

            LevelLoop.Battle(enemies.ToList(), theParty);

            WinOrLose(theParty, currentLevel);

            if (availableLevels == currentLevel)
            {

                availableLevels++;

            }

            WantNextLevel(currentLevel);

        }

        private static void Level7()
        {



            COH.ClearScreen();

            Enemy King = EnemyGenerator.GenerateOneEnemy(3, true);
            Enemy Queen = EnemyGenerator.GenerateOneEnemy(3, true);
            King.Name = "King George";
            Queen.Name = "Queen Elisabeth";
            Enemy[] army = new Enemy[2] { King, Queen };

            const int currentLevel = 7;
            COH.PrintCombatantParty(army);

            COH.PrintStory("this is our chance only the King and Queen remain destroy them", 20);

            playerChoice();

            LevelLoop.Battle(army.ToList(), theParty);

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

                    COH.ClearScreen();
                    TakeToLevel(currentLevel + 1);
                    break;

                case 2:


                    COH.ClearScreen();
                    ChooseLevel(availableLevels);
                    break;

                default:

                    COH.ClearScreen();
                    ReturnToMainMenu();
                    break;
            }



        }

        private static void HealPlayer()
        {
            int healCost = 750;
            if (LevelLoop.gold > healCost)
            {
                int theslot = ChooseHero();
                theParty[theslot].CurrentHealth = theParty[theslot].MaxHealth;
                LevelLoop.gold -= healCost;
            }
            else
            {
                Console.WriteLine($"You do not have enought gold to heal any ally you need 750 and have {LevelLoop.gold}");
            }




        }

        private static void WhoGetsAWeapon(Person[] theParty, Weapon weapon)
        {


            COH.PrintHeroNames(theParty);

            int heroSlot = CIO.PromptForInt($"which of the heroes from slot 1 to {theParty.Length} do you want to recieve the weapon", 1, theParty.Length);

            theParty[heroSlot - 1].EquipWeapon(weapon);

        }




        public static void playerChoice()
        {


            bool isCrafting = true;
            do
            {
                Console.WriteLine("What would you like to do?");
                string[] possibleMenus = { "Skip", "Craft Weapon", "Repair Weapon", "Replace Weapon", "HealHero" };
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
                        ReplaceWeapon();
                        break;
                    case 5:
                        HealPlayer();
                        break;
                    case 6:
                        UpgradeWeapon();
                        break;
                    case 7:
                        CheckGold();
                        break;

                }
            } while (isCrafting);
        }

        private static void CheckGold()
        {
            COH.PrintStory($"{LevelLoop.gold}", 4);
        }

        private static void ReplaceWeapon()
        {

            COH.PrintStory("Which weapon would you like to equip", 7);
            List<string> weaponNames = new List<string>();
            foreach (Weapon weapon in weaponStorage)
            {
                weaponNames.Add(weapon.getName());
            }

            int selection = (CIO.PromptForMenuSelection(weaponNames, true) - 1);
            Weapon chosenWeapon = weaponStorage.ElementAt(selection);
            int heroSlot = ChooseHero();


            if (heroSlot >= 0 && heroSlot < (theParty.Length - 1))
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

        

        public static void RepairWeapon()
        {

            Weapon weaponToRepair = CIO.PromptForWeaponFromPerson("Whoes weapon would you like to Repair?", theParty);

            bool isNull = true;

            do
            {
                if (weaponToRepair == null)
                {

                    weaponToRepair = CIO.PromptForWeaponFromPerson("that hero doesn't have a weapon pick another", theParty);
                }
                else { isNull = false; }
            } while (isNull);


            bool doBuy = CIO.PromptForBool($"it will cost {weaponToRepair.getRepair()} gold\nAre you sure?\n", "Yes", "No");
            if (weaponToRepair != null && doBuy)
            {
                if (weaponToRepair.getRepair() > LevelLoop.gold)
                {
                    Console.WriteLine($"You don't have enough gold to upgrade this weapon you need {weaponToRepair.getRepair()}");
                }
                else
                {
                    weaponToRepair.repairWeapon();
                    LevelLoop.gold -= weaponToRepair.getRepair();
                }
            }

        }


        private static void MakeWeapon()
        {
            int limit = (LevelLoop.gold / 1000) + 2;

            int heroSlot = ChooseHero();
            Weapon newWeapon = Weapon.createWeapon(limit);

            if (theParty[heroSlot].heldWeapon != null)
            {
                weaponStorage.Add(theParty[heroSlot].heldWeapon);

            }

            theParty[heroSlot].EquipWeapon(newWeapon);
            Console.WriteLine("\n\n");


        }


        public static void UpgradeWeapon()
        {

            Weapon weaponToUpgrade = CIO.PromptForWeaponFromPerson("Whoes weapon would you like to upgrade?", theParty);
            bool doBuy = CIO.PromptForBool($"it will cost {weaponToUpgrade.getUpgradeCost()} gold\nAre you sure?\n", "Yes", "No");
            if (weaponToUpgrade != null && doBuy)
            {
                if (weaponToUpgrade.getUpgradeCost() > LevelLoop.gold)
                {
                    Console.WriteLine($"You don't have enough gold to upgrade this weapon you need {weaponToUpgrade.getUpgradeCost()}");
                }
                else
                {
                    weaponToUpgrade.upgradeWeapon();
                    LevelLoop.gold -= weaponToUpgrade.getUpgradeCost();
                }
            }

        }



        private static int ChooseHero()
        {

            COH.PrintHeroNames(theParty);
            int heroSlot = CIO.PromptForInt($"which hero from slot 1 to {theParty.Length} do you want to choose", 1, theParty.Length);
            return heroSlot - 1;

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
