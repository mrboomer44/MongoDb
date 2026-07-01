using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Entities
{
    [BsonIgnoreExtraElements]
    public class AboutList
    {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string AboutListId { get; set; }
            public string Title { get; set; }
    }
}
