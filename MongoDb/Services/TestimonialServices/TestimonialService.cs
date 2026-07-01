using MongoDb.Dtos.TestimonialDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = Database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }
        public async Task CreateTestimonialAsyn(CreateTestimonialDto TestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(TestimonialDto);
            await _testimonialCollection.InsertOneAsync(value);
        }

        public async Task DeleteTestimonialAsyn(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsyn()
        {
            var values = await _testimonialCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTestimonialByIdDto>(value);
        }

        public async Task UpdateTestimonialAsyn(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == updateTestimonialDto.TestimonialId, value);
        }
    }
}
