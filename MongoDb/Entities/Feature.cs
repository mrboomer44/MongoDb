using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDb.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
