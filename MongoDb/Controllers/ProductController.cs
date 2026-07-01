using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.ProductDto;
using MongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto _createProductDto)
        {
            await _productService.CreateProductAsyn(_createProductDto);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsyn(id);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var value = await _productService.GetProductByIdDto(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto _updateProductDto)
        {
            await _productService.UpdateProductAsyn(_updateProductDto);
            return RedirectToAction("ProductList");
        }
     }
}

