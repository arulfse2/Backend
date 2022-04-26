using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace COVID19Tracker.Core.Entities
{
    public class Role : Domain
    {
        //[BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonElement]
        [BsonRequired]
        public string RoleId { get; set; }
        [BsonElement]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement]
        [BsonDefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
