using Database.CacheModels;
using Slowpoke.Services.LocationServiceManager;
using System.Collections.Generic;

namespace Slowpoke.Services
{
    public class LocationService
    {
        LocationManager _manager;
        public LocationService()
        {
            _manager = new LocationManager();
        }

        public List<CacheLocation> GetAllLocations()
        {
            return _manager.GetAllLocations();
        }

        public void StoreLocation(CacheLocation location)
        {
            _manager.StoreLocation(location);
        }
    }
}
