namespace Slowpoke.Services.LocationServiceManager
{

    using Database.CacheModels;
    using Database.DatabaseContext;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LocationManager
    {
        public readonly RedisLocationDb _db;
        public LocationManager()
        {
            _db = new RedisLocationDb();
        }
        public void StoreLocation(CacheLocation location)
        {
            _db.Write(location);
        }

        public List<CacheLocation> GetAllLocations()
        {
            //return _db.All<CacheLocation>().Take(10).ToList();
            return null;
        }
    }
}
