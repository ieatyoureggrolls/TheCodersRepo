using System.Drawing;
using TheCoders.models;
using System.Linq.Expressions;
using TheCoders.extensions;

namespace TheCoders.views;

//Console Output Helper


public static class ConsoleOutputHelper
{
    public static Random rand = new Random();
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
    //Print Boss health bar

    public static void PrintHealthBar(Enemy enemy)
    {
        string square = "\u25A0";
        double maxHealth = enemy.MaxHealth;
        double currentHealth = enemy.CurrentHealth;

        double healthPercentage = currentHealth / maxHealth * 100;
        int numOfHealthSquares = 10;
        int numOfFilledSquares = (int)Math.Round(numOfHealthSquares * (healthPercentage / 100));
        int numOfEmptySquares = numOfHealthSquares - numOfFilledSquares;

        int rows = 3;
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
        //Multi-Rowed
        //Shifts through different colors

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



    //PrintCrit
    public static void PrintCrit(int damage, string playerName)
    {

    }




    public static int[] GenerateRGB(int[]? oldColor)
    {
        int[] newColor;
        do
        {
            newColor = [rand.Next(256), rand.Next(256), rand.Next(256)];
        }
        while (oldColor != null && newColor.EqualTo(oldColor));

        return newColor;
    }

    //public static bool isTooClose(int numberRange, int numToCompare, int numToCompareAgainst)
    //{
        
    //    int[] range = new int[numberRange];

    //    int[] compareToRange = new int[numberRange * 2+1];

    //    int totalIndex = 0;
        
    //    //slap this dumb number being compared against in the middle of the array
    //    compareToRange[compareToRange.Length - 1 / 2] = numToCompareAgainst;
        
    //    for (int index = 1; index < numberRange; index++)
    //    {
    //        range[index] = index;
    //    }

    //    //Fill the lower half of array with numbers in range of numberRange less than numToCompareAgainst
    //    for (int index = 0; index < compareToRange.Length - 1 / 2; index++)
    //    {
    //        int rangeInt = numberRange;
    //        compareToRange[index] = numToCompareAgainst - rangeInt;
    //        rangeInt--;
    //    }

    //    //Fill the upper half of array with numbers in range of numberRange more than numToCompareAgainst
        
    //    for (int index = ; index < compareToRange.Length - 1 / 2; index++)
    //    {
    //        int rangeInt = numberRange;
    //        compareToRange[index] = numToCompareAgainst - rangeInt;
    //        rangeInt--;
    //    }

    //}

    //public static bool TooSimilarShade(int[] colorOne, int[] colorTwo)
    //{


    //    bool tooSimilar = false;
    //    for (int index = 0; index < colorOne.Length; index++)
    //    {
    //        if (colorOne[index] == colorTwo[index])
    //    }
    //}

    public static void rainbowText(string sentence)
    {
        char[] chars = sentence.ToCharArray();


        int[]? oldColor = null;
        int[] bgColor = new int[3];
        int[] fgColor = new int[3];

        //Use rgb
        for (int index = 0; index < chars.Length; index++)
        {
            bgColor = GenerateRGB(oldColor);
            oldColor = bgColor;

            fgColor = GenerateRGB(oldColor);
            oldColor = fgColor;

            if (index == chars.Length - 1)
            {
                PrintColoredChar(chars[index], true, fgColor, bgColor);
            }
            else
            {
                PrintColoredChar(chars[index], false, fgColor, bgColor);
            }
        }
    }

    //print colored sentence
    public static void PrintColoredChar(char character, bool newLine = false, int[]? fgColor = null, int[]? bgColor = null)
    {
        if (fgColor == null)
        {
            fgColor = new int[3];
            fgColor[0] = 0;
            fgColor[1] = 0;
            fgColor[2] = 0;
        }
        if (bgColor == null)
        {
            bgColor = new int[3];
            bgColor[0] = 255;
            bgColor[1] = 255;
            bgColor[2] = 255;
        }

        if (newLine == false || newLine == null)
        {
            Console.Write($"\x1b[38;2;{fgColor[0]};{fgColor[1]};{fgColor[2]}m\x1b[48;2;{bgColor[0]};{bgColor[1]};{bgColor[2]}m{character}\x1b[0m");
        }
        else
        {
            Console.WriteLine($"\x1b[38;2;{fgColor[0]};{fgColor[1]};{fgColor[2]}m\x1b[48;2;{bgColor[0]};{bgColor[1]};{bgColor[2]}m{character}\x1b[0m");
        }

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

