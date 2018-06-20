using Database.CacheModels;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Database.DatabaseContext
{
    public class RedisLocationDb
    {
        private const string _locationsKey = "Locations";
        private readonly string _redistHost;
        private readonly RedisManagerPool _manager;
        public RedisLocationDb()
        {
            _redistHost = "localhost:6379";
            _manager = new RedisManagerPool(_redistHost);
        }

        public void Write(CacheLocation entity)
        {
            using (var client = _manager.GetClient())
            {
                client.Set(entity.Key, entity.Nick, DateTime.Now.AddSeconds(30));
                client.AddGeoMember("Sicily", entity.Lng, entity.Lat, entity.Key);
                var sub = client.CreateSubscription();
                sub.SubscribeToChannels(entity.Key);
                sub.OnMessage = (x, y) =>
                {
                    var s = x + y;
                };
            }
        }

        public IEnumerable<CacheLocation> GetMembersByRadius(CacheLocation currentUserLocation, double radiusInMeters = 1000)
        {
            using (var client = _manager.GetClient())
            {
                var result = client.FindGeoMembersInRadius(_locationsKey, currentUserLocation.Lng, currentUserLocation.Lat, radiusInMeters, "m");
                return result.Select(x => JsonConvert.DeserializeObject<CacheLocation>(x));
            }
        }

        public void Remove(CacheLocation entity)
        {
            using (var client = _manager.GetClient())
            {
                var redisValue = JsonConvert.SerializeObject(entity);
                client.RemoveItemFromSortedSet(_locationsKey, redisValue);
            }
        }

        //public void Read(string key)
        //{
        //    using (var client = _manager.GetClient())
        //    {
        //        return client.RemoveItemFromList(;
        //    }
        //}

    }
}
