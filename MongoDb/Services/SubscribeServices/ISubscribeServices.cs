using MongoDb.Dtos.SubscribeDto;

namespace MongoDb.Services.SubscribeServices
{
    public interface ISubscribeServices
    {
        Task<List<ResultSubscribeDto>> GetAllSubscribeAsyn();
        Task CreateSubscribeAsyn(CreateSubscribeDto createSubscribeDto);
        Task DeleteSubscribeAsyn(string id);
    }
}
