using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks
{
    public class SQLInjectionDemoCLI
    {
        private readonly IStateDao stateDao;
        private readonly IParkDao parkDao;

        public SQLInjectionDemoCLI(IStateDao stateDao, IParkDao parkDao)
        {
            this.stateDao = stateDao;
            this.parkDao = parkDao;
        }

        public void RunCLI()
        {
            DisplayBanner();
            bool running = true;
            while (running)
            {
                DisplayMenu();
                int selection = PromptForInt("Please select an option: ");
                if (selection == 1)
                {
                    string stateAbbr = PromptForString("Please enter a state abbreviation: ");
                    State state = stateDao.GetStateByAbbreviation(stateAbbr);
                    DisplayState(state);
                }
                else if (selection == 2)
                {
                    string stateAbbr = PromptForString("Please enter a state abbreviation: ");
                    State state = stateDao.GetStateByAbbreviationConcatenation(stateAbbr);
                    DisplayState(state);
                }
                else if (selection == 3)
                {
                    string stateName = PromptForString("Please enter a search string: ");
                    if (string.IsNullOrWhiteSpace(stateName))
                    {
                        DisplayError("You must enter a search term");
                    }
                    else
                    {
                        IList<State> states = stateDao.GetStatesByName(stateName);
                        DisplayStates(states);
                    }
                }
                else if (selection == 4)
                {
                    int parkCount = parkDao.GetParkCount();
                    Console.WriteLine($"\nThere are {parkCount} parks\n");
                }
                else if (selection == 5)
                {
                    running = false;
                }
                else
                {
                    DisplayError("Invalid option selected.");
                }
            }
        }

        private void DisplayState(State state)
        {
            Console.WriteLine("---");
            if (state != null)
            {
                Console.WriteLine($"State name: {state.StateName} ({state.StateAbbreviation})");
            }
            else
            {
                Console.WriteLine("State is null");
            }
            Console.WriteLine("---");
        }

        private void DisplayStates(IList<State> states)
        {
            Console.WriteLine("---");
            foreach (State state in states)
            {
                Console.WriteLine($"State name: {state.StateName} ({state.StateAbbreviation})");
            }
            Console.WriteLine("---");
        }

        private void DisplayBanner()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|      SQL Injection Demonstration      |");
            Console.WriteLine("-----------------------------------------");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("1. Get State By Abbreviation (parameter)");
            Console.WriteLine("2. Get State By Abbreviation (string concatenation)");
            Console.WriteLine("3. Get States By Name (string concatenation)");
            Console.WriteLine("4. Get Park Count");
            Console.WriteLine("5. Exit");
        }

        private void DisplayError(string message)
        {
            Console.WriteLine();
            Console.WriteLine("***" + message + "***");
            Console.WriteLine();
        }

        private string PromptForString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private int PromptForInt(string prompt)
        {
            return (int)PromptForDecimal(prompt);
        }

        private decimal PromptForDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string response = Console.ReadLine();
                if (decimal.TryParse(response, out decimal parsed))
                {
                    return parsed;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        return -1; //Assumes negative numbers are never valid entries.
                    }
                    else
                    {
                        DisplayError("Numbers only, please.");
                    }
                }
            }
        }
    }
}
