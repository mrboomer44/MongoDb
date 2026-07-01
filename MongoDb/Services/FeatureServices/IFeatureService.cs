using MongoDb.Dtos.FeatureDto;

namespace MongoDb.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsyn();
        Task CreateFeatureAsyn(CreateFeatureDto cteateFeatureDto);
        Task UpdateFeatureAsyn(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsyn(string id);
        Task<GetFeatureByIdDto> GetFeatureByIdDto(string id);
    }
}