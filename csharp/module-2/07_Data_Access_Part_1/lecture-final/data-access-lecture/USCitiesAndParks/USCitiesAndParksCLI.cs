using System;
using System.Collections.Generic;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks
{
    public class USCitiesAndParksCLI
    {
        private readonly ICityDao cityDao;
        private readonly IStateDao stateDao;
        private readonly IParkDao parkDao;

        public USCitiesAndParksCLI(ICityDao cityDao, IStateDao stateDao, IParkDao parkDao)
        {
            this.cityDao = cityDao;
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
                    ViewCityInfo();
                }
                else if (selection == 2)
                {
                    ViewParkInfo();
                }
                else if (selection == 3)
                {
                    running = false;
                }
                else
                {
                    DisplayError("Invalid option selected.");
                }
            }
        }

        private void ViewCityInfo()
        {
            int cityCount = GetCityCount();
            Console.WriteLine();
            Console.WriteLine($"There are {cityCount} cities available");
            Console.WriteLine();
            if (cityCount > 0)
            {
                Console.WriteLine($"The largest city has a population of {GetLargestPopulation().ToString("#,###")}");
                Console.WriteLine($"The smallest city has a population of {GetSmallestPopulation().ToString("#,###")}");
                Console.WriteLine();
                Console.WriteLine($"The average city area is {GetAverageCityArea().ToString("0.00")} sq. km");
                Console.WriteLine();
                Console.WriteLine("1. View a specific city");
                Console.WriteLine("2. View a random city");
                Console.WriteLine("3. View a list of city names");
                int selection = PromptForInt("Please select an option: ");
                if (selection == 1)
                {
                    City city = PromptForCity();
                    Console.WriteLine();
                    DisplayCity(city);
                }
                else if (selection == 2)
                {
                    Console.WriteLine();
                    City city = cityDao.GetRandomCity();
                    DisplayCity(city);
                }
                else if (selection == 3)
                {
                    Console.WriteLine();
                    DisplayCityNames();
                }
                else
                {
                    DisplayError("Invalid option selected.");
                }
            }
        }

        private int GetCityCount()
        {
            int cityCount = 0;
            cityCount = cityDao.GetCityCount();
            return cityCount;
        }

        private int GetLargestPopulation()
        {
            int population = 0;
            population = cityDao.GetMostPopulatedCity();
            return population;
        }

        private int GetSmallestPopulation()
        {
            int population = 0;
            population = cityDao.GetLeastPopulatedCity();
            return population;
        }

        private decimal GetAverageCityArea()
        {
            decimal area = 0.0M;
            area = cityDao.GetAverageCityArea();
            return area;
        }

        private City GetRandomCity()
        {
            City city = null;
            city = cityDao.GetRandomCity();
            return city;
        }

        private void ViewParkInfo()
        {
            int parkCount = GetParkCount();
            Console.WriteLine();
            Console.WriteLine($"There are {parkCount} parks available");
            Console.WriteLine();
            if (parkCount > 0)
            {
                Console.WriteLine($"The oldest park was established in {GetOldestParkDate().ToString("yyyy-MM-dd")}");
                Console.WriteLine();
                Console.WriteLine($"The average park area is {GetAverageParkArea().ToString("0.00")} sq. km");
                Console.WriteLine();
                Console.WriteLine("1. Find a park by name");
                Console.WriteLine("2. Find a park by state");
                Console.WriteLine("3. View a random park");
                Console.WriteLine("4. View a list of parks with camping");
                Console.WriteLine("5. View a list of park names");
                int selection = PromptForInt("Please select an option: ");
                if (selection == 1)
                {
                    Park park = PromptForParkByName();
                    Console.WriteLine();
                    DisplayPark(park);
                }
                else if (selection == 2)
                {
                    Park park = PromptForParkByState();
                    Console.WriteLine();
                    DisplayPark(park);
                }
                else if (selection == 3)
                {
                    Console.WriteLine();
                    Park park = parkDao.GetRandomPark();
                    DisplayPark(park);
                }
                else if (selection == 4)
                {
                    Console.WriteLine();
                    DisplayParksWithCamping();
                }
                else if (selection == 5)
                {
                    Console.WriteLine();
                    DisplayParkNames();
                }
                else
                {
                    DisplayError("Invalid option selected.");
                }
            }
        }

        private int GetParkCount()
        {
            int ParkCount = 0;
            ParkCount = parkDao.GetParkCount();
            return ParkCount;
        }

        private DateTime GetOldestParkDate()
        {
            DateTime parkDate = DateTime.MinValue;
            parkDate = parkDao.GetOldestParkDate();
            return parkDate;
        }

        private decimal GetAverageParkArea()
        {
            decimal area = 0.0M;
            area = parkDao.GetAverageParkArea();
            return area;
        }

        private Park GetRandomPark()
        {
            Park park = null;
            park = parkDao.GetRandomPark();
            return park;
        }

        private void DisplayBanner()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|  US Cities and Parks Data Management  |");
            Console.WriteLine("-----------------------------------------");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("1. View city information");
            Console.WriteLine("2. View park information");
            Console.WriteLine("3. Exit");
        }

        private void DisplayError(string message)
        {
            Console.WriteLine();
            Console.WriteLine("***" + message + "***");
            Console.WriteLine();
        }

        private void DisplayCity(City city)
        {
            if (city != null)
            {
                Console.WriteLine(city);
                Console.WriteLine($"Population: {city.Population.ToString("#,###")} Area: {city.Area.ToString("0.00")} sq. km\n");
            }
            else
            {
                Console.WriteLine("City is null");
            }
        }

        private void DisplayCityNames()
        {
            Console.WriteLine("The following cities are available: ");
            IList<string> cityNames = cityDao.GetCityNames();
            if (cityNames.Count > 0)
            {
                foreach (string cityName in cityNames)
                {
                    Console.WriteLine(cityName);
                }
            }
            else
            {
                Console.WriteLine("No city names available");
            }
            Console.WriteLine();
        }

        private void DisplayPark(Park park)
        {
            if (park != null)
            {
                Console.WriteLine(park);
                Console.WriteLine($"Established: {park.DateEstablished.ToShortDateString()} Area: {park.Area} sq. km");
                Console.WriteLine("This park {0} camping.\n", park.HasCamping ? "offers" : "does not offer");
            }
            else
            {
                Console.WriteLine("Park is null");
            }
        }

        private void DisplayParksWithCamping() {
            Console.WriteLine("The following parks offer camping: ");
            IList<Park> parks = parkDao.GetParksWithCamping();
            if (parks.Count > 0)
            {
                foreach (Park park in parks)
                {
                    DisplayPark(park);
                }
            }
            else
            {
                Console.WriteLine("No parks with camping");
            }
        }

        private void DisplayParkNames()
        {
            Console.WriteLine("The following parks are available: ");
            IList<string> parks = parkDao.GetParkNames();
            if (parks.Count > 0)
            {
                foreach (string parkName in parks)
                {
                    Console.WriteLine(parkName);
                }
            }
            else
            {
                Console.WriteLine("No park names are available");
            }
            Console.WriteLine();
        }

        private string PromptForString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private void PromptToContinue()
        {
            Console.Write("Press Enter to continue: ");
            Console.ReadLine();
            Console.WriteLine();
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

        private DateTime PromptForDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string response = Console.ReadLine();
                try
                {
                    return DateTime.Parse(response);
                }
                catch
                {
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        return DateTime.MinValue;
                    }
                    else
                    {
                        DisplayError("Please format as YYYY-MM-DD.");
                    }
                }
            }
        }

        private State PromptForState()
        {
            while (true)
            {
                Console.Write("Please enter a state abbreviation (enter ? to list state abbreviations): ");
                string response = Console.ReadLine();
                if (response == "?")
                {
                    foreach (State state in stateDao.GetStates())
                    {
                        Console.WriteLine(state.StateAbbreviation + "   " + state.StateName);
                    }
                }
                else
                {
                    State result = stateDao.GetStateByAbbreviation(response.ToUpper());
                    if (result == null)
                    {
                        DisplayError("Invalid state abbreviation.");
                    }
                    else
                    {
                        return result;
                    }
                }
            }
        }

        private City PromptForCity()
        {
            City city = null;
            IList<City> cities = new List<City>();
            Console.WriteLine("What state is the city in?");
            State state = PromptForState();
            // Get the cities in the state
            cities = cityDao.GetCitiesByState(state.StateAbbreviation);
            if (cities.Count > 0)
            {
                for (int i = 0; i < cities.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {cities[i].CityName}");
                }
                while (true)
                {
                    try
                    {
                        int selection = PromptForInt("Please select a city: ");
                        city = cities[selection - 1];
                        break;
                    }
                    catch
                    {
                        DisplayError("Invalid selection.");
                    }
                }
            }
            else
            {
                DisplayError("No cities in selected state.");
            }
            return city;
        }

        private Park PromptForParkByName()
        {
            Park park = null;
            IList<Park> parks = new List<Park>();
            Console.WriteLine("What is the park's name?");
            Tuple<string, bool> nameAndWildCard = PromptForNameAndWildcard();
            // Get the parks in the state
            parks = parkDao.GetParksByName(nameAndWildCard.Item1, nameAndWildCard.Item2);
            if (parks.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{parks.Count} park(s) found for name: {nameAndWildCard.Item1}");

                for (int i = 0; i < parks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {parks[i].ParkName}");
                }

                Console.WriteLine();

                while (true)
                {
                    try
                    {
                        int selection = PromptForInt("Please select a park: ");
                        park = parks[selection - 1];
                        break;
                    }
                    catch
                    {
                        DisplayError("Invalid selection.");
                    }
                }
            }
            else
            {
                DisplayError($"No parks found by name: {nameAndWildCard.Item1}.");
            }
            return park;
        }

        private Tuple<string, bool> PromptForNameAndWildcard()
        {
            string name = null;
            bool useWildCard = false;

            while (true)
            {
                Console.Write("Please enter all or part of the park's name you wish to search for: ");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    DisplayError("Please enter a value to search for.");
                }
                else
                {
                    Console.WriteLine("Is this the exact park name (y/n)?");
                    useWildCard = Console.ReadLine().ToLower() != "y";

                    return new Tuple<string, bool>(name, useWildCard);
                }
            }
        }

        private Park PromptForParkByState()
        {
            Park park = null;
            IList<Park> parks = new List<Park>();
            Console.WriteLine("What state is the park in?");
            State state = PromptForState();
            // Get the parks in the state
            parks = parkDao.GetParksByState(state.StateAbbreviation);
            if (parks.Count > 0)
            {
                for (int i = 0; i < parks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {parks[i].ParkName}");
                }
                while (true)
                {
                    try
                    {
                        int selection = PromptForInt("Please select a park: ");
                        park = parks[selection - 1];
                        break;
                    }
                    catch
                    {
                        DisplayError("Invalid selection.");
                    }
                }
            }
            else
            {
                DisplayError("No parks in selected state.");
            }
            return park;
        }
    }
}
