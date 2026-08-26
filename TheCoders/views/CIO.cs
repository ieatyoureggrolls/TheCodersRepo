using System;
using System.Collections.Generic;
using System.Text;
using TheCoders.models;
using COH = TheCoders.views.ConsoleOutputHelper;


namespace TheCoders.views
{
    public static class CIO
    {
        /// <summary>
        /// Generates a console-based menu using the strings in options as the menu items.
        /// Automatically numbers each option starting at 1 and incrementing by 1.
        /// Reserves the number 0 for the "quit" option when withQuit is true.
        /// </summary>
        /// <param name="options">strings representing the menu options</param>
        /// <param name="withQuit">adds option 0 for "quit" when true</param>
        /// <returns>the int of the selection made by the user</returns>
        /// <exception cref="ArgumentException">
        ///     options is null
        ///     options is empty and withQuit is false
        /// </exception>
        public static int PromptForMenuSelection(IEnumerable<string> options, bool withQuit)
        {
            if (options == null || (options.Count() == 0 && (!withQuit)))
                throw new ArgumentException("Options cannot be null or empty with no quit");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < options.Count(); i++)
                sb.Append($"{(i + 1)}. {options.ElementAt(i)}\n");

            if (withQuit)
                sb.Append("0. Quit");

            int input = PromptForInt(sb.ToString(), (withQuit ? 0 : 1), options.Count());

