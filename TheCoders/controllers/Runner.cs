using CSC160_ConsoleMenu;
using TheCoders.models;
using TheCoders.views;
using COH = TheCoders.views.ConsoleOutputHelper;

namespace TheCoders.controllers;

public class Runner
{
    private Random random = new Random();
    public Person[] partyMembers = { new Person("I", 10000, 250, 250, true), new Person("Am", 25, 3, 6, true), new Person("SUFFING ALL CAPS... ALL. CAPS.", 50, 1, 1, true) };
    public void Run()
    {
        //COH.Test();
       

        
        // Entry point of the application
        ChooseMode();
    }

    /// <summary>
    /// Prompts the user if they want to play story or endless mode. Then sends them into that mode
    /// </summary>
    private void ChooseMode()
    {
        int input = CIO.PromptForMenuSelection(["Story Mode", "Endless Mode"], true);
        switch (input)
        {
            case 1:
                Story();
                break;
            case 2:
                Endless();
                break;
            default:
                //Quit message here
                break;
        }

        
        
        
        //// Entry point of the application
        //bool isStory = ChooseMode();
        //if (isStory)
        //    Story();
        //else
        //    Endless();

    }


    public void Story()
    {
        Console.WriteLine("Story");
        Storymode.main(partyMembers);
    }

    public void Endless()
    {
        int currentRound = 100;
        Console.WriteLine("Welcome To Endless");
        bool partyAlive;
        do
        {
            partyAlive = Wave(currentRound);
            currentRound++;
        } while (partyAlive);
    }


    /// <summary>
    /// Entry point for a level, handles all level logic (generates enemies | print enemies | craft weapons | do battle stuff)
    /// </summary>
    /// <param name="level">The level to scale enemies stats around</param>
    /// <param name="enemies">Used for if you want pregenerated enemies opposed to randomly generated enemies</param>
    /// <returns>True if the heroes won | False if the enemies won</returns>
    public bool Wave(int level, List<Enemy>? enemies = null)
    {
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
    private void PrintEnemies(Enemy[] enemies)
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
    public void HandleWeapons()
    {
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
                //ReplaceWeapon();
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
    private void CraftWeapon()
    {
        //Weapon craftedWeapon = new Weapon();
        Weapon craftedWeapon = Weapon.createWeapon();
        string[] partyNames = new string[partyMembers.Length];
        for (int i = 0; i < partyMembers.Length; i++)
            partyNames[i] = partyMembers[i].Name;

        Console.WriteLine("Who would you like to use the weapon:");
        int personToUse = CIO.PromptForMenuSelection(partyNames, false) -1;
        partyMembers[personToUse].EquipWeapon(craftedWeapon);
    }

    private void RepairWeapon()
    {
        List<string> weapons = new List<string>();
        foreach (Person person in partyMembers)
        {
            if (person.heldWeapon == null)
                continue;
            //weapons.Add(person.heldWeapon.durability);
        }
    }

    //private void ReplaceWeapon()
    //{

    //}

    private void UpgradeWeapon()
    {

    }

    private void EnchantWeapon()
    {

    }
    #endregion

    /// <summary>
    /// Has heroes battle enemies in a loop
    /// </summary>
    /// <param name="enemies">The list of eneimes the party will be fighting</param>
    /// <returns>True if the heroes won | False if the enemies won</returns>
    public bool Battle(List<Enemy> enemies)
    {
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
                COH.PrintHealthBar(person);
                Console.WriteLine();
                if (person.CurrentHealth > 0)
                    alivePeople.Add(person);
            }
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
    private static void PersonAttacks(Person attacker, Person defender)
    {
        int[] attackResult = attacker.DealDamage();
        int damageDealt = defender.TakeDamage(attackResult[0]);
        if (attackResult[1] > 0)
            COH.PrintCrit(attackResult[0], attacker.Name, new string[]{defender.Name});
        else
            Console.WriteLine($"{attacker.Name} did {damageDealt} damage to {defender.Name}\n\n");
    }

    /// <summary>
    /// Checks to see if either side of the fight is dead
    /// </summary>
    /// <param name="heroes">Array of heroes to check their state</param>
    /// <param name="enemies">Array of enemies to check their state</param>
    /// <returns>True if the heroes or enemies are dead</returns>
    private static bool isBattleOver(Person[] heroes, Enemy[] enemies)
    {
        bool herosDead = heroes.OrderByDescending(p => p.CurrentHealth).First().CurrentHealth <= 0;
        bool enemiesDead = enemies.OrderByDescending(p => p.CurrentHealth).First().CurrentHealth <= 0;
        return !herosDead && !enemiesDead;
    }
}

