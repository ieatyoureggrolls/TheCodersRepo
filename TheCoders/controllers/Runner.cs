using TheCoders.models;
using TheCoders.views;

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
    /// Handles the main battle programing between the heros and the vilians
    /// </summary>
    private void Battle()
    {
        List<Person> villians = AddExperimentalPeople();
        List<Person> people = new List<Person>();
        people.AddRange(villians);
        people.AddRange(partyMembers);
        List<Person> attackOrder = people.OrderBy(p => p.Speed).ToList();
        bool herosDead = false;
        bool villiansDead = false;
        do
        {
            foreach (Person person in attackOrder)
            {
                if (person.CurrentHealth <= 0)
                {
                    Console.WriteLine($"{person.Name} is dead");
                    continue;
                }
                int damageToDeal = person.DealDamage();
                int attackChoice;
                if (person.IsHero)
                {
                    attackChoice = random.Next(villians.Count);
                    int damageDealt = villians[attackChoice].TakeDamage(damageToDeal);
                    Console.WriteLine($"{person.Name} did {damageDealt} damage to {villians[attackChoice].Name}");
                }
                else if (!person.IsHero)
                {
                    attackChoice = random.Next(partyMembers.Length);
                    int damageDealt = partyMembers[attackChoice].TakeDamage(damageToDeal);
                    Console.WriteLine($"{person.Name} did {damageDealt} damage to {partyMembers[attackChoice].Name}");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n\nCurrentStandings");
            foreach (Person person in attackOrder)
                Console.WriteLine($"\t{(person.IsHero ? "Hero" : "Villian")}'s health: {person.CurrentHealth}");

            herosDead = partyMembers.OrderByDescending(p => p.CurrentHealth).First().CurrentHealth <= 0;
            villiansDead = villians.OrderByDescending(p => p.CurrentHealth).First().CurrentHealth <= 0;
        } while (!herosDead && !villiansDead);
        Console.WriteLine($"{(herosDead ? "Villians" : "Heroes")} Won!");
    }



    private List<Person> AddExperimentalPeople()
    {
        List<Person> people = new List<Person>();
        people.Add(new Person("Villian 1", 20, 1, 1, false));
        people.Add(new Person("Villian 2", 5, 3, 4, false));
        people.Add(new Person("Villian 3", 10, 1, 7, false));
        people.Add(new Person("Villian 4", 15, 2, 5, false));

        return people;
    }
}