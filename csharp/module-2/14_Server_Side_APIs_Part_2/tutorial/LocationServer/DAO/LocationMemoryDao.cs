using System.Collections.Generic;
using Locations.Exceptions;
using Locations.Models;

namespace Locations.DAO
{
    public class LocationMemoryDao : ILocationDao
    {
        private static List<Location> locations { get; set; }

        public LocationMemoryDao()
        {
            InitializeLocationData();
        }

        private void InitializeLocationData()
        {
            if (locations == null || locations.Count == 0)
            {
                locations = new List<Location>
                {
                    new Location(1, "Baker Electric Building", "7100 Euclid Ave #14", "Cleveland", "OH", "44103"),
                    new Location(2, "Rev1 Ventures", "1275 Kinnear Rd #121", "Columbus", "OH", "43212"),
                    new Location(3, "HCDC Business Center", "1776 Mentor Ave Suite 355", "Cincinnati", "OH", "45212"),
                    new Location(4, "House of Metal", "901 Pennsylvania Ave #3", "Pittsburgh", "PA", "15233"),
                    new Location(5, "TechTown Detroit", "440 Burroughs St #316", "Detroit", "MI", "48202"),
                    new Location(6, "Duane Morris Plaza", "30 S 17th St", "Philadelphia", "PA", "19103")
                };
            }
        }

        public List<Location> GetLocations()
        {
            return locations;
        }

        public Location GetLocationById(int id)
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

        public Location CreateLocation(Location location)
        {
            if (location.IsValid)
            {
                location.Id = GetNextId();
                locations.Add(location);
                return location;
            }
            return null;
        }

        public Location UpdateLocation(Location updated)
        {
            if (updated.IsValid)
            {
                Location old = GetLocationById(updated.Id);
                if (old != null)
                {
                    updated.Id = old.Id;
                    locations.Remove(old);
                    locations.Add(updated);
                    return updated;
                }

                throw new DaoException("Location to update not found");
            }

            throw new DaoException("Location to update is invalid");
        }

        public int DeleteLocationById(int id)
        {
            Location location = GetLocationById(id);
            if (location != null)
            {
                locations.Remove(location);
                return 1;
            }
            return 0;
        }

        private int GetNextId()
        {
            int maxId = 0;
            foreach (Location loc in locations)
            {
                if (loc.Id > maxId)
                {
                    maxId = loc.Id;
                }
            }
            return maxId + 1;
        }
    }
}
