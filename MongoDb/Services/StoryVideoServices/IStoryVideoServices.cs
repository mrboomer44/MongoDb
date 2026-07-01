using MongoDb.Dtos.StoryVideoDto;

namespace MongoDb.Services.StoryVideoServices
{
    public interface IStoryVideoServices
    {
        Task<List<ResultStoryVideoDto>> GetAllStoryVideosAsyn();
        Task CreateStoryVideoAsyn(CreateStoryVideoDto createStoryVideoDto);
        Task UpdateStoryVideoAsyn(UpdateStoryVideoDto updateStoryVideoDto);
    }
}
