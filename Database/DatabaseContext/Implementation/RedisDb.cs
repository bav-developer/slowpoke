using Database.CacheModels;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Database.DatabaseContext
{
    public class RedisDb : ICacheDb
    {
        private readonly string _redistHost;
        private readonly RedisManagerPool _manager;
        public RedisDb()
        {
            _redistHost = "localhost:6379";
            _manager = new RedisManagerPool(_redistHost);
        }

        public void Write(CacheEntity entity)
        {
            using (var client = _manager.GetClient())
            {
                var redisValue = JsonConvert.SerializeObject(entity);
                //client.RemoveItemFromSortedSet()
            }
        }

        public T Read<T>(string key) where T : CacheEntity
        {
            using (var client = _manager.GetClient())
            {
                return client.Get<T>(key);
            }
        }

        public IEnumerable<T> All<T>() where T: CacheEntity, new()
        {
            var collectionKey = new T().CollectionKey;

            using (var client = _manager.GetClient())
            {
                var jsonValues = client.GetAllItemsFromList(collectionKey);
                var deserializedEntities = jsonValues.Select(x => JsonConvert.DeserializeObject<T>(x));
                return deserializedEntities;
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
