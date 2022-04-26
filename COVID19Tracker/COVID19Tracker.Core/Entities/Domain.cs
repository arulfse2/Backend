using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace COVID19Tracker.Core.Entities
{
    public class Domain
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        [BsonDefaultValue("ADMIN")]
        public string CreatedBy { get; set; }
        [BsonElement]
        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Local)]
        public DateTime? CreatedDate { get; set; }
        [BsonElement]
        [BsonDefaultValue("ADMIN")]
        public string ModifiedBy { get; set; }
        [BsonElement]
        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Local)]
        public DateTime? ModifiedDate { get; set; }
    }
}
