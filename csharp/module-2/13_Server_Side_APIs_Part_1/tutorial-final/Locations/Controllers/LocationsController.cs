using Locations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private static List<Location> locations = new List<Location>();
        public LocationsController()
        {
            if (locations.Count == 0)
            {
                locations.Add(new Location(1,
                    "Baker Electric Building",
                    "7100 Euclid Ave #14",
                    "Cleveland",
                    "OH",
                    "44103"));
                locations.Add(new Location(2,
                    "Rev1 Ventures",
                    "1275 Kinnear Rd #121",
                    "Columbus",
                    "OH",
                    "43212"));
                locations.Add(new Location(3,
                    "HCDC Business Center",
                    "1776 Mentor Ave Suite 355",
                    "Cincinnati",
                    "OH",
                    "45212"));
                locations.Add(new Location(4,
                    "House of Metal",
                    "901 Pennsylvania Ave #3",
                    "Pittsburgh",
                    "PA",
                    "15233"));
                locations.Add(new Location(5,
                    "TechTown Detroit",
                    "440 Burroughs St #316",
                    "Detroit",
                    "MI",
                    "48202"));
                locations.Add(new Location(6,
                    "Duane Morris Plaza",
                    "30 S 17th St",
                    "Philadelphia",
                    "PA",
                    "19103"));
            }
        }

        [HttpGet]
        public List<Location> List()
        {
            return locations;
        }

        [HttpPost]
        public Location Add(Location location)
        {
            if (location != null)
            {
                locations.Add(location);
                return location;
            }
            return null;
        }

        [HttpGet("{id}")]
        public Location Get(int id)
        {
            foreach (Location location in locations)
            {
                if (location.Id == id)
                {
                    return location;
                }
            }
            return null;
        }
    }
}
