using LocationClient.Models;
using LocationClient.Services;
using System;
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
                int menuSelection = console.PromptForInteger("Please choose an option", 0, 5);

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

                if (menuSelection == 3)
                {
                    // Create new location
                    AddLocation();
                }

                if (menuSelection == 4)
                {
                    // Update existing location
                    UpdateLocation();
                }

                if (menuSelection == 5)
                {
                    // Delete location
                    DeleteLocation();
                }
            }
        }

        private void ShowLocations()
        {
            List<Location> listLocations = locationApiService.GetAllLocations();
            console.PrintLocations(listLocations);
            console.Pause();
        }

        private void ShowLocationDetails()
        {
            List<Location> listLocations = locationApiService.GetAllLocations();
            int locationId = console.PromptForLocationId(listLocations, "view");
            if (locationId == 0)
            {
                // User cancel
                return;
            }
            Location location = locationApiService.GetDetailsForLocation(locationId);
            console.PrintLocation(location);
            console.Pause();
        }

        private void AddLocation()
        {
            Location newLocation = console.PromptForLocationData();
            if (newLocation == null)
            {
                // User cancel
                return;
            }

            try
            {
                if (newLocation.IsValid)
                {
                    Location returnedLocation = locationApiService.AddLocation(newLocation);
                    if (returnedLocation != null)
                    {
                        console.PrintLocations(locationApiService.GetAllLocations()); //confirmation of success
                        console.PrintSuccess($"Location {returnedLocation.Id} was added.");
                    }
                    else
                    {
                        console.PrintError("Location was not added.");
                    }
                }
                else
                {
                    console.PrintError("Location was not added. Some data was invalid.");
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void UpdateLocation()
        {
            try
            {
                List<Location> listLocations = locationApiService.GetAllLocations();
                int locationId = console.PromptForLocationId(listLocations, "update");
                if (locationId == 0)
                {
                    // User cancel
                    return;
                }

                Location locationToUpdate = locationApiService.GetDetailsForLocation(locationId);
                if (locationToUpdate != null)
                {
                    Location updatedLocation = console.PromptForLocationData(locationToUpdate);
                    if (updatedLocation.IsValid)
                    {
                        Location returnedLocation = locationApiService.UpdateLocation(updatedLocation);
                        if (returnedLocation != null)
                        {
                            console.PrintLocations(locationApiService.GetAllLocations()); //confirmation of success
                            console.PrintSuccess($"Location {locationToUpdate.Id} was updated.");
                        }
                        else
                        {
                            console.PrintError($"Location {locationToUpdate.Id} was not updated.");
                        }
                    }
                    else
                    {
                        console.PrintError($"Location {locationToUpdate.Id} was not updated. Some data was invalid.");
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void DeleteLocation()
        {
            try
            {
                List<Location> listLocations = locationApiService.GetAllLocations();
                int locationId = console.PromptForLocationId(listLocations, "delete");
                if (locationId == 0)
                {
                    // User cancel
                    return;
                }
                bool deleted = locationApiService.DeleteLocation(locationId);
                if (deleted)
                {
                    console.PrintLocations(locationApiService.GetAllLocations()); //confirmation of success
                    console.PrintSuccess($"Location {locationId} was deleted.");
                }
                else
                {
                    console.PrintError($"Location {locationId} was not deleted.");
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }
    }
}
