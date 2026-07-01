namespace MongoDb.Dtos.FaqDto
{
    public class GetFaqByIdDto
    {
        public string FaqId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
