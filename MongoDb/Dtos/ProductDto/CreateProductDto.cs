namespace MongoDb.Dtos.ProductDto
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public int TotlalTime { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
