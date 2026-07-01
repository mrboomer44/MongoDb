using MongoDb.Dtos.StoryVideoDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.StoryVideoServices
{
    public class StoryVideoServices : IStoryVideoServices
    {
        private readonly IMongoCollection<StoryVideo> _storyVideoCollection;
        private readonly IMapper _mapper;
        public StoryVideoServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _storyVideoCollection = Database.GetCollection<StoryVideo>(_databaseSettings.StoryVideoCollectionName);
            _mapper = mapper;
        }
        public async Task CreateStoryVideoAsyn(CreateStoryVideoDto createStoryVideoDto)
        {
            var value = _mapper.Map<StoryVideo>(createStoryVideoDto);
            await _storyVideoCollection.InsertOneAsync(value);
        }
        public async Task<List<ResultStoryVideoDto>> GetAllStoryVideosAsyn()
        {
            var values = await _storyVideoCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultStoryVideoDto>>(values);
        }
        public Task UpdateStoryVideoAsyn(UpdateStoryVideoDto updateStoryVideoDto)
        {
            var value = _mapper.Map<StoryVideo>(updateStoryVideoDto);
            return _storyVideoCollection.ReplaceOneAsync(x => x.StoryVideoId == updateStoryVideoDto.StoryVideoId, value);
        }
    }
}
