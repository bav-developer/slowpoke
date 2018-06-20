using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Database.CacheModels
{
    public class CacheLocation : CacheEntity
    {
        public Guid Id { get; set; }
        public string Nick { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        [IgnoreDataMember]
        public override string Key => $"{CollectionKey}/{Id.ToString()}";
        [IgnoreDataMember]
        public override string CollectionKey => "Locations";
    }
}
