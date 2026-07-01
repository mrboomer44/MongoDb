using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.TestimonialDto;
using MongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialService.GetAllTestimonialAsyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto _createTestimonialDto)
        {
            await _testimonialService.CreateTestimonialAsyn(_createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonialAsyn(id);
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetTestimonialByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto _updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonialAsyn(_updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }
    }
}

