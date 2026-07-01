using MongoDb.Dtos.AboutSection2Dto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.AboutSection2Services
{
    public class AboutSection2Services : IAboutSection2Services
    {
        private readonly IMongoCollection<AboutSection2> _aboutSection2Collection;
        private readonly IMapper _mapper;

        public AboutSection2Services(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutSection2Collection = Database.GetCollection<AboutSection2>(_databaseSettings.AboutSecition2CollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutSection2Asyn(Dtos.AboutSection2Dto.CreateAboutSection2Dto createAboutSection2Dto)
        {
            var value = _mapper.Map<AboutSection2>(createAboutSection2Dto);
            await _aboutSection2Collection.InsertOneAsync(value);
        }
        public async Task<List<ResultAboutSection2Dto>> GetAllAboutSection2Asyn()
        {
            var values = await _aboutSection2Collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutSection2Dto>>(values);
        }
        public Task UpdateAboutSection2Asyn(Dtos.AboutSection2Dto.UpdateAboutSection2Dto updateAboutSection2Dto)
        {
            var value = _mapper.Map<AboutSection2>(updateAboutSection2Dto);
            return _aboutSection2Collection.ReplaceOneAsync(x => x.AboutSection2Id == updateAboutSection2Dto.AboutSection2Id, value);
        }
    }
}
