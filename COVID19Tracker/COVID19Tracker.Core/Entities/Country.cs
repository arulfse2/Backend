using MongoDB.Bson.Serialization.Attributes;

namespace COVID19Tracker.Core.Entities
{
    public class Country : Domain
    {
        [BsonElement]
        [BsonRequired]
        public string CountryId { get; set; }
        [BsonElement]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement]
        [BsonDefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
