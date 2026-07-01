using MongoDb.Dtos.AboutSection2Dto;

namespace MongoDb.Services.AboutSection2Services
{
    public interface IAboutSection2Services
    {
        Task<List<ResultAboutSection2Dto>> GetAllAboutSection2Asyn();
        Task CreateAboutSection2Asyn(CreateAboutSection2Dto createAboutSection2Dto);
        Task UpdateAboutSection2Asyn(UpdateAboutSection2Dto updateAboutSection2Dto);
    }
}
