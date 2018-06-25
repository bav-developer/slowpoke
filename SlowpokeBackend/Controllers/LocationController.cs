using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.CacheModels;
using Database.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Slowpoke.Services;

namespace SlowpokeBackend.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private LocationService _locationService;

        public LocationController()
        {
            _locationService = new LocationService();
        }

        [HttpGet]
        public IEnumerable<CacheLocation> Get()
        {
            return _locationService.GetAllLocations();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]CacheLocation value)
        {
            _locationService.StoreLocation(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
