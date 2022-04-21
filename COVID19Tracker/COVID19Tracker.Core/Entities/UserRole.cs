using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace COVID19Tracker.Core.Entities
{
    public class UserRole : Domain
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonRequired]
        public Guid Id { get; set; }
        [BsonElement]
        [BsonRequired]
        public Guid UserId { get; set; }
        [BsonElement]
        [BsonRequired]
        public Guid RoleId { get; set; }
        [BsonElement]
        [BsonDefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}