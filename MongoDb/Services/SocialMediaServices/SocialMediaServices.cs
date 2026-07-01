using MongoDb.Dtos.SocialMediaDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.SocialMediaServices
{
    public class SocialMediaServices : ISocialMediaServices
    {
        private readonly IMongoCollection<SocialMedia> _socialMediaCollection;
        private readonly IMapper _mapper;

        public SocialMediaServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _socialMediaCollection = Database.GetCollection<SocialMedia>(_databaseSettings.SocialMediaCollectionName);
            _mapper = mapper;
        }
        public async Task CreateSocialMediaAsyn(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            await _socialMediaCollection.InsertOneAsync(value);
        }
        public async Task<List<ResultSocialMediaDto>> GetAllSocialMediaAsyn()
        {
            var values = await _socialMediaCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSocialMediaDto>>(values);
        }
        public async Task UpdateSocialMediaAsyn(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            await _socialMediaCollection.ReplaceOneAsync(x => x.SocialMediaId == updateSocialMediaDto.SocialMediaId, value);
        }
    }
}
