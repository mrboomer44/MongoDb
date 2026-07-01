using MongoDb.Dtos.FaqDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.FaqServices
{
    public class FaqServices : IFaqServices
    {
        private readonly IMongoCollection<Faq> _faqCollection;
        private readonly IMapper _mapper;

        public FaqServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _faqCollection = Database.GetCollection<Faq>(_databaseSettings.FaqCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFaqAsyn(CreateFaqDto createFaqDto)
        {
            var value = _mapper.Map<Faq>(createFaqDto);
            await _faqCollection.InsertOneAsync(value);
        }

        public async Task DeleteFaqAsyn(string id)
        {
            await _faqCollection.DeleteOneAsync(x => x.FaqId == id);
        }

        public async Task<List<ResultFaqDto>> GetAllFaqAsyn()
        {
            var values = await _faqCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFaqDto>>(values);
        }

        public async Task<GetFaqByIdDto> GetFaqByIdDto(string id)
        {
            var value = await _faqCollection.Find(x => x.FaqId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFaqByIdDto>(value);
        }

        public Task UpdateFaqAsyn(UpdateFaqDto updateFaqDto)
        {
            var value = _mapper.Map<Faq>(updateFaqDto);
            return _faqCollection.ReplaceOneAsync(x => x.FaqId == updateFaqDto.FaqId, value);
        }

    }
}
