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
            Console.WriteLine($"Wave: {level}");
            if (enemies == null)
                enemies = EnemyGenerator.GenerateRangeOfEnemies(level, 2, 4).ToList();

            PrintEnemies(enemies.ToArray());

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
                Console.WriteLine("What would you like to do?");
                string[] possibleMenus = { "Skip", "Craft Weapon", "Repair Weapon", "Replace Weapon", "Upgrade Weapon", "Enchant Weapon" };
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
                    case 6:
                        EnchantWeapon();
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
            //Weapon craftedWeapon = new Weapon();
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
            List<string> weapons = new List<string>();
            Console.WriteLine("Whoes weapon would you like to repair?");
            for (int i = 0; i < partyMembers.Length; i++)
            {
                if (partyMembers[i].heldWeapon == null)
                    continue;
                Console.WriteLine($"{i + 1}. {partyMembers[i].Name} - Weapon:");
                partyMembers[i].heldWeapon.displayWeaponInfo();
            }
            int weaponToRepair = CIO.PromptForInt("", 1, partyMembers.Length) - 1;
            partyMembers[weaponToRepair].heldWeapon.repairWeapon();
        }

        public static void ReplaceWeapon(List<Weapon> weaponInventory, Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            Console.WriteLine("Whoes weapon would you like to replace?");
            for (int i = 0; i < partyMembers.Length; i++)
            {
                if (partyMembers[i].heldWeapon == null)
                    continue;
                Console.WriteLine($"{i + 1}. {partyMembers[i].Name} - Weapon:");
                partyMembers[i].heldWeapon.displayWeaponInfo();
            }
            int weaponToReplace = CIO.PromptForInt("", 1, partyMembers.Length) - 1;

            Console.WriteLine("Which weapon would you like them to start using?");
            for (int i = 0; i < weaponInventory.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                weaponInventory[i].displayWeaponInfo();
            }
            int weaponReplacing = CIO.PromptForInt("", 1, weaponInventory.Count) - 1;
            Weapon weaponToStorage = partyMembers[weaponToReplace].heldWeapon;
            partyMembers[weaponToReplace].EquipWeapon(weaponInventory[weaponReplacing]);
            weaponInventory.RemoveAt(weaponToReplace);
            weaponInventory.Add(weaponToStorage);
        }

        public static void UpgradeWeapon(Person[] party = null)
        {
            if (party != null)
                partyMembers = party;

        }

        public static void EnchantWeapon(Person[] party = null)
        {
            if (party != null)
                partyMembers = party;

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
                        alivePeople.Add(person);
                    if (person.IsHero)
                        aliveHeroes.Add(person);
                    else
                        aliveEnemies.Add((Enemy)person);
                }
                COH.PrintBattleStanding(aliveHeroes, aliveEnemies);
                CIO.PromptForInput("Press enter to continue", true);
                attackOrder = alivePeople;

                foreach (Person person in attackOrder)
                {
                    int defenderIndex = random.Next(person.IsHero ? aliveEnemies.Count : aliveHeroes.Count);
                    Person defender = person.IsHero ? aliveEnemies[defenderIndex] : aliveHeroes[defenderIndex];

                    PersonAttacks(person, defender);
                    Console.WriteLine("\n");
                    //Thread.Sleep(300);
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
        public static void PersonAttacks(Person attacker, Person defender, Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            int[] attackResult = attacker.DealDamage();
            int damageDealt = defender.TakeDamage(attackResult[0]);
            if (attackResult[1] > 0)
                COH.PrintCrit(attackResult[0], attacker.Name, new string[] { defender.Name });
            else
                Console.WriteLine($"{attacker.Name} did {damageDealt} damage to {defender.Name}\n\n");
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
