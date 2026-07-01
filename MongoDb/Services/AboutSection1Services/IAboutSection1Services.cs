using MongoDb.Dtos.AboutSection1Dto;

namespace MongoDb.Services.AboutSection1Services
{
    public interface IAboutSection1Services
    {
        Task<List<ResultAboutSection1Dto>> GetAllAboutSection1Asyn();
        Task CreateAboutSection1Asyn(CreateAboutSection1Dto createAboutSection1Dto);
        Task UpdateAboutSection1Asyn(UpdateAboutSection1Dto updateAboutSection1Dto);
    }
}
