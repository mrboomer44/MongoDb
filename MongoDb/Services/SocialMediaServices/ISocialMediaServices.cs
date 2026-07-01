using MongoDb.Dtos.SocialMediaDto;

namespace MongoDb.Services.SocialMediaServices
{
    public interface ISocialMediaServices
    {
        Task<List<ResultSocialMediaDto>> GetAllSocialMediaAsyn();
        Task CreateSocialMediaAsyn(CreateSocialMediaDto createSocialMediaDto);
        Task UpdateSocialMediaAsyn(UpdateSocialMediaDto updateSocialMediaDto);
    }
}
