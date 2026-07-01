using MongoDb.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;
        public _DefaultFeatureComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsyn();
            var value = values.FirstOrDefault();
            return View(value);
        }
    }
}
