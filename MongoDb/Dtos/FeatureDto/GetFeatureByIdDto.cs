namespace MongoDb.Dtos.FeatureDto
{
    public class GetFeatureByIdDto
    {
        public string FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
