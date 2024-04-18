using System;
using System.Collections.Generic;
using HotelReservations.Models;

namespace HotelReservations.DAO
{
    public class HotelMemoryDao : IHotelDao
    {
        // Each request of the controller may create a new instance of the DAO.
        // This static is to preserve the data on each request until we get to dependency injection
        private static List<Hotel> Hotels { get; set; }

        public HotelMemoryDao()
        {
            if (Hotels == null)
            {
                Hotels = new List<Hotel>
                {
                    new Hotel(1, "Aloft Cleveland", new Address("1111 W 10th St", "", "Cleveland", "Ohio", "44113"), 3, 48, 274, "aloft-cleveland.webp"),
                    new Hotel(2, "Hilton Cleveland Downtown", new Address("100 Lakeside Ave", "", "Cleveland", "Ohio", "44114"), 4, 12, 287, "hilton-cleveland.webp"),
                    new Hotel(3, "Metropolitan at the 9", new Address("2017 E 9th St", "", "Cleveland", "Ohio", "44115"), 4, 22, 319, "metropolitan-cleveland.webp"),
                    new Hotel(4, "The Westin Pittsburgh", new Address("1000 Penn Ave", "", "Pittsburgh", "Pennsylvania", "15222"), 4, 60, 131, "westin-pittsburgh.webp"),
                    new Hotel(5, "Hilton Columbus Downtown", new Address("401 N High St", "", "Columbus", "Ohio", "43215"), 4, 43, 190, "hilton-columbus.webp"),
                    new Hotel(6, "The Summit A Dolce Hotel", new Address("5345 Medpace Way", "", "Cincinnati", "Ohio", "43215"), 4, 43, 218, "summit-cincinnati.webp"),
                    new Hotel(7, "Greektown Detroit", new Address("1200 St Antoine St", "", "Detroit", "Michigan", "48226"), 4, 75, 185, "greektown-detroit.webp")
                };
            }
        }

        public List<Hotel> GetHotels()
        {
            return Hotels;
        }

        public List<Hotel> GetHotelsByStateAndCity(string state, string city)
        {
            List<Hotel> filteredHotels = new List<Hotel>();

            if (String.IsNullOrEmpty(state) && String.IsNullOrEmpty(city))
            {
                return GetHotels();
            }

            foreach (Hotel hotel in Hotels)
            {
                // if city was passed we don't care about the state filter
                if (!String.IsNullOrEmpty(city))
                {
                    if (hotel.Address.City.ToLower().Equals(city.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
                else
                {
                    if (hotel.Address.State.ToLower().Equals(state.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
            }
            return filteredHotels;
        }

        public Hotel GetHotelById(int id)
        {
            foreach (Hotel hotel in Hotels)
            {
                if (hotel.Id == id)
                {
                    return hotel;
                }
            }

            return null;
        }
    }
}
