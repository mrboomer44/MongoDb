using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Entities
{
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
