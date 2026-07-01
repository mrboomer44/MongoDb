using MongoDb.Dtos.ProductDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.ProductServices
{
    public class ProductServices : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var Database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = Database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsyn(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsyn(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsyn()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetProductByIdDto> GetProductByIdDto(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductByIdDto>(value);
        }

        public Task UpdateProductAsyn(UpdateProductDto updateProductDto)
        {
           var value = _mapper.Map<Product>(updateProductDto);
           return _productCollection.ReplaceOneAsync(x => x.ProductId == updateProductDto.ProductId, value);
        }
    }
}
