using CSC160_ConsoleMenu;
using TheCoders.models;
using TheCoders.models.Generators;
using TheCoders.views;
using COH = TheCoders.views.ConsoleOutputHelper;

namespace TheCoders.controllers;

public class Runner
{
    public Person[] partyMembers = { new Person("Bob", 10000, 250, 250, true), new Person("Billy", 25, 3, 6, true), new Person("Joe", 50, 1, 1, true) };
    public void Run()
    {
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
                Endless.StartEndless();
                break;
            default:
                //Quit message here
                break;
        }
    }


    public void Story()
    {
        Console.WriteLine("Story");
        Storymode.main(partyMembers);
    }
}

