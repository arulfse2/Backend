using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace COVID19Tracker.Core.Entities
{
    public class User : Domain
    {
        //[BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonElement]
        [BsonRequired]
        public string UserId { get; set; }
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
