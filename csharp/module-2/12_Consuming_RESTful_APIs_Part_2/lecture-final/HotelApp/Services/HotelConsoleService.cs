using HotelReservationsClient.Models;
using System;
using System.Collections.Generic;

namespace HotelReservationsClient.Services
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
            Console.WriteLine("2: List Reservations for Hotel");
            Console.WriteLine("3: Create new Reservation for Hotel");
            Console.WriteLine("4: Update existing Reservation for Hotel");
            Console.WriteLine("5: Delete Reservation");
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
        }

        public void PrintReservations(List<Reservation> reservations, int hotelId = -1)
        {
            string msg = hotelId == -1 ? "All Reservations" : "Reservations for hotel: " + hotelId;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(msg);
            Console.WriteLine("--------------------------------------------");
            if (reservations.Count > 0)
            {
                foreach (Reservation reservation in reservations)
                {
                    PrintReservationDetails(reservation);
                }
            }
            else
            {
                Console.WriteLine("There are no reservations for hotel: " + hotelId);
            }
        }

        private void PrintReservationDetails(Reservation reservation)
        {
            Console.WriteLine(
                $" Id: {reservation.Id}\n" +
                $" Hotel Id: {reservation.HotelId}\n" +
                $" Name: {reservation.FullName}\n" +
                $" Check-in Date: {reservation.CheckinDate:d}\n" +
                $" Number of nights: {reservation.Nights}\n" +
                $" Guests: {reservation.Guests}\n"
            );
        }

        /************************************************************
            Validation methods
        ************************************************************/
        public bool IsValidHotelId(List<Hotel> hotels, int hotelId)
        {
            if (hotels == null)
            {
                return false;
            }
            foreach (Hotel hotel in hotels)
            {
                if (hotel.Id == hotelId)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsValidReservationId(List<Reservation> reservations, int reservationId)
        {
            if (reservations == null)
            {
                return false;
            }
            foreach (Reservation reservation in reservations)
            {
                if (reservation.Id == reservationId)
                {
                    return true;
                }
            }
            return false;
        }

        /************************************************************
            Prompt methods (get user input)
        ************************************************************/
        public int PromptForHotelId(List<Hotel> hotels, string action)
        {
            PrintHotels(hotels);
            Console.WriteLine();
            while (true)
            {
                int hotelId = PromptForInteger($"Please enter a hotel number to {action}, 0 to cancel");
                if (hotelId == 0)
                {
                    // User cancel
                    return 0;
                }
                if (IsValidHotelId(hotels, hotelId))
                {
                    return hotelId;
                }
                PrintError("This is not a valid hotel number");
            }
        }

        public Reservation PromptForReservationData(int hotelId, Reservation existingReservation = null)
        {
            // 0 is new reservation
            int reservationId = 0;

            // If existing reservation, must use existing reservation Id and same hotel Id
            if (existingReservation != null)
            {
                reservationId = existingReservation.Id;
                hotelId = existingReservation.HotelId;
            }

            // Name
            string name = PromptForString("Full name (Enter to cancel)", existingReservation?.FullName);
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            // Checkin
            DateTime checkin = PromptForDate("Check-in date", existingReservation?.CheckinDate ?? DateTime.Today);

            // Checkout
            int nights = PromptForInteger("Number of nights, up to 14", 1, 14, existingReservation?.Nights ?? 1);

            // Number of guests
            int numberOfGuests = PromptForInteger("Number of guests, up to 5", 1, 5, existingReservation?.Guests ?? 1);

            Reservation reservation = new Reservation(reservationId, hotelId, name, checkin, nights, numberOfGuests);
            return reservation;
        }

        public int PromptForReservationId(List<Reservation> reservations, string action)
        {
            PrintReservations(reservations);
            Console.WriteLine();
            while (true)
            {
                int reservationId = PromptForInteger($"Please enter a reservation number to {action}, 0 to cancel");
                if (reservationId == 0)
                {
                    // User cancel
                    return 0;
                }
                if (IsValidReservationId(reservations, reservationId))
                {
                    return reservationId;
                }
                PrintError("This is not a valid reservation number");
            }
        }
    }
}
