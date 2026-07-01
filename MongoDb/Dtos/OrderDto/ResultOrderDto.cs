namespace MongoDb.Dtos.OrderDto
{
    public class ResultOrderDto
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
