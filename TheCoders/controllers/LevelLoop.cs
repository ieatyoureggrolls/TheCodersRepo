using System.Collections.Generic;
using System.Text;
using TheCoders.models;
using TheCoders.models.Generators;
using TheCoders.views;
using COH = TheCoders.views.ConsoleOutputHelper;

namespace TheCoders.controllers
{
    public static class LevelLoop
    {
        public static int gold;
        public static Person[] partyMembers;
        private static Random random = new Random();



        /// <summary>
        /// Entry point for a level, handles all level logic (generates enemies | print enemies | craft weapons | do battle stuff)
        /// </summary>
        /// <param name="level">The level to scale enemies stats around</param>
        /// <param name="enemies">Used for if you want pregenerated enemies opposed to randomly generated enemies</param>
        /// <returns>True if the heroes won | False if the enemies won</returns>
        public static bool Wave(int level, Person[] party, List<Weapon> weaponStorage, List<Enemy>? enemies = null)
        {
            partyMembers = party;
            if (enemies == null)
                enemies = EnemyGenerator.GenerateRangeOfEnemies(level, 2, 4).ToList();

            COH.PrintWaveInfo(level, enemies);

            HandleWeapons(weaponStorage);

            bool partySurvives = Battle(enemies);
            return partySurvives;
        }

        /// <summary>
        /// Prints out the info of all enemies you will be fighting this wave
        /// </summary>
        public static void PrintEnemies(Enemy[] enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                Console.WriteLine(enemy);
            }
        }


        #region Weaopn Stuff
        /// <summary>
        /// Controls the crafting weapon stage of the game
        /// </summary>
        public static void HandleWeapons(List<Weapon> weaponStorage, Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            bool isCrafting = true;
            do
            {
                Console.WriteLine($"What would you like to do?\nGold: {gold}");
                string[] possibleMenus = { "Skip", "Craft Weapon", "Repair Weapon", "Replace Weapon", "Upgrade Weapon" };
                int selection = CIO.PromptForMenuSelection(possibleMenus, false);

                switch (selection)
                {
                    case 1:
                        isCrafting = false;
                        break;
                    case 2:
                        CraftWeapon();
                        break;
                    case 3:
                        RepairWeapon();
                        break;
                    case 4:
                        ReplaceWeapon(weaponStorage);
                        break;
                    case 5:
                        UpgradeWeapon();
                        break;
                }
            } while (isCrafting);
        }

        /// <summary>
        /// Makes the user craft a weapon, then they choose who to give the weapon to
        /// </summary>
        public static void CraftWeapon(Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            Weapon craftedWeapon = Weapon.createWeapon();
            string[] partyNames = new string[partyMembers.Length];
            for (int i = 0; i < partyMembers.Length; i++)
                partyNames[i] = partyMembers[i].Name;

            Console.WriteLine("Who would you like to use the weapon:");
            int personToUse = CIO.PromptForMenuSelection(partyNames, false) - 1;
            partyMembers[personToUse].EquipWeapon(craftedWeapon);
        }

        public static void RepairWeapon(Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            Weapon weaponToRepair = CIO.PromptForWeaponFromPerson("Whoes weapon would you like to repair?", partyMembers);
            bool doBuy = CIO.PromptForBool($"it will cost {weaponToRepair.getRepair()} gold\nAre you sure?\n", "Yes", "No");
            if (weaponToRepair != null && doBuy)
            {
                if (weaponToRepair.getRepair() > gold)
                {
                    Console.WriteLine("You don't have enough to repair this weapon...(getajobwhydontyaorelseyouwillendupbrokehoweveryoudohavethisjobsoiguessyouaretryingyourbest)");
                }
                else
                {
                    weaponToRepair.repairWeapon();
                    gold -= weaponToRepair.getRepair();
                }
            }

        }

        public static void ReplaceWeapon(List<Weapon> weaponInventory, Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            Person personToSwitch = CIO.PromptForPersonWithWeapon("Whose weapon would you like to replace?", partyMembers);
            Weapon weaponToEquip = CIO.PromptForWeapon("Which weapon would you like them to start using?", weaponInventory.ToArray());

            Weapon weaponToStorage = personToSwitch.heldWeapon;
            weaponInventory.Remove(weaponToEquip);
            if (weaponToStorage != null)
                weaponInventory.Add(weaponToStorage);
        }

