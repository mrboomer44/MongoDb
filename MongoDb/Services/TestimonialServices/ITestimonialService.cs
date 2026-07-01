using MongoDb.Dtos.TestimonialDto;

namespace MongoDb.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsyn();
        Task CreateTestimonialAsyn(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsyn(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteTestimonialAsyn(string id);
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id);
    }
}
