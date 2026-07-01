using MongoDb.Dtos.FaqDto;

namespace MongoDb.Services.FaqServices
{
    public interface IFaqServices
    {
        Task<List<ResultFaqDto>> GetAllFaqAsyn();
        Task CreateFaqAsyn(CreateFaqDto createFaqDto);
        Task UpdateFaqAsyn(UpdateFaqDto updateFaqDto);
        Task DeleteFaqAsyn(string id);
        Task<GetFaqByIdDto> GetFaqByIdDto(string id);
    }
}
