using MongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MongoDb.ViewComponents
{
    public class _DefaultProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _DefaultProductComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsyn();
            var list = values.Take(3).ToList();
            return View(list);
        }
    }
}
