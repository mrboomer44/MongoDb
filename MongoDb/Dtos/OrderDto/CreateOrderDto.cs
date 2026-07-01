namespace MongoDb.Dtos.OrderDto
{
    public class CreateOrderDto
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
