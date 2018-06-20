using Database.CacheModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.DatabaseContext
{
    public interface ICacheDb
    {
        void Write(CacheEntity entity);
        T Read<T>(string key) where T: CacheEntity;
        IEnumerable<T> All<T>() where T : CacheEntity, new();
    }
}
