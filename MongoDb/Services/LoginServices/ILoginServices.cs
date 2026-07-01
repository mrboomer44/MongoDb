using MongoDb.Dtos.FeatureDto;
using MongoDb.Dtos.LoginDto;

namespace MongoDb.Services.LoginServices
{
    public interface ILoginServices
    {
        Task<List<ResultLoginDto>> GetAllLoginsAsync();
        Task CreateLoginAsync(CreateLoginDto createLoginDto);
        Task UpdateLoginAsync(UpdateLoginDto updateLoginDto);
        Task<GetLoginByIdDto> GetLoginByIdDto(string id);
    }
}
