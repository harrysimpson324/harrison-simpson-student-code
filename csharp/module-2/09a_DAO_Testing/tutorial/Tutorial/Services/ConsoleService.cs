using System;

namespace Tutorial.Services
{
    /// <summary>
    /// ConsoleService is a class that provides text-based UI functionality using Console.Read and Console.Write methods.
    /// </summary>
    public class ConsoleService : IBasicConsole
    {
        /************************************************************
            Print methods
        ************************************************************/

        /// <summary>
        /// Prints an error message to the screen, in red text.
        /// </summary>
        /// <param name="message">Message to print.</param>
        public void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a success message to the screen, in green text.
        /// </summary>
        /// <param name="message">Message to print.</param>
        public void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a message to the screen.
        /// </summary>
        /// <param name="message">Message to print.</param>
        public void PrintMessage(string message)
        {
            PrintMessage(message, true);
        }

        /// <summary>
        /// Prints a message to the screen.
        /// </summary>
        /// <param name="message">Message to print.</param>
        /// <param name="withLineFeed">Set to true to print with line feed after message.</param>
        public void PrintMessage(string message, bool withLineFeed)
        {
            if (withLineFeed)
            {
                Console.WriteLine(message); // Print with linefeed
            }
            else
            {
                Console.Write(message);  // Print without linefeed
            }
        }

        /// <summary>
        /// Print a blank line to the screen.
        /// </summary>
        public void PrintBlankLine()
        {
            PrintBlankLines(1);
        }

        /// <summary>
        /// Print multiple blank lines to the screen.
        /// </summary>
        /// <param name="numberOfLines">The number of lines to print.</param>
        public void PrintBlankLines(int numberOfLines)
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints a divider on a line to break up output on screen.
        /// </summary>
        public void PrintDivider()
        {
            Console.WriteLine("-----------------------------");
        }

        /// <summary>
        /// Prints banner consisting of the message with dashes above and below it.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public void PrintBanner(string message)
        {
            string dashes = "".PadRight(message.Length, '-');
            Console.WriteLine(dashes);
            Console.WriteLine(message);
            Console.WriteLine(dashes);
        }

        /// <summary>
        /// Prints items in a bulleted list.
        /// </summary>
        /// <param name="items">The items to display.</param>
        public void PrintBulletedItems(string[] items)
        {
            foreach (string item in items)
            {
                Console.WriteLine("* " + item);
            }
        }

        /************************************************************
            Prompt methods (get user input)
        ************************************************************/

        /// <summary>
        /// Waits for the user to press a key before continuing. Used 
        /// after displaying some results, so the user can read the results, 
        /// then press a key to dismiss.
        /// </summary>
        /// <param name="message">Message to display. If NULL, 'Press any key to continue' will be shown.</param>
        public void Pause(string message = null)
        {
            if (message == null)
            {
                message = "Press any key to continue:";
            }
            Console.Write(message);
            Console.ReadKey();
        }

        /// <summary>
        /// Display a prompt and read an integer from the keyboard.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <returns>Integer entered by the user.</returns>
        public int? PromptForInteger(string message)
        {
            return PromptForInteger(message, null);
        }

        /// <summary>
        /// Display a prompt and read an integer from the keyboard.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <param name="defaultValue">Optional. Value to be used if the user presses Enter without entering anything.</param>
        /// <returns>Integer entered by the user.</returns>
        public int? PromptForInteger(string message, int? defaultValue = null)
        {
            // Prompts for a non-negative integer
            return PromptForInteger(message, 0, int.MaxValue, defaultValue);
        }

        /// <summary>
        /// Display a prompt and read an integer from the keyboard. Validates integer is in a range.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <param name="minimum">Number entered must be greater than or equal to this number.</param>
        /// <param name="maximum">Number entered must be less than or equal to this number.</param>
        /// <param name="defaultValue">Optional. Value to be used if the user presses Enter without entering anything.</param>
        /// <returns>Integer entered by the user.</returns>
        public int? PromptForInteger(string message, int minimum, int maximum, int? defaultValue = null)
        {
            string defaultPrompt = defaultValue.HasValue ? $" [{defaultValue}]: " : ": ";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{message}{defaultPrompt}");
                Console.ResetColor();
                string input = Console.ReadLine();

                if (input.Trim().Length == 0)
                { 
                    // Did the user take the default value?
                    if (defaultValue.HasValue)
                    {
                        return defaultValue.Value;
                    }
                    else
                    {
                        return null;
                    }
                }

                if (int.TryParse(input, out int selection) && selection >= minimum && selection <= maximum)
                {
                    return selection;
                }
                PrintError($"Number is out of range, please try again.");
            }
        }

        /// <summary>
        /// Display a prompt and read a decimal from the keyboard.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <returns>Decimal entered by the user.</returns>
        public decimal PromptForDecimal(string message)
        {
            return PromptForDecimal(message, null);
        }

        /// <summary>
        /// Display a prompt and read a decimal from the keyboard.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <param name="defaultValue">Optional. Value to be used if the user presses Enter without entering anything.</param>
        /// <returns>Decimal entered by the user.</returns>
        public decimal PromptForDecimal(string message, decimal? defaultValue = null)
        {
            return PromptForDecimal(message, 0, decimal.MaxValue, defaultValue);
        }

