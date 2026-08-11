using TheCoders.models;

namespace TheCoders.views;

//Console Output Helper

public static class ConsoleOutputHelper
{
    //Print Health bar
    /// <summary>
    /// Prints a health bar made of squares corresponding to how much health a player has
    /// </summary>
    /// <param name="person"> The Person object whose health will be influencing the health bar</param>
    public static void PrintHealthBar(Person person)
    {
      
        int maxHealth = person.MaxHealth;
        int currentHealth = person.CurrentHealth;
        int numOfHealthSquares = 10;
        int numOfFilledSquares = currentHealth /  numOfHealthSquares;
        Console.WriteLine($"Health: {currentHealth} / {maxHealth}");
        Console.WriteLine($"Number of health squares: {numOfHealthSquares}");
        Console.WriteLine($"Number of filled squares: {numOfFilledSquares}");
        

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