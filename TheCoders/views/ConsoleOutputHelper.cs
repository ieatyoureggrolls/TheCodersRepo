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
    /// <summary>
    /// Prints a message that says how much damage someone was attacked for
    /// Each char has alternating background and foreground color
    /// </summary>
    /// <param name="damage">The amount of damage done</param>
    /// <param name="attackerName">The person who attacked</param>
    /// <param name="targetNames">A string array filled with the names of who is being attacked</param>
    public static void PrintCrit(int damage, string attackerName, string[] targetNames)
    {
        foreach(string targetName in targetNames)
        {
            rainbowText($"{attackerName} critically hit {targetName} for {damage} damage!");
        }
        
    }



    /// <summary>
    /// Generates an int array that can be used as a rgb color
    /// </summary>
    /// <param name="oldColor"></param>
    /// <returns>An int[] that is used for rgb</returns>
    public static int[] GenerateRGB(int[] oldColor)
    {
        int numberRange = 25;
        int[] newColor;
        int[] black = new int[3];
        black = [0, 0, 0];
        int[] white = new int[3];
        white = [255, 255, 255];
        do
        {
            //Pre comparison rgb color
            newColor = [rand.Next(256), rand.Next(256), rand.Next(256)];

            //Checks if newColor is within numberRange of oldColor
            if(TooSimilarShade(newColor, oldColor, numberRange))
            {
                //Changes existing rgb as opposed to generating a new one, which
                //has a smallpossibilty of an infinite loop
                newColor = ShuffleRgb(newColor, numberRange);
            }
        }
        //Makes sure colors are not the same, white, black, or null
        while (oldColor != null && newColor.EqualTo(oldColor) && !(newColor.EqualTo(black) && newColor.EqualTo(white)));

        return newColor;
    }

    /// <summary>
    /// Subracts a fixed value from each rgb color, in order of making it darker
    /// </summary>
    /// <param name="newColor">The RGB color being modified</param>
    /// <param name="numberRange">The number used to modify the RGBV</param>
    /// <returns>A RGB value that is NumberRange smaller</returns>
    public static int[] ShuffleRgb(int[] newColor, int numberRange)
    {
        for(int index = 0; index < newColor.Length; index++)
        {
            int difference = newColor[index] - numberRange;
            if ( difference > 0)
            {
            
                newColor[index] = difference;
            }
            //Makes negative overflow wrap around and decrease from 255
            else
            {
                newColor[index] = 255 - (difference *= -1);
            }
        }
        return newColor;
    }
    /// <summary>
    /// Checks if a numer is a within a range more or less than a second number
    /// </summary>
    /// <param name="numberRange">The range more and less of numToCompareAgainst</param>
    /// <param name="numToCompare">The number being compared</param>
    /// <param name="numToCompareAgainst">The number being compared against</param>
    /// <returns></returns>
    public static bool IsTooClose(int numberRange, int numToCompare, int numToCompareAgainst)
    {
        /**
         * Creates an array to store all numbers in range of a given number less than, more 
         * than the number being compared against as well as the number itself
        **/
        int[] range = new int[numberRange];
        int[] compareToRange = new int[numberRange * 2+1];

        //put the number being compared against in the middle of the array
        int middleIndex = compareToRange.Length / 2 - 1;
        compareToRange[middleIndex] = numToCompareAgainst;

        //Shared index between for loops. This prevents an ugly for loop 
        int totalIndex = 0;

        //Populate an array with all numbers between numberRange and 0 (inclusive)
        for (int index = totalIndex; index < numberRange + 1; index++)
        {
            totalIndex = index;
            compareToRange[index] = numToCompareAgainst - index;
            
        }
        //Add this number to numToCompareAgainst
        int rangeCounter = numberRange;

        /**
         * Fill the lower half of array with numbers in range 
         * of numberRange less than numToCompareAgainst by 
         * adding rangeCounter to numToCompareAgainst then decreasing
         * range counter. Repeat untill rangeCounter is zero
        **/
        for (int index = totalIndex; index < compareToRange.Length - 1 ; index++)
        {
            
            compareToRange[index] = numToCompareAgainst + rangeCounter;
            rangeCounter--;
        }


        //Resets rangeInt back to numberRange to start comparison
        rangeCounter = numberRange;

        /**
         * Fill the upper half of array with numbers in range of 
         * numberRange more than numToCompareAgainst by adding 
         * rangeCounter to numToCompareAgainst then decrement rangeCounter
         * Repeat untill rangeCounter = 0
         **/
        for (int index = totalIndex; index < compareToRange.Length - 1 / 2; index++)
        {
            
            compareToRange[index] = numToCompareAgainst - rangeCounter;
            rangeCounter--;
        }

        //checks if numToCompare is in compareToRange atleast once
        return numToCompare.IsIn(compareToRange);

    }

    /// <summary>
    /// Checks if any of part of an rgb color is a certain range more or less than the second color
    /// </summary>
    /// <param name="colorOne">RGB color being compared</param>
    /// <param name="colorTwo">RGB color beinmg compared to</param>
    /// <param name="numberRange"></param>
    /// <returns>If an rgb color is with range of the other rgb color</returns>
    public static bool TooSimilarShade(int[] colorOne, int[] colorTwo, int numberRange)
    {
        bool isTooSimilar = false;

        for (int index = 0; index < colorOne.Length; index++)
        {
            for (int indexTwo = 0; indexTwo < colorTwo.Length; indexTwo++)
                if (IsTooClose(numberRange, colorOne[index], colorTwo[indexTwo]))
                {
                    isTooSimilar = true;
                }
        }
        return isTooSimilar;
    }
    /// <summary>
    /// Takes in a sentence, then prints each character with alternating Background and Foreground color
    /// </summary>
    /// <param name="sentence">The sentence to be colorfully printed</param>
    public static void rainbowText(string sentence)
    {
        //Breaks string into chars for easy customization
        char[] chars = sentence.ToCharArray();

        //Defaults to White in rgb
        int[] oldColor = new int[3];
        oldColor = [255, 255, 255];

        //Each array is a rgb color
        int[] bgColor = new int[3];
        int[] fgColor = new int[3];

        
        for (int index = 0; index < chars.Length; index++)
        {
            //If char is a space, don't color it
            if (chars[index] == ' ')
            {
                Console.Write(' ');
                continue;
            }
            //Generates Background color
            bgColor = GenerateRGB(oldColor);
            oldColor = bgColor;

            //Generates Foreground color
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
    public static void PrintColoredChar(char character, bool? newLine = false, int[]? fgColor = null, int[]? bgColor = null)
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
        string boldedC = ToBold(character);

        if (newLine == false || newLine == null)
        {
            
            Console.Write($"\x1b[38;2;{fgColor[0]};{fgColor[1]};{fgColor[2]}m\x1b[48;2;{bgColor[0]};{bgColor[1]};{bgColor[2]}m{boldedC}\x1b[0m");

        }
        else
        {
            Console.WriteLine($"\x1b[38;2;{fgColor[0]};{fgColor[1]};{fgColor[2]}m\x1b[48;2;{bgColor[0]};{bgColor[1]};{bgColor[2]}m{boldedC}\x1b[0m");
        }

    }

    //Bold
    public static string ToBold(char c)
    {
        if (c >= 'A' && c <= 'Z')
        {
            int offset = c - 'A';
            return char.ConvertFromUtf32(0x1D400 + offset);
        }
        else if (c >= 'a' && c <= 'z')
        {
            int offset = c - 'a';
            return char.ConvertFromUtf32(0x1D41A + offset);
        }
        else if (c >= '0' && c <= '9')
        {
            int offset = c - '0';
            return char.ConvertFromUtf32(0x1D7CE + offset);
        }
        else
        {
            return c.ToString();
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

