using LocationClient.Models;
using System;
using System.Collections.Generic;

namespace LocationClient.Services
{
    public class LocationConsoleService : ConsoleService
    {
        /************************************************************
            Print methods
        ************************************************************/
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Online Meetups Menu");
            Console.WriteLine("-------------------");
            Console.WriteLine("1: List Locations");
            Console.WriteLine("2: Show Location Details");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }

        ///************************************************************
        //    Print methods
        //************************************************************/

        public void PrintLocations(List<Location> locations)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Locations");
            Console.WriteLine("--------------------------------------------");
            if (locations != null)
            {
                foreach (Location location in locations)
                {
                    Console.WriteLine(location.Id + ": " + location.Name);
                }
                Console.WriteLine();
            }
        }

        public void PrintLocation(Location location)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Location Details");
            Console.WriteLine("--------------------------------------------");
            if (location == null)
            {
                Console.WriteLine("Location was not found");
            }
            else
            {
                Console.WriteLine("Id: " + location.Id);
                Console.WriteLine("Name: " + location.Name);
                Console.WriteLine("Address: " + location.Address);
                Console.WriteLine("City: " + location.City);
                Console.WriteLine("State: " + location.State);
                Console.WriteLine("Zip: " + location.Zip);
            }
            Console.WriteLine();
        }

        ///************************************************************
        //    Prompt methods (get user input)
        //************************************************************/
        public int PromptForLocationId(List<Location> locations, string action)
        {
            PrintLocations(locations);
            while (true)
            {
                int locationId = PromptForInteger($"Please enter a location id to {action}, 0 to cancel");
                if (locationId == 0)
                {
                    // User cancel
                    return 0;
                }
                if (IsValidLocationId(locations, locationId))
                {
                    return locationId;
                }
                PrintError("This is not a valid location id");
            }
        }

        ///************************************************************
        //    Validation methods
        //************************************************************/
        public bool IsValidLocationId(List<Location> locations, int locationId)
        {
            if (locations == null)
            {
                return false;
            }
            foreach (Location location in locations)
            {
                if (location.Id == locationId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
