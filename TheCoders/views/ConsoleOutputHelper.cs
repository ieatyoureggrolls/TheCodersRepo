using System.Drawing;
using TheCoders.models;
using System.Linq.Expressions;
using TheCoders.extensions;
using System.Runtime.CompilerServices;

namespace TheCoders.views;

//Console Output Helper


public static class ConsoleOutputHelper
{
    public static Random rand = new Random();

    public static void Test()
    {
        Person Jeff = new Person("Jeff", 100, 10, 100, true);
        Person Jack = new Person("Jack", 100, 10, 100, true);
        Person Mort = new Person("Mort", 100, 10, 100, true);
        Person Jor = new Person("Jor", 100, 10, 100, true);
        Jeff.CurrentHealth = 77;
        Jack.CurrentHealth = 23;
        Mort.CurrentHealth = 1;
        Person[] heroParty = new Person[4] { Jeff, Jack, Mort, Jor };
        //PrintCombatantParty(heroParty);

        Enemy[] enemyParty = EnemyGenerator.GenerateEnemies(5, 4);
        Enemy boss = new Enemy("Bossy Dude", true, 100, 1, 1);
        
        Enemy[] enemyPartyTwo = new Enemy[enemyParty.Length + 1];
        for (int index = 0; index < enemyParty.Length; index++)
        {
            enemyPartyTwo[index] = enemyParty[index];
        }
        enemyPartyTwo[4] = boss;
        //PrintCombatantParty(enemyPartyTwo);
    }
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
        int numOfFilledSquares = (int)Math.Ceiling(numOfHealthSquares * (healthPercentage / 100));
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
        Console.WriteLine($" {currentHealth}/{maxHealth} ({healthPercentage}%)");
    }

    public static void PrintHealthBar(Enemy enemy)
    {
        Person person = enemy as Person;
        PrintHealthBar(person);
    }
    //Print Boss health bar

    public static void Repeat(string printMe, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            if(i == quantity -1)
            {
                Console.WriteLine(printMe);
            }
            else
            {
                Console.Write(printMe);
            }
            
        }
    }
    public static void Repeat(string printMe, int quantity, int[] rgb)
    {
        for (int i = 0;i < quantity; i++)
        {
            if(i == quantity)
            {

                Console.WriteLine($"\u001b[38;2;{rgb[0]};{rgb[1]};{rgb[2]}m{printMe}");
            }
            else
            {
                Console.Write($"\u001b[38;2;{rgb[0]};{rgb[1]};{rgb[2]}m{printMe}");
            }
            
        }
    }

    public static void PrintHealthBar(Enemy boss, bool isBoss)
    {
        string square = "\u25A0";
        double maxHealth = boss.MaxHealth;
        double currentHealth = boss.CurrentHealth;
        const int numOfLayers = 3;
        const int totalSquares = 90;
        const int totalSquaresInALayer = 30;
        const int rows = 3;
        const int numOfHealthSquaresInARow = 10;
        Console.WriteLine($"Number of layers: {numOfLayers }");
        Console.WriteLine($"Total squares: {totalSquares}");
        Console.WriteLine($"Total squares in a layer: {totalSquaresInALayer}");

        double healthPercentage = (currentHealth / maxHealth);

        int totalFilledSquares = (int)Math.Ceiling(totalSquares * healthPercentage);
        int totalEmptySquares = totalSquares - totalFilledSquares;

        Console.WriteLine($"Health percentage: {healthPercentage}");
        Console.WriteLine($"{totalFilledSquares} total filled squares");
        Console.WriteLine($"{totalEmptySquares} total empty squares");

        int filledSquaresInLayerThree = (totalFilledSquares > 60) ? totalFilledSquares - 60 : 0;
        totalFilledSquares -= filledSquaresInLayerThree;
        int filledSquaresInLayerTwo = (totalFilledSquares > 30) ? totalFilledSquares - 30 : 0;
        totalFilledSquares -= filledSquaresInLayerTwo;
        int filledSquaresInLayerOne = totalFilledSquares;
        //Total filled == 80

        //l1 green 20 filled
        //l2 yellow 30 filled
        //l3 orange 30 filled



        

        //Subtract


        Console.WriteLine($"{filledSquaresInLayerThree} filled in layer three");
        Console.WriteLine($"{filledSquaresInLayerTwo} filled in layer two");
        Console.WriteLine($"{filledSquaresInLayerOne} filled in layer one");
        
        //Console.WriteLine($"{totalEmptySquaresInLayerOne} emptied in layer one");




        
        //Console.WriteLine($"{totalEmptySquaresInLayerThree} emptied in layer three");
        


        //Green -> Yellow -> Orange -> red
        //Keep track of layers
        //Print the previos layes color in empty squares
        //3 layers of 30



        Console.ResetColor();
        }
    
            

        
        //Multi-Rowed
        //Shifts through different colors

    
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

    /// <summary>
    /// Prints a message that says how much damage someone was attacked for
    /// Each char has alternating background and foreground color
    /// </summary>
    /// <param name="damage">The amount of damage done</param>
    /// <param name="attackerName">The person who attacked</param>
    /// <param name="targetNames">A string array filled with the names of who is being attacked</param>
    public static void PrintCrit(int damage, string attackerName, string[] targetNames)
    {
        foreach (string targetName in targetNames)
        {
            rainbowText($"{attackerName} critically hit {targetName} for {damage} damage!");
        }

    }

    #region coloring

    /// <summary>
    /// Generates an int array that can be used as a rgb color
    /// </summary>
    /// <param name="oldColor"></param>
    /// <returns>An int[] that is used for rgb</returns>
    public static int[] GenerateRGB(int[] oldColor)
    {
        int numberRange = 15;
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
            if (TooSimilarShade(newColor, oldColor, numberRange))
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
        for (int index = 0; index < newColor.Length; index++)
        {
            int difference = newColor[index] - numberRange;
            if (difference > 0)
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
        int[] compareToRange = new int[numberRange * 2 + 1];

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
        for (int index = totalIndex; index < compareToRange.Length - 1; index++)
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

    /// <summary>
    /// Prints a char to terminal with the given foreground and background color
    /// Can print without and with new line
    /// </summary>
    /// <param name="character">The character to be printed</param>
    /// <param name="newLine">Is this going to have a new line at the end</param>
    /// <param name="fgColor">The foreground/fopnt color</param>
    /// <param name="bgColor">The background color</param>
    public static void PrintColoredChar(char character, bool? newLine = false, int[]? fgColor = null, int[]? bgColor = null)
    {
        //De3faults font color to white
        if (fgColor == null)
        {
            fgColor = new int[3];
            fgColor[0] = 0;
            fgColor[1] = 0;
            fgColor[2] = 0;
        }

        //Defaults Background color to black
        if (bgColor == null)
        {
            bgColor = new int[3];
            bgColor[0] = 255;
            bgColor[1] = 255;
            bgColor[2] = 255;
        }

        //Bolds/thicken character for better visibility
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

    /// <summary>
    /// Prints a bolded/thickened character
    /// </summary>
    /// <param name="c">Thje character to be bolded/thickened</param>
    /// <returns></returns>
    public static string ToBold(char c)
    {
        //Gets the unicode for the character, subtracts it from a different unicode to get the uinicode for
        //the bolden unicode for the requested char

        //Is capital
        if (c >= 'A' && c <= 'Z')
        {
            int offset = c - 'A';
            return char.ConvertFromUtf32(0x1D400 + offset);
        }
        //Is lowercase
        else if (c >= 'a' && c <= 'z')
        {
            int offset = c - 'a';
            return char.ConvertFromUtf32(0x1D41A + offset);
        }
        //Is number
        else if (c >= '0' && c <= '9')
        {
            int offset = c - '0';
            return char.ConvertFromUtf32(0x1D7CE + offset);
        }
        //No bold
        else
        {
            return c.ToString();
        }
    }

    #endregion


    /// <summary>
    /// Clears Terminal of all text
    /// </summary>
    public static void ClearScreen()
    {
        Console.Clear();
    }

    //PrintWeapons

    //Print combatant party
    /// <summary>
    /// Prints a party of Person objects, Enemy objects including Bosses
    /// </summary>
    /// <param name="party">The party of Person objects to print</param>
    public static void PrintCombatantParty(List<Person> party)
    {
        //If first array element is a hero, its the hero party, else if enemy party
        if (party[0].IsHero)
        {
            Console.WriteLine("Hero Party\n");
        }
        else
        {
            Console.WriteLine("Enemy Party\n");
        }


        foreach (Person person in party)
        {


            ///Name
            ///is a hero
            if (person.IsHero)
            {
                Console.WriteLine($"Name: {person.Name}");
            }
            else if (person != null && person is Enemy)
            {
                //is a boss
                Enemy enemy = person as Enemy;
                if (enemy.IsBoss)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write($"Boss Name: {enemy.Name}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    //Is an enemy
                    Console.WriteLine($"Name: {enemy.Name}");
                }
            }


            //Health
            if (person is Enemy)
            {
                
                Enemy enemy = (person as Enemy);
                if (enemy.IsBoss)
                {
                    //Is a boss
                    //PrintHealthBar(enemy, enemy.IsBoss);
                    PrintHealthBar(enemy);
                }
                else
                {
                    //is regular enemy
                    PrintHealthBar(person);
                }

            }
            else
            {
                //is a hero
                PrintHealthBar(person);
            }

            //Weapon Place holder
            Console.WriteLine("Weapon: {player.Weapon}");
            ///speed
            Console.WriteLine($"Speed: {person.Speed}");
            ///damage
            Console.WriteLine($"Damage: {person.Damage} \n");
        }
    }
    //Print wave information
}


