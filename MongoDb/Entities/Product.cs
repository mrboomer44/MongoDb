using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDb.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotlalTime { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
