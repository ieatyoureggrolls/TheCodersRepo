using TheCoders.models;

namespace TheCoders.controllers;

public class Runner
{
    private Random random = new Random();
    public Person[] partyMembers = {new Person(30, 2, 4, true), new Person(25, 3, 6, true), new Person(50, 1, 1, true) };
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
        List<Person> attackOrder = people.OrderBy(p => p.speed).ToList();
        bool herosDead = false;
        bool villiansDead = false;
        do
        {
            foreach (Person person in attackOrder)
            {
                if (person.currentHealth <= 0)
                {
                    Console.WriteLine("This person is dead, but you dont know whooooooo");
                    continue;
                }
                int attackChoice;
                if (person.isHero)
                {
                    attackChoice = random.Next(villians.Count);
                    villians[attackChoice].currentHealth -= person.damage;
                    Console.WriteLine($"Hero did {person.damage} damage to the {attackChoice + 1} villian");
                }
                else if (!person.isHero)
                {
                    attackChoice = random.Next(partyMembers.Length);
                    partyMembers[attackChoice].currentHealth -= person.damage;
                    Console.WriteLine($"Villian did {person.damage} damage to the {attackChoice + 1} hero");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n\nCurrentStandings");
            foreach (Person person in attackOrder)
                Console.WriteLine($"\t{(person.isHero ? "Hero" : "Villian")}'s health: {person.currentHealth}");
            herosDead = partyMembers.OrderByDescending(p => p.currentHealth).First().currentHealth <= 0;
            villiansDead = villians.OrderByDescending(p => p.currentHealth).First().currentHealth <= 0;
        } while (!herosDead && !villiansDead);
        Console.WriteLine($"{(herosDead ? "Villians" : "Heroes")} Won!");
    }



    private List<Person> AddExperimentalPeople()
    {
        List<Person> people = new List<Person>();
        people.Add(new Person(20, 1, 1, false));
        people.Add(new Person(5, 3, 4, false));
        people.Add(new Person(10, 1, 7, false));
        people.Add(new Person(15, 2, 5, false));

        return people;
    }
}