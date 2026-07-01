using MongoDb.Dtos.OrderDto;

namespace MongoDb.Services.OrderServices
{
    public interface IOrderServices
    {
        Task<List<ResultOrderDto>> GetAllOrdersAsyn();
        Task CreateOrderAsyn(CreateOrderDto createOrderDto);
        Task DeleteOrderAsyn(string id);
        Task<GetOrderByIdDto> GetOrderByIdDto(string id);
    }
}