        /// <summary>
        /// Display a prompt and read a decimal from the keyboard. Validates decimal is in a range.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <param name="minimum">Number entered must be greater than or equal to this number.</param>
        /// <param name="maximum">Number entered must be less than or equal to this number.</param>
        /// <param name="defaultValue">Optional. Value to be used if the user presses Enter without entering anything.</param>
        /// <returns></returns>
        public decimal PromptForDecimal(string message, decimal minimum, decimal maximum, decimal? defaultValue = null)
        {
            string defaultPrompt = defaultValue.HasValue ? $" [{defaultValue}]: " : ": ";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{message}{defaultPrompt}");
                Console.ResetColor();
                string input = Console.ReadLine();

                // Did the user take the default value?
                if (input.Trim().Length == 0 && defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }

                if (decimal.TryParse(input, out decimal selection) && selection >= minimum && selection <= maximum)
                {
                    return selection;
                }
                PrintError($"Number is out of range, please try again.");
            }
        }

        /// <summary>
        /// Display a prompt and read a string from the keyboard.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <returns>String entered by the user.</returns>
        public string PromptForString(string message)
        {
            return PromptForString(message, null);
        }

        /// <summary>
        /// Display a prompt and read a string from the keyboard.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <param name="defaultValue">Optional. Value to be used if the user presses Enter without entering anything.</param>
        /// <returns>String entered by the user.</returns>
        public string PromptForString(string message, string defaultValue = null)
        {
            string defaultPrompt = defaultValue == null ? ": " : $" [{defaultValue}]: ";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{message}{defaultPrompt}");
            Console.ResetColor();
            string input = Console.ReadLine();
            // Did the user take the default value?
            if (input.Length == 0 && defaultValue != null)
            {
                return defaultValue;
            }
            return input;
        }

        /// <summary>
        /// Display a prompt and read a string from the keyboard. Value must start with Y or N.
        /// </summary>
        /// <param name="message"Prompt to display to the user.></param>
        /// <returns>Boolean representing user's input. Y = true, N = false.</returns>
        public bool PromptForYesNo(string message)
        {
            return PromptForYesNo(message, null);
        }

        /// <summary>
        /// Display a prompt and read a string from the keyboard. Value must start with Y or N.
        /// </summary>
        /// <param name="message"Prompt to display to the user.></param>
        /// <param name="defaultValue">Optional. Value to be used if the user presses Enter without entering anything.</param>
        /// <returns>Boolean representing user's input. Y = true, N = false.</returns>
        public bool PromptForYesNo(string message, bool? defaultValue = null)
        {
            while (true)
            {
                string reply = PromptForString(message, defaultValue.HasValue ? defaultValue.Value == true ? "Y" : "N" : null);
                string upperReply = reply.ToUpper();
                if (upperReply.StartsWith("Y"))
                {
                    return true;
                }
                else if (upperReply.StartsWith("N"))
                {
                    return false;
                }
                else
                {
                    PrintError("Please enter Y or N");
                }
            }
        }

        /// <summary>
        /// Display a prompt and read a date from the keyboard.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <returns>Date entered by the user.</returns>
        public DateTime PromptForDate(string message)
        {
            return PromptForDate(message, null);
        }

        /// <summary>
        /// Display a prompt and read a date from the keyboard.
        /// </summary>
        /// <param name="message">Prompt to display to the user.</param>
        /// <param name="defaultValue">Optional. Value to be used if the user presses Enter without entering anything.</param>
        /// <returns>Date entered by the user.</returns>
        public DateTime PromptForDate(string message, DateTime? defaultValue = null)
        {
            while (true)
            {
                string defaultPrompt = defaultValue.HasValue ? $"[{defaultValue:d}]: " : ": ";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{message}{defaultPrompt}");
                Console.ResetColor();
                string input = Console.ReadLine();

                // Did the user take the default value?
                if (input.Trim().Length == 0 && defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }

                if (DateTime.TryParse(input, out DateTime date))
                {
                    return date;
                }
                PrintError($"Invalid date, please try again.");
            }
        }

        public string GetMenuSelection(string[] options)
        {
            return GetMenuSelection(options, false);
        }

        public string GetMenuSelection(string[] options, bool allowNullResponse)
        {
            int? index = GetMenuSelectionIndex(options, allowNullResponse);
            return index == null ? null : options[index.Value];
        }

        public int? GetMenuSelectionIndex(string[] options, bool allowNullResponse)
        {
            int? result = null;
            bool validInput = false;
            while (!validInput)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {options[i]}");
                }
                int? selection = PromptForInteger("Please select");
                if (selection == null)
                {
                    if (allowNullResponse)
                    {
                        validInput = true;
                    }
                    else
                    {
                        PrintError("Please make a selection");
                    }
                }
                else if (selection > 0 && selection <= options.Length)
                {
                    result = selection - 1;
                    validInput = true;
                }
                else
                {
                    PrintError("Invalid selection");
                }
            }
            return result;
        }
    }
}
