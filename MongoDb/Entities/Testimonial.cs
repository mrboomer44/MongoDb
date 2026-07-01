using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDb.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string NameSurnama { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
