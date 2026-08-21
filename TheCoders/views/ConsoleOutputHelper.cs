using System.Drawing;
using TheCoders.models;
using System.Linq.Expressions;
using TheCoders.extensions;
using System.Runtime.CompilerServices;

namespace TheCoders.views;

//Console Output Helper

//Pause inbetween dialogs
//Delay text method
//Make sure methods are broken up into small methods
//Make sure methods are documented with XML comments
//Add menu design
//Print name of hero and slot
//Possible cursor animation


public static class ConsoleOutputHelper
{
    public static Random rand = new Random();

    public static void Test()
    {
        List<Person> heroParty = new List<Person>
        {
            new Person("Hero1", 100, 10, 5, true),
            new Person("Hero2", 80, 12, 6, true),
    }

    public static void PrintHeroNames(IReadOnlyList<Person> heroParty)
    {
        Console.WriteLine("Hero Party\n");
        for (int i = 0; i < heroParty.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {heroParty[i].Name}");
        }
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


    /// <summary>
    /// Prints a string a certain number of times, with a new line at the end
    /// </summary>
    /// <param name="printMe">The string to print</param>
    /// <param name="quantity">The number of times to print the string</param>
    public static void Repeat(string printMe, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            if (i == quantity - 1)
            {
                Console.WriteLine(printMe);
            }
            else
            {
                Console.Write(printMe);
            }

        }
    }
    /// <summary>
    /// Prints a string a certain number of times, with a new line at the end, in a specific rgb color
    /// </summary>
    /// <param name="printMe">The string to print</param>
    /// <param name="quantity">The number of times to print the string</param>
    /// <param name="rgb">The rgb color to use</param>
    public static void Repeat(string printMe, int quantity, int[] rgb)
    {
        for (int i = 0; i < quantity; i++)
        {
            if (i == quantity)
            {

                Console.WriteLine($"\u001b[38;2;{rgb[0]};{rgb[1]};{rgb[2]}m{printMe}");
            }
            else
            {
                Console.Write($"\u001b[38;2;{rgb[0]};{rgb[1]};{rgb[2]}m{printMe}");
            }

        }
    }

    /// <summary>
    /// Checks which layer the healthbar is currently in, then returns the current layer
    /// </summary>
    /// <param name="totalFilledSquares">The total number of filled squares in the healthbar</param>
    /// <param name="totalEmptySquaresInLayerThree">The total number of empty squares in layer three</param>
    /// <param name="totalEmptySquaresInLayerTwo">The total number of empty squares in layer two</param>
    /// <param name="totalEmptySquaresInLayerOne">The total number of empty squares in layer one</param>
    /// <returns>The current layer</returns>
    public static int LayerCheck(int totalFilledSquares, int totalEmptySquaresInLayerThree, int totalEmptySquaresInLayerTwo, int totalEmptySquaresInLayerOne)
    {
        if (totalFilledSquares >= 60)
        {
            return 3;
        }
        else if (totalFilledSquares > 30 && totalFilledSquares < 60)
        {
            return 2;
        }
        else if (totalFilledSquares <= 30)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Prints a layer of the healthbar, with empty squares printed first, then filled squares printed
    /// </summary>
    /// <param name="currentLayer">The current layer to print</param>
    /// <param name="totalEmptySquares">The total number of empty squares in the layer</param>
    /// <param name="totalFilledSquares">The total number of filled squares in the layer</param>
    /// <param name="square">The character to use for the squares</param>
    public static void PrintLayer(int currentLayer, int totalEmptySquares, int totalFilledSquares, string square)
    {
        //Keeps track of how many squares have been printed
        int layerTracker = 1;

        //Sets the color of the empty squares based on the current layer
        if (currentLayer == 3)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (currentLayer == 2)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else if (currentLayer == 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }

        //Prints the empty squares, with a new line after every 10 squares
        for (int i = 0; i < totalEmptySquares; i++)
        {
            if (layerTracker % 10 == 0)
            {
                Console.WriteLine(square);
            }
            else
            {
                Console.Write(square);
            }

            layerTracker++;
        }

        //Resets the color of the console to default
        Console.ResetColor();

        //Sets the color of the filled squares based on the current layer
        if (currentLayer == 3)
        {
            Console.ForegroundColor = ConsoleColor.Green;

        }
        else if (currentLayer == 2)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (currentLayer == 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        //Prints the filled squares, with a new line after every 10 squares
        for (int i = 0; i < totalFilledSquares; i++)
        {
            if (layerTracker % 10 == 0)
            {
                Console.WriteLine(square);
            }
            else
            {
                Console.Write(square);
            }

            layerTracker++;
        }
        Console.ResetColor();
    }

    /// <summary>
    /// Prints an Emeny Bosses multi-layered healthbar
    /// </summary>
    /// <param name="boss">The Enemy Boss whose healthbar is being printed</param>
    /// <param name="isBoss">If the Enemy is a boss</param>
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

        double healthPercentage = (currentHealth / maxHealth);

        int totalFilledSquares = (int)Math.Ceiling(totalSquares * healthPercentage);
        int totalEmptySquares = totalSquares - totalFilledSquares;
        int remainingFilledSquares = totalFilledSquares;
        int remainingEmptySquares = totalEmptySquares;

        //Individually calculates the amount of squares filled and empty per layer
        //This is very un-optimized, but it works. Will optimize if given the time.

        int filledSquaresInLayerThree = (totalFilledSquares > 60) ? totalFilledSquares - 60 : 0;
        remainingFilledSquares -= filledSquaresInLayerThree;
        int totalEmptySquaresInLayerThree = 30 - filledSquaresInLayerThree;
        remainingEmptySquares -= totalEmptySquaresInLayerThree;

        int filledSquaresInLayerTwo = (totalFilledSquares > 30) ? totalFilledSquares - 30 : 0;
        remainingFilledSquares -= filledSquaresInLayerTwo;
        int totalEmptySquaresInLayerTwo = 30 - filledSquaresInLayerTwo;
        remainingEmptySquares -= totalEmptySquaresInLayerTwo;

        int filledSquaresInLayerOne = totalFilledSquares;
        int totalEmptySquaresInLayerOne = 30 - filledSquaresInLayerOne;
        remainingFilledSquares -= filledSquaresInLayerOne;
        remainingEmptySquares -= totalEmptySquaresInLayerOne;

        //Checks which layer the healthbar is currently in, then prints the appropriate layer
        int currentLayer = LayerCheck(totalFilledSquares, totalEmptySquaresInLayerThree, totalEmptySquaresInLayerTwo, totalEmptySquaresInLayerOne);
        if (currentLayer == 3)
        {
            PrintLayer(currentLayer, totalEmptySquaresInLayerThree, filledSquaresInLayerThree, square);
        }
        else if (currentLayer == 2)
        {
            PrintLayer(currentLayer, totalEmptySquaresInLayerTwo, filledSquaresInLayerTwo, square);
        }
        else if (currentLayer == 1)
        {
            PrintLayer(currentLayer, totalEmptySquaresInLayerOne, filledSquaresInLayerOne, square);
        }

        Console.ResetColor();
    }

    //Print battle standings
    public static void PrintBattleStanding(IReadOnlyList<Person> heroParty, IReadOnlyList<Person> enemyParty)
    {

    }
    //Print banner

    public static void PrintLeftRect(int cursorLeft, int cursorTop, string topLeftArch, string bottomLeftArch, string verticalLine, int[] curserCords)
    {
        int oldLeft = Console.CursorLeft;
        int oldTop = Console.CursorTop;

        //Console.SetCursorPosition(cursorLeft, cursorTop);

        Console.Write(verticalLine);
        Console.SetCursorPosition(cursorLeft, cursorTop + 1);
        Console.Write(topLeftArch);
        curserCords[0] = Console.CursorLeft;
        curserCords[1] = Console.CursorTop;
        Console.SetCursorPosition(oldLeft, oldTop);
        Console.SetCursorPosition(oldLeft, oldTop - 1);
        Console.Write(bottomLeftArch);
        Console.SetCursorPosition(oldLeft + 1, oldTop);


    }
    public static void PrintRightRect(int cursorLeft, int cursorTop, string topRightArch, string bottomRightArch, string verticalLine)
    {

        int oldLeft = Console.CursorLeft;
        int oldTop = Console.CursorTop;

        Console.Write(verticalLine);
        Console.SetCursorPosition(cursorLeft, cursorTop + 1);
        Console.Write(topRightArch);
        Console.SetCursorPosition(oldLeft, oldTop);
        Console.SetCursorPosition(oldLeft, oldTop - 1);
        Console.Write(bottomRightArch);
        Console.SetCursorPosition(oldLeft + 1, oldTop);



    }

    public static void PrintHorizontalEdges(string edge, int length, int cursorLeft, int cursorTop)
    {
        for (int index = 0; index < length + 2; index++)
        {
            Console.Write(edge);
            Console.SetCursorPosition(cursorLeft + index, cursorTop - 2);
            Console.Write(edge);
            Console.SetCursorPosition(cursorLeft + index, cursorTop);
            Console.Write(edge);
        }

        //extra removal
        Console.SetCursorPosition(0, 2);
        for(int index = 0; index != length; index++)
        {
            Console.Write(" ");
        }

        //for (int index = 0; cursorLeft >= 0; index++)
        //{
              

        //}


     

    }
    /// <summary>
    /// Prints a banner with a message in the center of the terminal, with a border around it
    /// </summary>
    /// <param name="message">The message to display in the banner</param>
    public static void PrintBanner(string message)
    {
        //ClearScreen();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        //Banner has different thickness or font size
        //Figure out char length of Terminal
        //Print message in the top center
        //Fill the left and right sides with -----
        string bottomLeftArch = "\u2554";
        string bottomRightArch = "\u2557";
        string topLeftArch = "\u255A";
        string topRightArch = "\u255D";
        string verticalLine = "\u2551";
        string horizontalLine = "\u2550";


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        int terminalWidth = Console.WindowWidth;
        int messageLength = message.Length;
        int centerPosition = (terminalWidth - messageLength) / 2;
        int padding = (terminalWidth - messageLength) / 2;
        int[] curserCords = new int[2];



        Console.SetCursorPosition(0, 1);

        for (int index = 0; index < terminalWidth; index++)
        {
            if (index == padding - 1 || index == padding + 1)
            {

                Console.Write(" ");
                //PrintHorizontalEdges(horizontalLine);
            }
            else if (index == padding - 2 || index == padding + 2)
            {

                int oldLeft = Console.CursorLeft;
                int oldTop = Console.CursorTop;




                if (index == padding - 2)
                {
                    PrintLeftRect(oldLeft, oldTop, topLeftArch, bottomLeftArch, verticalLine, curserCords);
                }
                else if (index == padding + 2)
                {
                    PrintRightRect(oldLeft, oldTop, topRightArch, bottomRightArch, verticalLine);
                }


            }

            else if (index == padding)
            {
                Console.Write(message);
                //PrintHorizontalEdges(horizontalLine);
                //Console.WriteLine(Console.GetCursorPosition());
            }
            else if (index != terminalWidth)
            {

                Console.Write(horizontalLine);
            }

        }
        PrintHorizontalEdges(horizontalLine, messageLength, curserCords[0], curserCords[1]);

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
    /// <param name="party">The party of Person or Enemy objects to print</param>
    public static void PrintCombatantParty(IReadOnlyList<Person> party)
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
                    PrintHealthBar(enemy, enemy.IsBoss);
                    //PrintHealthBar(enemy);
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


