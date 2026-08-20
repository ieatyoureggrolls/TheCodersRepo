using CSC160_ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Text;
using TheCoders.models;
using TheCoders.models.Generators;
using COH = TheCoders.views.ConsoleOutputHelper;

namespace TheCoders.controllers
{
    public static class LevelLoop
    {
        public static Person[] partyMembers;
        private static Random random = new Random();



        /// <summary>
        /// Entry point for a level, handles all level logic (generates enemies | print enemies | craft weapons | do battle stuff)
        /// </summary>
        /// <param name="level">The level to scale enemies stats around</param>
        /// <param name="enemies">Used for if you want pregenerated enemies opposed to randomly generated enemies</param>
        /// <returns>True if the heroes won | False if the enemies won</returns>
        public static bool Wave(int level, Person[] party , List<Enemy>? enemies = null)
        {
            partyMembers = party;
            Console.WriteLine($"Wave: {level}");
            if (enemies == null)
                enemies = EnemyGenerator.GenerateRangeOfEnemies(level, 2, 4).ToList();

            PrintEnemies(enemies.ToArray());

            HandleWeapons();

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
        public static void HandleWeapons(Person[] party = null)
        {
            if (party != null)
                partyMembers = party;
            Console.WriteLine("What would you like to do?");
            string[] possibleMenus = { "Craft Weapon", "Repair Weapon", "Replace Weapon", "Upgrade Weapon", "Enchant Weapon" };
            int selection = CIO.PromptForMenuSelection(possibleMenus, false);

            switch (selection)
            {
                case 1:
                    CraftWeapon();
                    break;
                case 2:
                    RepairWeapon();
                    break;
                case 3:
                    ReplaceWeapon();
                    break;
                case 4:
                    UpgradeWeapon();
                    break;
                case 5:
                    EnchantWeapon();
                    break;
            }
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
            foreach (Person person in partyMembers)
            {
                if (person.heldWeapon == null)
                    continue;
                //weapons.Add(person.heldWeapon.durability);
            }
        }

        public static void ReplaceWeapon(Person[] party = null)
        {
            if (party != null)
                partyMembers = party;

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

            do
            {
                foreach (Person person in attackOrder)
                {
                    int defenderIndex = random.Next(person.IsHero ? enemies.Count : partyMembers.Length);
                    Person defender = person.IsHero ? enemies[defenderIndex] : partyMembers[defenderIndex];

                    PersonAttacks(person, defender);
                    Console.WriteLine("\n");
                    Thread.Sleep(1000);
                }

                List<Person> alivePeople = new List<Person>();
                Console.WriteLine("\n\n---------------------------\nCurrentStandings");
                foreach (Person person in attackOrder)
                {
                    if (person.CurrentHealth > 0)
                        alivePeople.Add(person);
                }
                COH.PrintCombatantParty(alivePeople.ToArray());
                Console.WriteLine("---------------------------\n\n");
                attackOrder = alivePeople;

            } while (isBattleOver(partyMembers, enemies.ToArray()));
            return enemies.OrderByDescending(p => p.CurrentHealth).First().CurrentHealth <= 0;
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
