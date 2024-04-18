using LocationClient.Models;
using LocationClient.Services;
using System.Collections.Generic;

namespace LocationClient
{
    public class LocationApp
    {
        private readonly LocationApiService locationApiService;
        private readonly LocationConsoleService console = new LocationConsoleService();

        public LocationApp(string apiURL)
        {
            this.locationApiService = new LocationApiService(apiURL);
        }

        public void Run()
        {
            while (true)
            {
                console.PrintMainMenu();
                int menuSelection = console.PromptForInteger("Please choose an option", 0, 2);

                if (menuSelection == 0)
                {
                    // Exit the loop
                    break;
                }

                if (menuSelection == 1)
                {
                    // List locations
                    ShowLocations();
                }

                if (menuSelection == 2)
                {
                    // Location details
                    ShowLocationDetails();
                }
            }
        }

        private void ShowLocations()
        {
            console.PrintError("This method has not been implemented");
            console.Pause();
        }

        private void ShowLocationDetails()
        {
            console.PrintError("This method has not been implemented");
            console.Pause();
        }
    }
}
