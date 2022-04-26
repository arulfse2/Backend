using MongoDB.Bson.Serialization.Attributes;
using System;

namespace COVID19Tracker.Core.Entities
{
    public class CovidInfo : Domain
    {
        [BsonElement]
        [BsonRequired]
        public string InfoId { get; set; }
        [BsonElement]
        [BsonRequired]
        public string CountryId { get; set; }
        [BsonElement]
        [BsonRequired]
        public string StateId { get; set; }
        [BsonElement]
        [BsonRequired]
        public string CityId { get; set; }
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
