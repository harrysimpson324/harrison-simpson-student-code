using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Locations.DAO;
using Locations.Models;
using Locations.Exceptions;

namespace Locations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationDao locationDao;

        public LocationsController(ILocationDao locationDao)
        {
            this.locationDao = locationDao;
        }

        [AllowAnonymous]
        [HttpGet("/")]
        public ActionResult<object> OpenEndpoint()
        {
            return Ok(new { message = "Welcome to Locations!", description = "This is an open endpoint. To reach any other endpoint in this API, you must be authenticated." });
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
        public ActionResult<Location> Add(Location location)
        {
            Location returnLocation = locationDao.CreateLocation(location);
            return Created($"/locations/{returnLocation.Id}", returnLocation);
        }

        [HttpPut("{id}")]
        public ActionResult<Location> Update(int id, Location location)
        {
            // The id on the URL takes precedence over the id in the request body, if any
            location.Id = id;

            try
            {
                Location result = locationDao.UpdateLocation(location);
                return Ok(result);
            }
            catch (DaoException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            int numDeleted = locationDao.DeleteLocationById(id);
            if (numDeleted == 1)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
