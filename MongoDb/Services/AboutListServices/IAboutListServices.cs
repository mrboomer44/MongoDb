using MongoDb.Dtos.AboutListDto;

namespace MongoDb.Services.AboutListServices
{
    public interface IAboutListServices
    {
        Task<List<ResultAboutListDto>> GetAllAboutListAsyn();
        Task CreateAboutListAsyn(CreateAboutListDto createAboutListDto);
        Task UpdateAboutListAsyn(UpdateAboutListDto updateAboutListDto);
        Task DeleteAboutListAsyn(string id);
        Task<GetAboutListByIdDto> GetAboutListByIdDto(string id);
    }
}
