using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Database.CacheModels
{
    public abstract class CacheEntity
    {
        [IgnoreDataMember]
        public virtual string Key { get; }

        [IgnoreDataMember]
        public virtual string CollectionKey {get;}
    }
}
