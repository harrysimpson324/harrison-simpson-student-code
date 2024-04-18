using HotelApp.Models;
using System;
using System.Collections.Generic;

namespace HotelApp.Services
{
    public class HotelConsoleService : ConsoleService
    {
        /************************************************************
            Print methods
        ************************************************************/
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Online Hotels Menu");
            Console.WriteLine("------------------");
            Console.WriteLine("1: List Hotels");
            Console.WriteLine("2: List Reviews");
            Console.WriteLine("3: Show Details for Hotel ID 1");
            Console.WriteLine("4: List Reviews for Hotel ID 1");
            Console.WriteLine("5: List Hotels with star rating 3");
            Console.WriteLine("6: Public API Query");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }

        public void PrintHotels(List<Hotel> hotels)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotels");
            Console.WriteLine("--------------------------------------------");
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.Id + ": " + hotel.Name);
            }
            Console.WriteLine("---");
        }

        public void PrintHotel(Hotel hotel)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotel Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + hotel.Id);
            Console.WriteLine(" Name: " + hotel.Name);
            Console.WriteLine(" Stars: " + hotel.Stars);
            Console.WriteLine(" Rooms Available: " + hotel.RoomsAvailable);
            Console.WriteLine(" Cover Image: " + hotel.CoverImage);
            Console.WriteLine("---");
        }

        public void PrintReviews(List<Review> reviews)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Review Details");
            Console.WriteLine("--------------------------------------------");
            foreach (Review review in reviews)
            {
                Console.WriteLine(" Hotel Id: " + review.HotelId);
                Console.WriteLine(" Title: " + review.Title);
                Console.WriteLine(" Review: " + review.ReviewText);
                Console.WriteLine(" Author: " + review.Author);
                Console.WriteLine(" Stars: " + review.Stars);
                Console.WriteLine("---");
            }
        }

        public void PrintCity(City city)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("City Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Full Name: " + city.FullName);
            Console.WriteLine(" Geoname Id: " + city.GeonameId);
            Console.WriteLine($" Population: {city.Population:###,###,##0}");
            Console.WriteLine("---");
        }
    }
}
