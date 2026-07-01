using MongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MongoDb.ViewComponents
{
    public class _DefaultTestimoialComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;
        public _DefaultTestimoialComponentPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialService.GetAllTestimonialAsyn();
            return View(values);
        }
    }
}
