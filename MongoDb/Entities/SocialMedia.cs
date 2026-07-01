using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Entities
{
    public class SocialMedia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SocialMediaId { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
    }
}
