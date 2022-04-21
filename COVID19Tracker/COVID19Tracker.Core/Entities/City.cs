using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace COVID19Tracker.Core.Entities
{
    public class City : Domain
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonRequired]
        public Guid Id { get; set; }
        [BsonElement]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement]
        [BsonRequired]
        public Guid CountryId { get; set; }
        [BsonElement]
        [BsonRequired]
        public Guid StateId { get; set; }
        [BsonElement]
        [BsonDefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
