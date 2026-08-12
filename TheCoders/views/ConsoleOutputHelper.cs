using System.Drawing;
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
    //Print battle standings
    public static void PrintBattleStanding(Person[] playerParty, Person[] enemyParty)
    {
        
    }
    //Print banner
    
    public static void PrintBanner(string message)
    {
        //Banner has different thickness or font size
        //Figure out char length of Terminal
        //Print message in the top center
        //Fill the left and right sides with -----
    }

    //Battle Summary
    
    //Print Boss health bar
    
    public static void PrintHealthBar(Enemy enemy)
    {
        //Multi-Rowed
        //Shifts through different colors
        
    }

    //PrintCrit
    public static void PrintCrit(int damage, string playerName)
    {
        
    }

    public static byte[] GenerateRGB()
    {
        Random rand = new Random();
        byte[] rgbBytes = new byte[3];
        rand.NextBytes(rgbBytes);
        byte red = rgbBytes[0];
        byte green = rgbBytes[1];
        byte blue = rgbBytes[2];
        return rgbBytes;
    }

    public static void rainbowText(string sentence)
    {
        char[] chars = sentence.ToCharArray();
        
        //Use rgb
        foreach (char c in chars )
        { 
            byte[] rgb = GenerateRGB();
            Console.BackgroundColor = Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);
        }
        
        //random generate each
        
        
    }

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