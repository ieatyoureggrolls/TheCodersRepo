using TheCoders.models;
using TheCoders.models.Generators;
using TheCoders.views;
using COH = TheCoders.views.ConsoleOutputHelper;

namespace TheCoders.controllers;

public class Runner
{
    
    public void Run()
    {
        Console.ResetColor();
        Console.WriteLine("PRESS ENTER IF YOU ARE IN FULLSCREEN");
        Console.ReadLine();
        COH.ClearScreen();

        //COH.Test();
        ChooseMode();

    }

    /// <summary>
    /// Prompts the user if they want to play story or endless mode. Then sends them into that mode
    /// </summary>
    private void ChooseMode()
    {
        //int input = CIO.PromptForMenuSelectionInBox(["Story Mode", "Endless Mode"], true,true);
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
        Storymode.main();
    }
}

