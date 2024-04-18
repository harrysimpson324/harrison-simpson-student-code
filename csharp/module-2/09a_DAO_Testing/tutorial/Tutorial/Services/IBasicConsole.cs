using System;

namespace Tutorial.Services
{
    /// <summary>
    /// The IBasicConsole interface is implemented by a class that provides a simple UI oriented
    /// around menus and prompting the user for input.
    /// The main reason this interface is included in the application is to facilitate testing.
    /// When testing, an implementation of this interface can be used that simulates user input.
    /// </summary>
    public interface IBasicConsole
    {
        void Pause(string message);

        void PrintMessage(string message);

        void PrintMessage(string message, bool noLineFeed);

        void PrintError(string message);

        void PrintSuccess(string message);

        void PrintBlankLine();

        void PrintBlankLines(int numberOfLines);

        void PrintDivider();

        void PrintBanner(string message);

        void PrintBulletedItems(string[] items);


        string GetMenuSelection(string[] options);
        string GetMenuSelection(string[] options, bool allowNullResponse);
        int? GetMenuSelectionIndex(string[] options, bool allowNullResponse);


        string PromptForString(string message);
        string PromptForString(string message, string defaultValue = null);


        bool PromptForYesNo(string message);
        bool PromptForYesNo(string message, bool? defaultValue = null);


        int? PromptForInteger(string message);
        int? PromptForInteger(string message, int? defaultValue = null);
        int? PromptForInteger(string message, int minimum, int maximum, int? defaultValue = null);


        decimal PromptForDecimal(string message);
        decimal PromptForDecimal(string message, decimal? defaultValue = null);
        decimal PromptForDecimal(string message, decimal minimum, decimal maximum, decimal? defaultValue = null);


        DateTime PromptForDate(string message);
        DateTime PromptForDate(string message, DateTime? defaultValue = null);
    }
}
