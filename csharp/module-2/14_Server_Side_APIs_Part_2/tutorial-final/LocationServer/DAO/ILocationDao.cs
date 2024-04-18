using System.Collections.Generic;
using Locations.Models;

namespace Locations.DAO
{
    public interface ILocationDao
    {
        List<Location> GetLocations();

        Location GetLocationById(int id);

        Location CreateLocation(Location location);

        Location UpdateLocation(Location location);

        int DeleteLocationById(int id);
    }
}
