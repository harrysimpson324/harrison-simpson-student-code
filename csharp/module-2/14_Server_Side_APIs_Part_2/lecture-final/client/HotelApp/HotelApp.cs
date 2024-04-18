using HotelReservationsClient.Models;
using HotelReservationsClient.Services;
using System;
using System.Collections.Generic;

namespace HotelReservationsClient
{
    public class HotelApp
    {
        private readonly HotelApiService hotelApiService;
        private readonly HotelConsoleService console = new HotelConsoleService();

        public HotelApp(string apiURL)
        {
            this.hotelApiService = new HotelApiService(apiURL);
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
                    // List hotels
                    ShowHotels();
                }

                if (menuSelection == 2)
                {
                    // List Reservations for Hotel
                    ShowHotelReservations();
                }

                if (menuSelection == 3)
                {
                    // Create new Reservation for Hotel
                    AddReservation();
                }

                if (menuSelection == 4)
                {
                    // Update existing Reservation for Hotel
                    UpdateReservation();
                }

                if (menuSelection == 5)
                {
                    // Delete Reservation
                    DeleteReservation();
                }

            }
        }

        private void ShowHotels()
        {
            try
            {
                List<Hotel> hotels = hotelApiService.GetHotels();
                if (hotels != null)
                {
                    console.PrintHotels(hotels);
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void ShowHotelReservations()
        {
            try
            {
                List<Hotel> hotels = hotelApiService.GetHotels();
                if (hotels != null && hotels.Count > 0)
                {
                    int hotelId = console.PromptForHotelId(hotels, "list reservations");
                    if (hotelId == 0)
                    {
                        // User cancel
                        return;
                    }

                    // Try to get reservations
                    List<Reservation> reservations = hotelApiService.GetReservations(hotelId);
                    if (reservations != null)
                    {
                        console.PrintReservations(reservations, hotelId);
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }
        private void AddReservation()
        {
            try
            {
                // Get the Hotel first
                List<Hotel> hotels = hotelApiService.GetHotels();
                int hotelId = console.PromptForHotelId(hotels, "create reservation");
                if (hotelId == 0)
                {
                    // User cancel
                    return;
                }
                Reservation reservationToAdd = console.PromptForReservationData(hotelId);
                if (reservationToAdd == null)
                {
                    // user cancel
                    return;
                }
                if (reservationToAdd.IsValid)
                {
                    Reservation addedReservation = hotelApiService.AddReservation(reservationToAdd);
                    if (addedReservation != null)
                    {
                        console.PrintSuccess("Reservation successfully added.");
                    }
                    else
                    {
                        console.PrintError("Reservation not added.");
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void UpdateReservation()
        {
            // Update an existing reservation
            try
            {
                List<Reservation> reservations = hotelApiService.GetReservations();
                if (reservations != null)
                {
                    int reservationId = console.PromptForReservationId(reservations, "update");
                    if (reservationId == 0)
                    {
                        // User cancel
                        return;
                    }
                    Reservation oldReservation = hotelApiService.GetReservation(reservationId);
                    if (oldReservation != null)
                    {
                        Reservation reservationToUpdate = console.PromptForReservationData(oldReservation.HotelId, oldReservation);

                        if (reservationToUpdate.IsValid)
                        {
                            Reservation updatedReservation = hotelApiService.UpdateReservation(reservationToUpdate);
                            if (updatedReservation != null)
                            {
                                console.PrintSuccess("Reservation successfully updated.");
                            }
                            else
                            {
                                console.PrintError("Reservation not updated.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void DeleteReservation()
        {
            // Delete reservation
            try
            {
                List<Reservation> reservations = hotelApiService.GetReservations();
                if (reservations != null)
                {
                    int reservationId = console.PromptForReservationId(reservations, "delete");
                    if (reservationId == 0)
                    {
                        // User cancel
                        return;
                    }

                    bool deleteSuccess = hotelApiService.DeleteReservation(reservationId);
                    if (deleteSuccess)
                    {
                        console.PrintSuccess("Reservation successfully deleted.");
                    }
                    else
                    {
                        console.PrintError("Reservation not deleted.");
                    }
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