            return input;
        }
        public static int PromptForMenuSelectionInBox(IEnumerable<string> optionsIE, bool withQuit,  bool centered = false)
        {
            if (optionsIE == null || (optionsIE.Count() == 0 && (!withQuit)))
                throw new ArgumentException("Options cannot be null or empty with no quit");

            

            string topLeftArch = "\u2554";
            string topRightArch = "\u2557";
            string bottomLeftArch = "\u255A";
            string bottomRightArch = "\u255D";
            string verticalLine = "\u2551";
            string horizontalLine = "\u2550";
            //Repeat(" ", 10, false);
            // ChooseMode();

            if (withQuit)
            {
                
                optionsIE = optionsIE.Append("Quit");
                

            }
            string[] options = optionsIE.ToArray();
            int listIndex = 0;
            int height = options.Count() + 2;
            
            int width = 0;
            for(int index = 0; index < options.Count(); index++)
            {
                if (options.ElementAt(index).Length > width)
                {
                    width = options.ElementAt(index).Length;
                }
            }
            width += 7;
            Console.WriteLine($"Width: {width}, Height: {height}");
            
            int column = 0;


            for (int index = 0; index < height; index++)
            {
                column++;
                int padding;
                if (centered)
                {
                    padding = (Console.WindowWidth - width) / 2 - 1;
                }
                else
                {
                    padding = 0;
                }
                if (index == 0)
                {
                    ConsoleOutputHelper.Repeat(" ", padding, false);
                    Console.Write(topLeftArch);
                    for (int i = 0; i < width; i++)
                    {
                        Console.Write(horizontalLine);
                    }
                    Console.WriteLine(topRightArch);
                }
                else if (index == height+1)
                {
                    COH.Repeat(" ", padding, false);
                    Console.Write(bottomLeftArch);
                    for (int i = 0; i < width; i++)
                    {
                        Console.Write(horizontalLine);
                    }
                    Console.WriteLine(bottomRightArch);
                }
                else if (index < options.Count() + 1)
                {
                    COH.Repeat(" ", padding, false);


                    Console.Write(verticalLine);
                    
                    Console.Write($"  {index}. {options[index - 1]} ");
                    if(index == 1)
                    {
                        Console.Write("  ");
                    }

                    listIndex++;
                    if (index == 3)
                    {
                        Console.Write("        ");
                    }

                    COH.Repeat(" ", 1, false);
                    Console.WriteLine(verticalLine);
                }

                else
                {
                    COH.Repeat(" ", padding, false);
                    Console.Write(verticalLine);
                    for (int i = 0; i < width; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(verticalLine);
                }

                if(index == height - 1)
                {
                    COH.Repeat(" ", padding, false);
                    Console.Write(bottomLeftArch);
                    for (int i = 0; i < width; i++)
                    {
                        Console.Write(horizontalLine);
                    }
                    Console.WriteLine(bottomRightArch);
                }
            }
            
            string anvil = ("""
                      ⢰⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⡄⠀⠀⠀⠀
                ⠹⣿⣿⣿⣿⡇⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢠⣄⡀⠀
                ⠀⠙⢿⣿⣿⡇⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢸⣿⣿⡶
                ⠀⠀⠀⠉⠛⠇⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠸⠟⠋⠀
                ⠀⠀⠀⠀⠀⠀⠸⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠇⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣶⣶⣶⣶⣶⣶⣶⣶⡀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⣀⣀⣈⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⣉⣁⣀⣀⠀⠀⠀
                ⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀
                """);
            string[] anvilLines = anvil.Split("\n");
            foreach (string line in anvilLines)
            {
                COH.Repeat(" ", (Console.WindowWidth - line.Length) / 2, false);
                Console.WriteLine(line);
            }
            int input = PromptForInt("Option: ",(withQuit ? 0 : 1), options.Count());
            return input;
        }

        /// <summary>
        /// Generates a prompt that expects the user to enter one of two responses that will equate
        /// to a boolean value. The trueString represents the case-insensitive response that will equate to true. 
        /// The falseString acts similarly, but for a false boolean value.
        ///     <para>
        ///         Example: Assume this method is called with a trueString argument of "yes" and a falseString
        ///         argument of "no". If the user enters "YES", the method returns true. If the user enters "no",
        ///         the method returns false. All other inputs are considered invalid, the user will be informed, 
        ///         and the prompt will repeat.
        ///     </para>
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="trueString">the case-insensitive value that will evaluate to true</param>
        /// <param name="falseString">the case-insensitive value that will evaluate to false</param>
        /// <returns>the boolean result based on the user's input</returns>
        /// <exception cref="ArgumentException">
        ///     prompt, trueString, or falseString is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     trueString and falseString are case-insensitively equal
        /// </exception>
        public static bool PromptForBool(string prompt, string trueString, string falseString)
        {
            if (string.IsNullOrWhiteSpace(prompt) || trueString == null || falseString == null)
                throw new ArgumentException("Prompt must not be empty/null | True & False string must not be null");
            do
            {
                string answer = PromptForInput(prompt, false);
                if (!string.Equals(answer, trueString, StringComparison.CurrentCultureIgnoreCase) && !string.Equals(answer, falseString, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine($"Response does not match {trueString} or {falseString}. Response: {answer}");
                    continue;
                }
                return string.Equals(answer, trueString, StringComparison.CurrentCultureIgnoreCase);
            } while (true);
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a byte value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid byte value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static byte PromptForByte(string prompt, byte min, byte max)
        {
            if (string.IsNullOrWhiteSpace(prompt) || min > max)
                throw new ArgumentException("Prompt must not be null and min must not be greater then max");

            do
            {
                string input = PromptForInput($"{prompt}({min}-{max})", false);
                byte response;
                try
                {
                    response = byte.Parse(input);
                    if (response <= max && response >= min)
                        return response;

                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
            } while (true);
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a short value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid short value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static short PromptForShort(string prompt, short min, short max)
        {
            if (string.IsNullOrWhiteSpace(prompt) || min > max)
                throw new ArgumentException("Prompt must not be null and min must not be greater then max");

            do
            {
                string input = PromptForInput($"{prompt}({min}-{max})", false);
                short response;
                try
                {
                    response = short.Parse(input);
                    if (response <= max && response >= min)
                        return response;

                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
            } while (true);
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing an int value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid int value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static int PromptForInt(string prompt, int min, int max)
        {
            if (string.IsNullOrWhiteSpace(prompt) || min > max)
                throw new ArgumentException("Prompt must not be null and min must not be greater then max");

            do
            {
                string input = PromptForInput($"{prompt}({min}-{max})", false);
                int response;
                try
                {
                    response = int.Parse(input);
                    if (response <= max && response >= min)
                        return response;

                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
            } while (true);
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a long value.
        /// This method loops until valid input is given.
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid long value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static long PromptForLong(string prompt, long min, long max)
        {
            if (string.IsNullOrWhiteSpace(prompt) || min > max)
                throw new ArgumentException("Prompt must not be null and min must not be greater then max");

            do
            {
                string input = PromptForInput($"{prompt}({min}-{max})", false);
                long response;
                try
                {
                    response = long.Parse(input);
                    if (response <= max && response >= min)
                        return response;

                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
            } while (true);
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a float value.
        /// This method loops until valid input is given.
		///
		/// <para>NOTE: For the purposes of this method, two floats are considered equal if the absolute value of their difference
		/// is less than or equal to 0.00001.</para>
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid float value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static float PromptForFloat(string prompt, float min, float max)
        {
            if (string.IsNullOrWhiteSpace(prompt) || min > max)
                throw new ArgumentException("Prompt must not be null and min must not be greater then max");

            do
            {
                string input = PromptForInput($"{prompt}({min}-{max})", false);
                float response;
                try
                {
                    response = float.Parse(input);
                    if (response <= max && response >= min)
                        return response;

                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
            } while (true);
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a double value.
        /// This method loops until valid input is given.
        /// 
		/// <para>NOTE: For the purposes of this method, two doubles are considered equal if the absolute value of their difference
		/// is less than or equal to 0.0000000000001.</para>
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid double value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static double PromptForDouble(string prompt, double min, double max)
        {
            if (string.IsNullOrWhiteSpace(prompt) || min > max)
                throw new ArgumentException("Prompt must not be null and min must not be greater then max");

            do
            {
                string input = PromptForInput($"{prompt}({min}-{max})", false);
                double response;
                try
                {
                    response = double.Parse(input);
                    if (response <= max && response >= min)
                        return response;

                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
            } while (true);
        }

        /// <summary>
        /// Generates a prompt that expects a numeric input representing a decimal value.
        /// This method loops until valid input is given.
        /// 
		/// <para>NOTE: For the purposes of this method, two decimals are considered equal if the absolute value of their difference
		/// is less than or equal to 0.00000000000000000000000000001.</para>
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid decimal value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static decimal PromptForDecimal(string prompt, decimal min, decimal max)
        {
            if (string.IsNullOrWhiteSpace(prompt) || min > max)
                throw new ArgumentException("Prompt must not be null and min must not be greater then max");

            do
            {
                string input = PromptForInput($"{prompt}({min}-{max})", false);
                decimal response;
                try
                {
                    response = decimal.Parse(input);
                    if (response <= max && response >= min)
                        return response;

                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Input must be a number between {min}-{max}");
                }
            } while (true);
        }

        /// <summary>
        /// Generates a prompt that allows the user to enter any response and returns the string.
        /// When allowEmpty is true, empty responses are valid. When false, responses must contain
        /// at least one character (including whitespace). Null is never a valid user input for this method.
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user.</param>
        /// <param name="allowEmpty">when true, makes empty responses valid</param>
        /// <returns>the input from the user as a string</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        /// </exception>
        public static string PromptForInput(string prompt, bool allowEmpty)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                throw new ArgumentException("The prompt can't be null, empty, or whitespace.");

            string? input = null;
            bool isInvalid = true;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                isInvalid = input == null || (input == string.Empty && !allowEmpty);
                if (isInvalid)
                {
                    Console.WriteLine("Your input was invalid. Please, try again.");
                }
            } while (isInvalid);

            return input!;
        }

        /// <summary>
        /// Generates a prompt that expects a single character input representing a char value.
        /// This method loops until valid input is given.
		///
		/// <para>NOTE: When validating user input and min/max values, this method IS case sensitive.</para>
        /// </summary>
        /// <param name="prompt">the prompt to be displayed to the user</param>
        /// <param name="min">the inclusive minimum boundary</param>
        /// <param name="max">the inclusive maximum boundary</param>
        /// <returns>the user's valid char value</returns>
        /// <exception cref="ArgumentException">
        ///     prompt is null
        ///     prompt is empty
        ///     prompt is just whitespace
        ///     min is greater than max
        /// </exception>
        public static char PromptForChar(string prompt, char min, char max)
        {
            if (string.IsNullOrWhiteSpace(prompt) || min > max)
                throw new ArgumentException("Prompt can't be empty/null | min can't be bigger then max");

            do
            {
                string input = PromptForInput(prompt, false);
                if (input.Count() > 1)
                {
                    Console.WriteLine("Please only enter 1 character");
                    continue;
                }
                char response = input[0];
                if (response < min || response > max)
                {
                    Console.WriteLine($"Your answer must be between {min} and {max}. You put: {response}");
                    continue;
                }
                return response;
            } while (true);
        }

        public static Person PromptForPerson(string prompt, Person[] people)
        {
            string[] names = new string[people.Length];
            for (int i = 0; i < names.Length; i++)
                names[i] = people[i].Name;
            Console.WriteLine(prompt);
            int choice = PromptForMenuSelection(names, false) - 1;
            return people[choice];
        }

        public static Weapon PromptForWeapon(string prompt, Weapon[] weapons)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < weapons.Length; i++)
            {
                Console.Write($"{i}. ");
                weapons[i].displayWeaponInfo();
            }
            int choice = PromptForInt("Selection: ", 1, weapons.Length) - 1;
            return weapons[choice];
        }

        public static Weapon PromptForWeaponFromPerson(string prompt, Person[] people)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < people.Length; i++)
            {
                Person person = people[i];
                Console.Write($"{i + 1}. {person}\n\t");
                if (person.heldWeapon != null)
                    person.heldWeapon.displayWeaponInfo();
                else
                    Console.WriteLine("No Weapon");
            }
            int choice = PromptForInt("Selection: ", 1, people.Length) - 1;
            return people[choice].heldWeapon;
        }

        public static Person PromptForPersonWithWeapon(string prompt, Person[] people)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < people.Length; i++)
            {
                Person person = people[i];
                Console.Write($"{i}. {person}\n\t");
                if (person.heldWeapon != null)
                    person.heldWeapon.displayWeaponInfo();
                else
                    Console.WriteLine("No Weapon");
            }
            int choice = PromptForInt("Selection: ", 1, people.Length) - 1;
            return people[choice];
        }
    }
}
