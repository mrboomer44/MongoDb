using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.FaqDto;
using MongoDb.Services.FaqServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class FaqController : Controller
    {
        private readonly IFaqServices _faqServices;
        public FaqController(IFaqServices faqServices)
        {
            _faqServices = faqServices;
        }
        public async Task<IActionResult> FaqList()
        {
            var values = await _faqServices.GetAllFaqAsyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateFaq()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFaq(CreateFaqDto _createFaqDto)
        {
            await _faqServices.CreateFaqAsyn(_createFaqDto);
            return RedirectToAction("FaqList");
        }
        public async Task<IActionResult> DeleteFaq(string id)
        {
            await _faqServices.DeleteFaqAsyn(id);
            return RedirectToAction("FaqList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFaq(string id)
        {
            var value = await _faqServices.GetFaqByIdDto(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFaq(UpdateFaqDto _updateFaqDto)
        {
            await _faqServices.UpdateFaqAsyn(_updateFaqDto);
            return RedirectToAction("FaqList");
        }
    }
}

