using HotelApp.Models;
using HotelApp.Services;
using System;
using System.Collections.Generic;

namespace HotelApp
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
                int menuSelection = console.PromptForInteger("Please choose an option", 0, 6);

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
                    // List Reviews
                    ShowReviews();
                }

                if (menuSelection == 3)
                {
                    // Show Details for Hotel ID 1
                    ShowHotelDetails(1);
                }

                if (menuSelection == 4)
                {
                    // List Reviews for Hotel ID 1
                    ShowHotelReviews(1);
                }

                if (menuSelection == 5)
                {
                    // List Hotels with star rating 3
                    FilterHotelsByRating(3);
                }

                if (menuSelection == 6)
                {
                    // Public API Query
                    PrintCity();
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

        private void ShowReviews()
        {
            try
            {
                List<Review> reviews = hotelApiService.GetReviews();
                if (reviews != null)
                {
                    console.PrintReviews(reviews);
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void ShowHotelDetails(int hotelId)
        {
            try
            {
                Hotel hotel = hotelApiService.GetHotel(hotelId);
                if (hotel != null)
                {
                    console.PrintHotel(hotel);
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void ShowHotelReviews(int hotelId)
        {
            try
            {
                List<Review> reviews = hotelApiService.GetHotelReviews(hotelId);
                if (reviews != null)
                {
                    console.PrintReviews(reviews);
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void FilterHotelsByRating(int rating)
        {
            try
            {
                List<Hotel> hotels = hotelApiService.GetHotelsWithRating(rating);
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

        private void PrintCity()
        {
            try
            {
                City city = hotelApiService.GetPublicAPIQuery();
                if (city != null)
                {
                    console.PrintCity(city);
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
