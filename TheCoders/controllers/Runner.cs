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
        Storymode.main(partyMembers);
    }

    public void Endless()
    {
        //Battle();
        Console.WriteLine("Endless");
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
        List<Person> vilians = AddExperimentalPeople();
        List<Person> people = new List<Person>();
        people.AddRange(vilians);
        people.AddRange(partyMembers);
        List<Person> attackOrder = people.OrderBy(p => p.speed).ToList();

        foreach (Person person in attackOrder)
        {
            int attackChoice;
            if (person.isHero)
            {
                attackChoice = random.Next(vilians.Count);
                vilians[attackChoice].health -= person.damage;
            }
            else if (!person.isHero)
            {
                attackChoice = random.Next(vilians.Count);
                partyMembers[attackChoice].health -= person.damage;
            }
        }
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