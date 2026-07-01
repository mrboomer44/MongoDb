using MongoDb.Dtos.AboutListDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.AboutListServices
{
    public class AboutListServices : IAboutListServices
    {
        private readonly IMongoCollection<AboutList> _aboutListsCollection;
        private readonly IMapper _mapper;

        public AboutListServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutListsCollection = Database.GetCollection<AboutList>(_databaseSettings.AboutListCollectionName);
            _mapper = mapper;
        }
        public async Task CreateAboutListAsyn(Dtos.AboutListDto.CreateAboutListDto createAboutListDto)
        {
            var value = _mapper.Map<AboutList>(createAboutListDto);
            await _aboutListsCollection.InsertOneAsync(value);
        }
        public async Task DeleteAboutListAsyn(string id)
        {
            await _aboutListsCollection.DeleteOneAsync(x => x.AboutListId == id);
        }
        public async Task<List<ResultAboutListDto>> GetAllAboutListAsyn()
        {
            var values = await _aboutListsCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutListDto>>(values);
        }
        public async Task<GetAboutListByIdDto> GetAboutListByIdDto(string id)
        {
            var value = await _aboutListsCollection.Find(x => x.AboutListId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetAboutListByIdDto>(value);
        }
        public Task UpdateAboutListAsyn(Dtos.AboutListDto.UpdateAboutListDto updateAboutListDto)
        {
            var value = _mapper.Map<AboutList>(updateAboutListDto);
            return _aboutListsCollection.ReplaceOneAsync(x => x.AboutListId == updateAboutListDto.AboutListId, value);
        }
    }
}
