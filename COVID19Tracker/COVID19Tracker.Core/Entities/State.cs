using MongoDB.Bson.Serialization.Attributes;

namespace COVID19Tracker.Core.Entities
{
    public class State : Domain
    {
        [BsonElement]
        [BsonRequired]
        public string StateId { get; set; }
        [BsonElement]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement]
        [BsonRequired]
        public string CountryId { get; set; }
        [BsonElement]
        [BsonDefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
