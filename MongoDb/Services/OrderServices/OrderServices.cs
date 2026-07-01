using MongoDb.Dtos.OrderDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IMapper _mapper;

        public OrderServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _orderCollection = Database.GetCollection<Order>(_databaseSettings.OrderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOrderAsyn(CreateOrderDto createOrderDto)
        {
            var value = _mapper.Map<Order>(createOrderDto);
            await _orderCollection.InsertOneAsync(value);
        }

        public async Task DeleteOrderAsyn(string id)
        {
            await _orderCollection.DeleteOneAsync(x => x.OrderId == id);
        }

        public async Task<List<ResultOrderDto>> GetAllOrdersAsyn()
        {
            var values = await _orderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOrderDto>>(values);
        }

        public async Task<GetOrderByIdDto> GetOrderByIdDto(string id)
        {
            var value = await _orderCollection.Find(x => x.OrderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetOrderByIdDto>(value);
        }

    }
}
