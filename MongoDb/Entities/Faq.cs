using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Entities
{
    public class Faq
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FaqId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
