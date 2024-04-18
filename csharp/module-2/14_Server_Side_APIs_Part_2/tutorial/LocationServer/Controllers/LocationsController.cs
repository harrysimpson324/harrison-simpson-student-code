using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Locations.DAO;
using Locations.Models;

namespace Locations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationDao locationDao;

        public LocationsController(ILocationDao locationDao)
        {
            this.locationDao = locationDao;
        }

        [HttpGet]
        public List<Location> List()
        {
            return locationDao.GetLocations();
        }

        [HttpGet("{id}")]
        public ActionResult<Location> Get(int id)
        {
            Location location = locationDao.GetLocationById(id);
            if (location != null)
            {
                return Ok(location);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public Location Add(Location location)
        {
            Location returnLocation = locationDao.CreateLocation(location);
            return returnLocation;
        }
    }
}
