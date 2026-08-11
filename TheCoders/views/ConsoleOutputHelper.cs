using TheCoders.models;

namespace TheCoders.views;

//Console Output Helper

public static class ConsoleOutputHelper
{
    /// <summary>
    /// Prints a health bar made of squares corresponding to how much health a player has
    /// </summary>
    /// <param name="person"> The Person object whose health will be influencing the health bar</param>
    public static void PrintHealthBar(Person person)
    {
        //Value errors are handled in Person setters

        string square = "\u25A0";
        double maxHealth = person.MaxHealth;
        double currentHealth = person.CurrentHealth;

        int numOfHealthSquares = 10;

        //Gets health percentage, then uses it to calculate how many filled and empty squares
        double healthPercentage = currentHealth / maxHealth * 100;
        int numOfFilledSquares = (int)Math.Round(numOfHealthSquares * (healthPercentage / 100));
        int numOfEmptySquares = numOfHealthSquares - numOfFilledSquares;

        for (int i = 0; i < numOfFilledSquares; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(square);
            Console.ResetColor();
        }

        for (int i = 0; i < numOfEmptySquares; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(square);
            Console.ResetColor();
        }
    }

    //Battle Summary

    //PrintCrit

    /// <summary>
    /// Clears Terminal of all text
    /// </summary>
    public static void ClearScreen()
    {
        Console.Clear();
    }

    //PrintWeapons

    //Print combatant party

    //Print wave information
}