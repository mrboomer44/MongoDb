using MongoDb.Dtos.SubscribeDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.SubscribeServices
{
    public class SubscribeServices : ISubscribeServices
    {
        private readonly IMongoCollection<Subscribe> _subscribeCollection;
        private readonly IMapper _mapper;
        public SubscribeServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _subscribeCollection = Database.GetCollection<Subscribe>(_databaseSettings.SubscribeCollectionName);
            _mapper = mapper;
        }
        public async Task CreateSubscribeAsyn(CreateSubscribeDto createSubscribeDto)
        {
            var value = _mapper.Map<Subscribe>(createSubscribeDto);
            await _subscribeCollection.InsertOneAsync(value);
        }
        public async Task DeleteSubscribeAsyn(string id)
        {
            await _subscribeCollection.DeleteOneAsync(x => x.SubscribeId == id);
        }
        public async Task<List<ResultSubscribeDto>> GetAllSubscribeAsyn()
        {
            var values = await _subscribeCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSubscribeDto>>(values);
        }
    }
}
