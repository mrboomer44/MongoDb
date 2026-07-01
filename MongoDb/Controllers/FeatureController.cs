using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.FeatureDto;
using MongoDb.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _FeatureService;
        public FeatureController(IFeatureService featureService)
        {
            _FeatureService = featureService;
        }
        public async Task<IActionResult> FeatureList()
        {
            var values = await _FeatureService.GetAllFeatureAsyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto _createFeatureDto)
        {
            await _FeatureService.CreateFeatureAsyn(_createFeatureDto);
            return RedirectToAction("FeatureList");
        }
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _FeatureService.DeleteFeatureAsyn(id);
            return RedirectToAction("FeatureList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var value = await _FeatureService.GetFeatureByIdDto(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto _updateFeatureDto)
        {
            await _FeatureService.UpdateFeatureAsyn(_updateFeatureDto);
            return RedirectToAction("FeatureList");
        }
    }
}

