using HotelReservations.Exceptions;
using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("reservations")]
    [ApiController]
    [Authorize]
    public class ReservationsController : ControllerBase
    {
        private IReservationDao reservationDao;
        private IHotelDao hotelDao;
        public ReservationsController(IHotelDao hotelDao, IReservationDao reservationDao)
        {
            this.hotelDao = hotelDao;
            this.reservationDao = reservationDao;
        }

        [HttpGet()]
        public List<Reservation> ListReservations()
        {
            return reservationDao.GetReservations();
        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.GetReservationById(id);

            if (reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/hotels/{hotelId}/reservations")]
        public ActionResult<List<Reservation>> ListReservationsByHotel(int hotelId)
        {
            Hotel hotel = hotelDao.GetHotelById(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return reservationDao.GetReservationsByHotel(hotelId);
        }

        [HttpPost()]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation added = reservationDao.CreateReservation(reservation);
            return Created($"/reservations/{added.Id}", added);
        }

        [HttpPut("{id}")]
        public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            // The id on the URL takes precedence over the one in the payload, if any
            reservation.Id = id;

            try
            {
                Reservation result = reservationDao.UpdateReservation(reservation);
                return Ok(result);
            }
            catch (DaoException)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            int numDeleted = reservationDao.DeleteReservationById(id);
            if (numDeleted == 1)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
