using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDb.Entities
{
    public class StoryVideo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StoryVideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
