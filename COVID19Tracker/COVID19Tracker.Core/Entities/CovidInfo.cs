using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace COVID19Tracker.Core.Entities
{
    public class CovidInfo : Domain
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonRequired]
        public Guid Id { get; set; }
        [BsonElement]
        [BsonRequired]
        public Guid CountryId { get; set; }
        [BsonElement]
        [BsonRequired]
        public Guid StateId { get; set; }
        [BsonElement]
        [BsonRequired]
        public Guid CityId { get; set; }
        [BsonElement]
        [BsonDefaultValue(false)]
        public bool? IsTested { get; set; }
        [BsonElement]
        [BsonDefaultValue(false)]
        public bool? IsConfirmed { get; set; }
        [BsonElement]
        [BsonDefaultValue(false)]
        public bool? IsQuarantined { get; set; }
        [BsonElement]
        [BsonDefaultValue(false)]
        public bool? IsRecovered { get; set; }
        [BsonElement]
        [BsonDefaultValue(false)]
        public bool? IsDeceased { get; set; }
        [BsonElement]
        [BsonDateTimeOptions(DateOnly = true, Kind = DateTimeKind.Local)]
        public DateTime? Date { get; set; }
        [BsonElement]
        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Local)]
        public DateTime? Time { get; set; }
    }
}
