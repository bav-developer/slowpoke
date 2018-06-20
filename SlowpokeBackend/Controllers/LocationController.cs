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
        // GET api/values
        [HttpGet]
        public IEnumerable<CacheLocation> Get()
        {
            return _locationService.GetAllLocations();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]CacheLocation value)
        {
            _locationService.StoreLocation(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
