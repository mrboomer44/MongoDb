using MongoDb.Dtos.ProductDto;

namespace MongoDb.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsyn();
        Task CreateProductAsyn(CreateProductDto createProductDto);
        Task UpdateProductAsyn(UpdateProductDto updateProductDto);
        Task DeleteProductAsyn(string id);
        Task<GetProductByIdDto> GetProductByIdDto(string id);
    }
}
 