        public static void UpgradeWeapon(Person[] party = null)
        {
            if (party != null)
                partyMembers = party;

            Weapon weaponToUpgrade = CIO.PromptForWeaponFromPerson("Whoes weapon would you like to upgrade?", partyMembers);
            bool doBuy = CIO.PromptForBool($"it will cost {weaponToUpgrade.getUpgradeCost()} gold\nAre you sure?\n", "Yes", "No");
            if (weaponToUpgrade != null && doBuy)
            {
                if (weaponToUpgrade.getUpgradeCost() > gold)
                {
                    Console.WriteLine("You don't have enough to upgrade this weapon...(getajobwhydontyaorelseyouwillendupbrokehoweveryoudohavethisjobsoiguessyouaretryingyourbest)");
                }
                else
                {  
                    weaponToUpgrade.upgradeWeapon();
                    gold -= weaponToUpgrade.getUpgradeCost();
                }
            }

        }
        #endregion

        /// <summary>
        /// Has heroes battle enemies in a loop
        /// </summary>
        /// <param name="enemies">The list of eneimes the party will be fighting</param>
        /// <returns>True if the heroes won | False if the enemies won</returns>
        public static bool Battle(List<Enemy> enemies, Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            List<Person> people = new List<Person>();
            people.AddRange(enemies);
            people.AddRange(partyMembers);
            List<Person> attackOrder = people.OrderByDescending(p => p.Speed).ToList();
            int round = 1;

            do
            {
                List<Person> alivePeople = new List<Person>();
                List<Person> aliveHeroes = new List<Person>();
                List<Enemy> aliveEnemies = new List<Enemy>();
                foreach (Person person in attackOrder)
                {
                    if (person.CurrentHealth > 0)
                    {
                        alivePeople.Add(person);
                        if (person.IsHero)
                            aliveHeroes.Add(person);
                        else
                            aliveEnemies.Add((Enemy)person);
                    }
                }
                COH.PrintBattleStanding(aliveHeroes, aliveEnemies);
                //CIO.PromptForInput("Press enter to continue", true);
                attackOrder = alivePeople;

                foreach (Person person in attackOrder)
                {
                    if (person.CurrentHealth == 0)
                        continue;
                    int defenderIndex = random.Next(person.IsHero ? aliveEnemies.Count : aliveHeroes.Count);
                    Person defender = person.IsHero ? aliveEnemies[defenderIndex] : aliveHeroes[defenderIndex];

                    string[] attackMessage = PersonAttacks(person, defender);
                    COH.PrintDamage(attackMessage, !person.IsHero);
                    Thread.Sleep(50);
                }

                round++;
            } while (isBattleOver(partyMembers, enemies.ToArray()));

            int totalGold = 0;
            foreach (Enemy enemy in enemies)
                totalGold += enemy.gold;

            bool battleWon = enemies.OrderByDescending(p => p.CurrentHealth).First().CurrentHealth <= 0;
            COH.PrintBattleSummary(partyMembers, enemies, battleWon, new List<Pieces.Material>(), totalGold);
            gold += totalGold;
            return battleWon;
        }

        /// <summary>
        /// Makes one person attack another for one instance of damage
        /// </summary>
        /// <param name="attacker">The person doing damage</param>
        /// <param name="defender">The person taking damage</param>
        /// <returns>String array where index 0 is the message and index 1 is if it is a crit</returns>
        public static string[] PersonAttacks(Person attacker, Person defender, Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            int[] attackResult = attacker.DealDamage();
            int damageDealt = defender.TakeDamage(attackResult[0]);
            string sanitizedAttackerName = attacker.Name.Replace(" ", "\u00A0");
            string sanitizedDefenderName = defender.Name.Replace(" ", "\u00A0");
            return new string[] { $"{sanitizedAttackerName} did {damageDealt} damage to {sanitizedDefenderName}\n\n", (attackResult[1] > 0 ? "true" : "false") };
        }

        /// <summary>
        /// Checks to see if either side of the fight is dead
        /// </summary>
        /// <param name="heroes">Array of heroes to check their state</param>
        /// <param name="enemies">Array of enemies to check their state</param>
        /// <returns>True if the heroes or enemies are dead</returns>
        public static bool isBattleOver(Person[] heroes, Enemy[] enemies, Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            bool herosDead = heroes.OrderByDescending(p => p.CurrentHealth).First().CurrentHealth <= 0;
            bool enemiesDead = enemies.OrderByDescending(p => p.CurrentHealth).First().CurrentHealth <= 0;
            return !herosDead && !enemiesDead;
        }
    }
}
