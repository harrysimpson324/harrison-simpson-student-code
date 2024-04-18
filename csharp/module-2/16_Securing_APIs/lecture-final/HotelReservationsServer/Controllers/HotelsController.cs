using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.DAO;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservations.Controllers
{
    [Route("hotels")]
    [ApiController]
    [Authorize]
    public class HotelsController : ControllerBase
    {
        private IHotelDao hotelDao;

        public HotelsController(IHotelDao hotelDao)
        {
            this.hotelDao = hotelDao;
        }

        /**
        * /hotels
        * /hotels?state=ohio
        * /hotels?state=ohio&city=cleveland
        *
        * @param state the state to filter by
        * @param city  the city to filter by
        * @return a list of hotels that match the city & state
        */

        [AllowAnonymous]
        [HttpGet()]
        public List<Hotel> ListHotels(string state = "", string city = "")
        {
            return hotelDao.GetHotelsByStateAndCity(state, city);
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            Hotel hotel = hotelDao.GetHotelById(id);

            if (hotel != null)
            {
                return hotel;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
