using MongoDb.Dtos.AboutSection1Dto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.AboutSection1Services
{
    public class AboutSection1Services : IAboutSection1Services
    {
        private readonly IMongoCollection<AboutSection1> _aboutSection1Collection;
        private readonly IMapper _mapper;

        public AboutSection1Services(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutSection1Collection = Database.GetCollection<AboutSection1>(_databaseSettings.AboutSecition1CollectionName);
            _mapper = mapper;
        }
        public async Task CreateAboutSection1Asyn(Dtos.AboutSection1Dto.CreateAboutSection1Dto createAboutSection1Dto)
        {
            var value = _mapper.Map<AboutSection1>(createAboutSection1Dto);
            await _aboutSection1Collection.InsertOneAsync(value);
        }
        public async Task<List<ResultAboutSection1Dto>> GetAllAboutSection1Asyn()
        {
            var values = await _aboutSection1Collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutSection1Dto>>(values);
        }
        public Task UpdateAboutSection1Asyn(Dtos.AboutSection1Dto.UpdateAboutSection1Dto updateAboutSection1Dto)
        {
            var value = _mapper.Map<AboutSection1>(updateAboutSection1Dto);
            return _aboutSection1Collection.ReplaceOneAsync(x => x.AboutSection1Id == updateAboutSection1Dto.AboutSection1Id, value);
        }
    }
}
