using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace COVID19Tracker.Core.Entities
{
    public class User : Domain
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonRequired]
        public Guid Id { get; set; }
        [BsonElement]
        [BsonRequired]
        public string FirstName { get; set; }
        [BsonElement]
        public string LastName { get; set; }
        [BsonElement]
        [BsonRequired]
        public string Email { get; set; }
        [BsonElement]
        [BsonRequired]
        public string Password { get; set; }
        [BsonElement]
        public int? Phone { get; set; }
        [BsonElement]
        [BsonDefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
