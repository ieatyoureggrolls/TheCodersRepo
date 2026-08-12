using TheCoders.models;
using TheCoders.views;
using COH = TheCoders.views.ConsoleOutputHelper;

namespace TheCoders.controllers;

public class Runner
{
    private Random random = new Random();
    public Person[] partyMembers = {new Person("Hero 1", 30, 2, 4, true), new Person("Hero 2", 25, 3, 6, true), new Person("Hero 3", 50, 1, 1, true) };
    public void Run()
    {
        
        // Entry point of the application
        bool isStory = ChooseMode();
        if (isStory)
            Story();
        else
            Endless();
    }

    

    public void Story()
    {
        Console.WriteLine("Story");
        Storymode.main(partyMembers);
    }

    public void Endless()
    {
        Console.WriteLine("Endless");
        Battle();
    }

    /// <summary>
    /// Prompts the user if they want to play story or endless mode
    /// </summary>
    /// <returns>True for story | False for endless</returns>
    private bool ChooseMode()
    {
        Console.WriteLine("Story mode: S\nEndless mode: E");
        string input = Console.ReadLine().ToUpper();
        return input == "S";
    }

    /// <summary>
    /// Has heroes battle enemies in a loop
    /// </summary>
    /// <param name="enemies">Used for pregenerated enemies</param>
    private void Battle(List<Enemy>? enemies = null)
    {
        if (enemies == null)
            enemies = AddExperimentalPeople();
        List<Person> people = new List<Person>();
        people.AddRange(enemies);
        people.AddRange(partyMembers);
        List<Person> attackOrder = people.OrderBy(p => p.Speed).ToList();

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

            Console.WriteLine("\n\n---------------------------\nCurrentStandings");
            foreach (Person person in attackOrder)
            {
                COH.PrintHealthBar(person);
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------\n\n");

        } while (isBattleOver(partyMembers, enemies.ToArray()));
    }

    /// <summary>
    /// Makes one person attack another for one instance of damage
    /// </summary>
    /// <param name="attacker">The person doing damage</param>
    /// <param name="defender">The person taking damage</param>
    private static void PersonAttacks(Person attacker, Person defender)
    {
        int damageToDeal = attacker.DealDamage();
        int damageDealt = defender.TakeDamage(damageToDeal);
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



    private List<Enemy> AddExperimentalPeople()
    {
        List<Enemy> enemies = EnemyGenerator.GenerateEnemies(0, 4).ToList();
        return enemies;
    }
}