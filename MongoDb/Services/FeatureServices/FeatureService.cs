using MongoDb.Dtos.FeatureDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featuresCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featuresCollection = Database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsyn(CreateFeatureDto cteateFeatureDto)
        {
            var value = _mapper.Map<Feature>(cteateFeatureDto);
            await _featuresCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsyn(string id)
        {
            await _featuresCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsyn()
        {
            var values = await _featuresCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetFeatureByIdDto> GetFeatureByIdDto(string id)
        {
            var value = await _featuresCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureByIdDto>(value);
        }

        public Task UpdateFeatureAsyn(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            return _featuresCollection.ReplaceOneAsync(x => x.FeatureId == updateFeatureDto.FeatureId, value);
        }

    }
}
